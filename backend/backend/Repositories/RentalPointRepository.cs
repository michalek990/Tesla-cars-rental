using backend.Entity;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class RentalPointRepository : BaseRepository<RentalPoint>, IRentalPointRepository
{
    public RentalPointRepository(AppDbContext context) : base(context) { }
    
    public async Task<RentalPoint?> GetRentalPointByName(string name)
    {
        return await Context.RentalPoints
            .Where(r => r.RentalPointName == name)
            .FirstOrDefaultAsync();
    }
    
    public async Task<bool?> ExistByRentalPointName(string name)
    {
        return await Context.RentalPoints
            .Where(r => r.RentalPointName == name)
            .AnyAsync();
    }
}