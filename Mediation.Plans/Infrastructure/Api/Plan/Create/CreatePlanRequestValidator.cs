using FastEndpoints;
using FluentValidation;

namespace Mediation.Plans.Infrastructure.Api.Plan.Create;

public class CreatePlanRequestValidator : Validator<CreatePlanRequest>
{
    public CreatePlanRequestValidator()
    {
        RuleFor(e => e.Name).NotEmpty();
        RuleFor(e => e.Cost).NotEmpty().GreaterThan(0);
        RuleFor(e => e.Description).NotEmpty();
        RuleFor(e => e.Features).NotEmpty();
    }
}