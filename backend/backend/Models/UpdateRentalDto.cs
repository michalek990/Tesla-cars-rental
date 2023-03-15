using AutoMapper;
using backend.Entity;

namespace backend.Models;

public sealed class UpdateRentalDto
{
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public DateTime RentalDateEnd { get; set; }
}

public sealed class UpdateRentalDtoProfile : Profile
{
    public UpdateRentalDtoProfile()
    {
        CreateMap<Rental, UpdateRentalDto>();
    }
}