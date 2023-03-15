using FluentValidation;

namespace backend.Service.Rental.Commands.CreateRental;

public sealed class CreateRentalCommandValidator : AbstractValidator<CreateRentalCommand>
{
    public CreateRentalCommandValidator()
    {
        RuleFor(r => r.FirstName)
            .NotNull()
            .MaximumLength(100);
        
        RuleFor(r => r.Surname)
            .NotNull()
            .MaximumLength(100);

        RuleFor(r => r.PeselNumber)
            .NotNull()
            .MaximumLength(14);

        RuleFor(r => r.ContactNumber)
            .NotNull()
            .GreaterThan(1)
            .LessThanOrEqualTo(999999999);

        RuleFor(r => r.Nationality)
            .NotNull()
            .IsInEnum();
        
        RuleFor(r => r.Gender)
            .NotNull()
            .IsInEnum();
        
        
        RuleFor(r => r.RentalDateEnd)
            .NotNull()
            .GreaterThan(DateTime.Now)
            .LessThanOrEqualTo(DateTime.Now.AddDays(20));
    }
}