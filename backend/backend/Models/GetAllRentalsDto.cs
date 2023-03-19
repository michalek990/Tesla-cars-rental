using System.Linq.Expressions;
using AutoMapper;
using backend.Entity;
using backend.Interfaces;

namespace backend.Models;

public sealed class GetAllRentalsDto
{
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string PeselNumber { get; set; }
    public int ContactNumber { get; set; }
    public Nationality Nationality { get; set; }
    public Gender Gender { get; set; }
    public DateTime RentalDateStart { get; set; }
    public DateTime RentalDateEnd { get; set; }
    public double TotalCostOfRent { get; set; }
    public int CarId { get; set; }
    public int StartRentalPointId { get; set; }
    public int EndRentalPointId { get; set; }
}

public sealed class GetAllRentalsDtoProfile : Profile
{
    public GetAllRentalsDtoProfile()
    {
        CreateMap<Rental, GetAllRentalsDto>();
    }
}

public sealed class RentalsColumnSelector : IColumnSelector<Rental>
{
    public Dictionary<string, Expression<Func<Rental, object>>> ColumnSelector { get; } = new()
    {
        { nameof(Rental.Surname), m => m.Surname }
    };
}
