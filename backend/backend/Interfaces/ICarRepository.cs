using backend.Entity;

namespace backend.Interfaces;

public interface ICarRepository : IBaseRepistory<Car>
{
    public Task<Car?> GetCarByModelAndRentalPointId(string model, int rentalPointId);
    public Task<bool> ExistByModel(string model);
    public Task<bool> IsCarAvailable(string model, int rentaPointId);
}