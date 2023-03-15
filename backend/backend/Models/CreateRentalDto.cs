using AutoMapper;
using backend.Entity;

namespace backend.Models;

public sealed record CreateRentalDto(
    string FirstName,
    string Surname,
    string PeselNumber,
    int ContactNumber,
    Nationality Nationality,
    Gender Gender,
    DateTime RentalDateStart,
    DateTime RentalDateEnd,
    string CarModel,
    string StartRentalPointName,
    string EndRentalPointName);

public sealed class CreateRentalDtoProfile : Profile
{
    public CreateRentalDtoProfile()
    {
        CreateMap<Rental, CreateRentalDto>();
    }
}