using backend.Entity;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class CarRepostitory : BaseRepository<Car>, ICarRepository
{
    public CarRepostitory(AppDbContext context) : base(context) { }
    
    public async Task<Car?> GetCarByModelAndRentalPointId(string model, int rentalPointId)
    {
        return await Context.Cars
            .Where(c => c.Model == model && c.RentalPointId == rentalPointId)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> ExistByModel(string model)
    {
        return await Context.Cars
            .Where(c => c.Model == model)
            .AnyAsync();    
    }

    public async Task<bool> IsCarAvailable(string model, int rentalPointId)
    {
        return await Context.Cars
            .Where(c => c.Model == model && c.RentalPointId == rentalPointId)
            .Select(c => c.Available == true)
            .FirstOrDefaultAsync();
        
    }
}