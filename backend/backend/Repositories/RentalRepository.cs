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

    public async Task RemoveAllExpiredRentals()
    {
        var expiredRentals = await Context.Rentals
            .Where(r => r.RentalDateEnd < DateTime.Now)
            .ToListAsync();

        if (expiredRentals != null && expiredRentals.Count > 0)
        {
            foreach (var rental in expiredRentals)
            {
                var car = await Context.Cars.FindAsync(rental.CarId);
                if (car != null && car.Available == false)
                {
                    car.Available = true;
                    car.RentalPointId = rental.EndRentalPointId;
                }
                Context.Rentals.Remove(rental);
            }
            await Context.SaveChangesAsync();
        }
    }

    public async Task<bool?> ExistByPeselNumber(string pesel)
    {
        return await Context.Rentals
            .Where(r => r.PeselNumber == pesel && r.RentalDateStart <= DateTime.Now && r.RentalDateEnd >= DateTime.Now)
            .AnyAsync();
    }
}