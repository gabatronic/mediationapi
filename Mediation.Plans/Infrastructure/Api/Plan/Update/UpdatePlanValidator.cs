using FastEndpoints;
using FluentValidation;

namespace Mediation.Plans.Infrastructure.Api.Plan.Update;

public class UpdatePlanValidator : Validator<UpdatePlanRequest>
{
    public UpdatePlanValidator()
    {
        RuleFor(e => e.Name).NotEmpty().WithMessage("Plan name is required");
        RuleFor(e => e.Cost).GreaterThanOrEqualTo(0).WithMessage("Cost cannot be negative");
    }
}