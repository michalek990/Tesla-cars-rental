using backend.Entity;

namespace backend.Interfaces;

public interface IRentalRepository : IBaseRepistory<Rental>
{
    public Task<bool?> ExistByPeselNumber(string pesel);
}