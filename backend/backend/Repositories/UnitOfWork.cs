using backend.Entity;
using backend.Interfaces;

namespace backend.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public ICarRepository Cars { get; }
    public IRentalRepository Rentals { get; }
    public IRentalPointRepository RentalPoints { get; }
    public UnitOfWork(AppDbContext context, 
        ICarRepository cars,
        IRentalRepository rentals,
        IRentalPointRepository rentalPoints)
    {
        _context = context;
        Cars = cars;
        Rentals = rentals;
        RentalPoints = rentalPoints;
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