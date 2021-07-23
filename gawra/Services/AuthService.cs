using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Exceptions;
using Data;
using gawra.Configuration;
using gawra.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace gawra.Services
{
    /// <summary>
    /// Contains service methods handling user and authentication management.
    /// </summary>
    /// <inheritdoc cref="IAuthService"/>
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtConfig _jwtConfig;

        public AuthService(UserManager<ApplicationUser> userManager, IOptions<JwtConfig> jwtConfig)
        {
            _userManager = userManager;
            _jwtConfig = jwtConfig?.Value;
        }

        public async Task CreateUserAsync(CreateUserDto dto)
        {
            var existing = await _userManager.FindByEmailAsync(dto.Email);

            if (existing != null)
            {
                throw new UserWithEmailAlreadyExistsException(
                    $"There already exists an account with E-Mail {dto.Email}");
            }

            await _userManager.CreateAsync(new ApplicationUser()
            {
                Email = dto.Email,
                UserName = dto.UserName,
            }, dto.Password);
        }
        
        public async Task LoginAsync(CreateUserDto dto)
        {
            var existing = await _userManager.FindByEmailAsync(dto.Email);

            if (existing == null)
            {
                throw new UserWithEmailAlreadyExistsException(
                    $"There already exists an account with E-Mail {dto.Email}");
            }

            await _userManager.CreateAsync(new ApplicationUser()
            {
                Email = dto.Email,
                UserName = dto.UserName,
            }, dto.Password);
        }
        
        public async Task<(string token, DateTime ValidTo)> LoginAsync(LoginDto dto)
        {
            
            var user = await _userManager.FindByEmailAsync(dto.Email);
            
            if (user == null)
            {
                throw new AuthenticationException();
            }

            var validPassword = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!validPassword) throw new AuthenticationException();
            
            var claims = new List<Claim>  
            {  
                new(ClaimTypes.Name, user.UserName),  
                new(ClaimTypes.Email, user.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),  
            };  
  
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.SecretKey));  
  
            var token = new JwtSecurityToken(  
                issuer: _jwtConfig.SecretKey,
                audience: _jwtConfig.ValidAudience,
                expires: DateTime.Now.AddDays(7),
                claims: claims,  
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)  
            );  
  
            return(
                new JwtSecurityTokenHandler().WriteToken(token),  
                token.ValidTo
            );
        }
    }

    public interface IAuthService
    {
        /// <summary>
        /// Creates a user according to the given dto.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task CreateUserAsync(CreateUserDto dto);

        /// <summary>
        /// Authenticates the user with the data in the given dto.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>The issued jwt and it's valid to date.</returns>
        Task<(string token, DateTime ValidTo)> LoginAsync(LoginDto dto);
    }
}