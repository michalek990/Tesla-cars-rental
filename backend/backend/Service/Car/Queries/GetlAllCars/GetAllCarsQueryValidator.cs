using backend.Pagination;
using FluentValidation;

namespace backend.Service.Car.Queries.GetlAllCars;

public sealed class GetAllCarsQueryValidator : AbstractValidator<GetAllCarsQuery>
{
    public GetAllCarsQueryValidator()
    {
        RuleFor(a => a.PageRequestDto)
            .SetValidator(new PageRequestDtoValidator());
    }
}