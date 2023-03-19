using backend.Entity;
using backend.Pagination.Request;
using backend.Pagination.Response;

namespace backend.Interfaces;

public interface ICarRepository : IBaseRepistory<Car>
{
    public Task<Car?> GetCarByModelAndRentalPointId(string model, int rentalPointId);
    public Task<bool> IsCarAvailable(string model, int rentaPointId);
    public Task<Page<Car>> GetCarsFromRentalPoint(int rentalPointId, PageRequest<Car> pageRequest);

}