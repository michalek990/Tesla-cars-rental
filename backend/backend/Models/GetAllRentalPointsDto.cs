using System.Linq.Expressions;
using AutoMapper;
using backend.Entity;
using backend.Interfaces;

namespace backend.Models;

public sealed class GetAllRentalPointsDto
{
    public string RentalPointName { get; set; }
    public string City { get; set; }
    public string? Street { get; set; }
    public int Number { get; set; }
}

public sealed class GetAllRentalPointsDtoProfile : Profile
{
    public GetAllRentalPointsDtoProfile()
    {
        CreateMap<RentalPoint, GetAllRentalPointsDto>();
    }
}

public sealed class RentalPointColumnSelector : IColumnSelector<RentalPoint>
{
    public Dictionary<string, Expression<Func<RentalPoint, object>>> ColumnSelector { get; } = new()
    {
        { nameof(RentalPoint.RentalPointName), m => m.RentalPointName }
    };
}