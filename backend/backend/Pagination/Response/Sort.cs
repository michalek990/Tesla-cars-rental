using backend.Pagination.Request;

namespace backend.Pagination.Response;

public class Sort
{
    public string? SortBy { get; init; }
    public SortDirection? Direction { get; init; }
}