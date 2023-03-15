using FluentValidation;

namespace backend.Service.Rental.Commands.DeleteRental;

public sealed class DeleteRentalCommandValidator : AbstractValidator<DeleteRentalCommand>
{
    public DeleteRentalCommandValidator()
    {
        RuleFor(x => x.PeselNumber)
            .NotNull()
            .MaximumLength(11);
        
        RuleFor(x => x.Model)
            .NotNull()
            .MaximumLength(50);

        RuleFor(x => x.EndRentalPoint)
            .NotNull()
            .MaximumLength(100);
    }
}