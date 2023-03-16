using System.Data;
using backend.Models;
using backend.Pagination;
using FluentValidation;

namespace backend.Service.RentalPoint.Queries.GetAllRentalPoints;

public sealed class GetAllRentalPointsQueryValidator : AbstractValidator<GetAllRentalPointsQuery>
{
    public GetAllRentalPointsQueryValidator()
    {
        RuleFor(c => c.PageRequestDto)
            .SetValidator(new PageRequestDtoValidator());
    }
}