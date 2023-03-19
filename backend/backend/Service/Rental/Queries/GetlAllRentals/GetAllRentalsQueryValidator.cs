using backend.Pagination;
using FluentValidation;

namespace backend.Service.Rental.Queries.GetlAllRentals;

public sealed class GetAllRentalsQueryValidator : AbstractValidator<GetAllRentalsQuery>
{
    public GetAllRentalsQueryValidator()
    {
        RuleFor(c => c.PageRequestDto)
            .SetValidator(new PageRequestDtoValidator());
    }
}