using backend.Pagination;
using FluentValidation;

namespace backend.Service.Car.Queries.GetCarsByRentalPoint;

public sealed class GetCarsByRentalPointQueryValidator : AbstractValidator<GetCarsByRentalPointQuery>
{
    public GetCarsByRentalPointQueryValidator()
    {
        RuleFor(c => c.rentalPointName)
            .NotNull()
            .MaximumLength(100);

        RuleFor(c => c.PageRequestDto)
            .SetValidator(new PageRequestDtoValidator());
    }
}