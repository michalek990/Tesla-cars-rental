using backend.Models.Pagination;
using FluentValidation;

namespace backend.Pagination;

public sealed class PageRequestDtoValidator : AbstractValidator<PageRequestDto>
{
    public PageRequestDtoValidator()
    {
        RuleFor(a => a.PageSize)
            .GreaterThan(0);

        RuleFor(a => a.PageNumber)
            .GreaterThan(0);
    }     
}