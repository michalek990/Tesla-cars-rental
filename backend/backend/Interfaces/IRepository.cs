using backend.Pagination.Request;
using backend.Pagination.Response;

namespace backend.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<Page<TEntity>> GetAllAsync(PageRequest<TEntity> pageRequest);
    void Add(TEntity entity);
    void Remove(TEntity entity);
}