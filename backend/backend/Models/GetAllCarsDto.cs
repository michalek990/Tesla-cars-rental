using System.Linq.Expressions;
using AutoMapper;
using backend.Entity;
using backend.Interfaces;

namespace backend.Models;

public sealed class GetAllCarsDto
{
    public string Model { get; set; }
    public decimal HorsePower { get; set; }
    public string VIN { get; set; }
    public int YearOfProduction { get; set; }
    public bool Available { get; set; }
    public double CostPerDay { get; set; }
    public int RentalPointId { get; set; }
}

public sealed class GetAllCarsDtoProfile : Profile
{
    public GetAllCarsDtoProfile()
    {
        CreateMap<Car, GetAllCarsDto>();
    }
}

public sealed class CarColumnSelector : IColumnSelector<Car>
{
    public Dictionary<string, Expression<Func<Car, object>>> ColumnSelector { get; } = new()
    {
        { nameof(Car.Model), m => m.Model }
    };
}