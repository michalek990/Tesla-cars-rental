using backend.Entity;
using backend.Entity.Common;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public abstract class BaseRepository<TEntity> : Repository<TEntity>, IBaseRepistory<TEntity> where TEntity : BaseEntity
{
    protected BaseRepository(AppDbContext context) : base(context) {}

    public async Task<TEntity?> GetAsync(long id)
    {
        return await Context.Set<TEntity>()
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> ExistById(long id)
    {
        return await Context.Set<TEntity>()
            .Where(t => t.Id == id)
            .AnyAsync();
    }
}