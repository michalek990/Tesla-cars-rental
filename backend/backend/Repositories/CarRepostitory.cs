using backend.Entity;
using backend.Interfaces;
using backend.Models.Pagination;
using backend.Pagination.Request;
using backend.Pagination.Response;
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

    public async Task<bool> IsCarAvailable(string model, int rentalPointId)
    {
        return await Context.Cars
            .Where(c => c.Model == model && c.RentalPointId == rentalPointId)
            .Select(c => c.Available == true)
            .AnyAsync();
        
    }
    
    public async Task<Page<Car>> GetCarsFromRentalPoint(int rentalPointId, PageRequest<Car> pageRequest)
    {
        var query = Context.Cars
            .Include(f => f.RentalPoints)
            .Where(f => f.RentalPointId == rentalPointId);
            

        return await Paginate(query, pageRequest);
    }
}