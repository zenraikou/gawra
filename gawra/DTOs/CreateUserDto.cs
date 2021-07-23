using System.ComponentModel.DataAnnotations;

namespace gawra.DTOs
{
    public class CreateUserDto
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Password missmatch")]
        public string ConfirmPassword { get; set; }
    }
}