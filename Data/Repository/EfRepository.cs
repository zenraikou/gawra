using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class EfRepository<T, TKey> : IAsyncRepository<T, TKey> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _dbContext;

        public EfRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteByIdAsync(TKey id)
        {
            var entity = await GetByIdAsync(id);
            await DeleteAsync(entity);
        }

        public async Task DeleteRangeAsync(List<T> entity)
        {
            foreach (var e in entity)
            {
                _dbContext.Set<T>().Remove(e);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<int> CountAllAsync()
        {
            return await _dbContext.Set<T>().CountAsync();
        }

        public async Task UpdateRangeAsync(List<T> entity)
        {
            foreach (var e in entity)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<List<T>> FetchAllPaginatedAsync(int pageSize, int currentPage)
        {
            return await _dbContext.Set<T>().OrderBy(x => x.Id).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToListAsync();
        }

        public async Task<List<T>> ListAllPaginatedAsync(ISpecification<T> spec, int pageSize, int currentPage)
        {
            return await ApplySpecification(spec).OrderBy(x => x.Id).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToListAsync();
        }

        public async Task AddRangeAsync(List<T> entity)
        {
            foreach (var ae in entity)
            {
                await _dbContext.Set<T>().AddAsync(ae);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            return await _dbContext.Set<T>().ToListAsync(spec);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            var evaluator = new SpecificationEvaluator();
            return evaluator.GetQuery(_dbContext.Set<T>(), spec);
        }
    }
}