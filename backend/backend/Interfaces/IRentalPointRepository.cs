using backend.Entity;
using backend.Pagination.Response;

namespace backend.Interfaces;

public interface IRentalPointRepository : IBaseRepistory<RentalPoint>
{
    public Task<RentalPoint?> GetRentalPointByName(string name);
}