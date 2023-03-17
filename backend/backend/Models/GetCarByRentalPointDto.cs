using AutoMapper;
using backend.Entity;

namespace backend.Models;

public sealed class GetCarByRentalPointDto
{
    public string Model { get; set; }
    public string VIN { get; set; }
    public int RentalPointId { get; set; }
}

public sealed class GetCarByRentalPointDtoProfile : Profile
{
    public GetCarByRentalPointDtoProfile()
    {
        CreateMap<Car, GetCarByRentalPointDto>();
    }
}
