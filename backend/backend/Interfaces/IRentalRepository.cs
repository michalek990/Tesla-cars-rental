using backend.Entity;

namespace backend.Interfaces;

public interface IRentalRepository : IBaseRepistory<Rental>
{
    public Task<Rental?> GetByPeselCarModelAndEndRentalPoint(string eselNumber, string model, string endRentalPoint);
    public Task RemoveAllExpiredRentals();
}