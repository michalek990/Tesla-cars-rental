using AutoMapper;
using backend.Entity;

namespace backend.Models;

public sealed class CreateRentalDto
{
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string PeselNumber { get; set; }
    public int ContactNumber { get; set; }
    public Nationality Nationality { get; set; }
    public Gender Gender { get; set; }
    public DateTime RentalDateEnd { get; set; }
    public string CarModel { get; set; }
    public string StartRentalPointName { get; set; }
    public string EndRentalPointName { get; set; }
    
}


public sealed class CreateRentalDtoProfile : Profile
{
    public CreateRentalDtoProfile()
    {
        CreateMap<Rental, CreateRentalDto>();
    }
}