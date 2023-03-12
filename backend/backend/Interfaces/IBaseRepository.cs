using backend.Entity.Common;

namespace backend.Interfaces;

public interface IBaseRepistory<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetAsync(long id);

    Task<bool> ExistById(long id);
}