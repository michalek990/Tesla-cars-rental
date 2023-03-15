using FluentValidation;

namespace backend.Service.Rental.Commands.UpdateRental;

public sealed class UpdateRentalCommandValidator : AbstractValidator<UpdateRentalCommand>
{
    public UpdateRentalCommandValidator()
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
        
        When(x => x.UpdateRentalDto is not null, () =>
        {
            RuleFor(u => u.UpdateRentalDto!.FirstName)
                .NotNull()
                .MaximumLength(50);
            
            RuleFor(u => u.UpdateRentalDto!.Surname)
                .NotNull()
                .MaximumLength(50);

            RuleFor(u => u.UpdateRentalDto!.RentalDateEnd)
                .NotNull()
                .GreaterThanOrEqualTo(DateTime.Now);
        });
    }
}