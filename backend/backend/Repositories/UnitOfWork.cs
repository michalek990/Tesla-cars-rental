using backend.Entity;
using backend.Interfaces;

namespace backend.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    
    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async  Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}