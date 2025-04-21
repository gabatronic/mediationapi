using FastEndpoints;
using Mediation.Plans.Application;
using Mediation.Plans.Infrastructure.Api.Plan.List;

namespace Mediation.Plans.Infrastructure.Api.Plan.Get;

public class GetPlanEndpoint(PlansService service) : Endpoint<GetPlanRequest>
{
    public override void Configure()
    {
        Get("/api/plan/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetPlanRequest request, CancellationToken cancellationToken)
    {
        var plan = await service.GetPlanById(request.Id);
        if (plan == null)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }
        
        await SendAsync(new PlanDto(plan.Id, plan.Name, plan.Description, plan.Cost, plan.Features?.Select(f => new PlanFeatureDto(f.Id, f.Description)) ?? []), 200, cancellationToken);
    }
}