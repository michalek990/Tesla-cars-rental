using backend.Entity;

namespace backend.Interfaces;

public interface IRentalPointRepository : IBaseRepistory<RentalPoint>
{
    public Task<RentalPoint?> GetRentalPointByName(string name);
    public Task<bool?> ExistByRentalPointName(string name);
}