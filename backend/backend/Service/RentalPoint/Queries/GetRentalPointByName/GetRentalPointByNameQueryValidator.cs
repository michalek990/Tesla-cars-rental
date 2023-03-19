using FluentValidation;

namespace backend.Service.RentalPoint.Queries.GetRentalPointByName;

public sealed class GetRentalPointByNameQueryValidator : AbstractValidator<GetRentalPointByNameQuery>
{
    public GetRentalPointByNameQueryValidator()
    {
        RuleFor(c => c.rentalPointName)
            .NotNull()
            .MaximumLength(100);
    }
}