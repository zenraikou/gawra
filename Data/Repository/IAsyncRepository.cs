using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;
using Data.Entities;

namespace Data.Repository
{
    public interface IAsyncRepository<T, TKey> where T : BaseEntity
    {
        Task<T> GetByIdAsync(TKey id);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        
        Task UpdateRangeAsync(List<T> entity);

        Task DeleteAsync(T entity);
        Task DeleteByIdAsync(TKey id);
        
        Task DeleteRangeAsync(List<T> entity);

        Task<int> CountAsync(ISpecification<T> spec);
        Task<int> CountAllAsync();
        Task<T> FirstOrDefaultAsync(ISpecification<T> spec);

        Task<List<T>> FetchAllPaginatedAsync(int pageSize, int currentPage);
        
        Task<List<T>> ListAllPaginatedAsync(ISpecification<T> spec, int pageSize, int currentPage);

        Task AddRangeAsync(List<T> addEntries);
    }
}