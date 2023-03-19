namespace backend.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICarRepository Cars { get; }
    IRentalRepository Rentals { get; }
    IRentalPointRepository RentalPoints { get; }
    Task SaveAsync();
}