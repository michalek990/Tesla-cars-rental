using System.Linq.Expressions;

namespace backend.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    void Add(TEntity entity);
    void Remove(TEntity entity);
}