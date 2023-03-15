using backend.Entity;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class RentalRepository : BaseRepository<Rental>, IRentalRepository
{
    public RentalRepository(AppDbContext context) : base(context) { }

    public async Task<Rental?> GetByPeselCarModelAndEndRentalPoint(string peselNubmer, string model, string endRentalPoint)
    {
        return await Context.Rentals
            .Where(c => c.PeselNumber == peselNubmer && c.Car.Model == model && c.EndRentalPoint.RentalPointName == endRentalPoint)
            .FirstOrDefaultAsync();
    }
    
    public async Task<bool?> ExistByPeselNumber(string pesel)
    {
        return await Context.Rentals
            .Where(r => r.PeselNumber == pesel && r.RentalDateStart <= DateTime.Now && r.RentalDateEnd >= DateTime.Now)
            .AnyAsync();
    }
}