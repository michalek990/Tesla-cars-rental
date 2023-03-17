using backend.Pagination.Request;

namespace backend.Models.Pagination;

public sealed class SortDto
{
    public string? SortBy { get; init; }
    public SortDirection? SortDirection { get; init; }
}