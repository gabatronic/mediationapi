using FastEndpoints;
using Mediation.Plans.Application;
using Mediation.Plans.Infrastructure.Api.Plan.List;
using Microsoft.AspNetCore.Http;

namespace Mediation.Plans.Infrastructure.Api.Plan.Get;

public class GetPlanEndpoint(PlansService service) : Endpoint<GetPlanRequest>
{
    public override void Configure()
    {
        Get("/api/plan/{id}");
        Description(e => e.Produces(200).WithTags("Plans"));
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
        
        await SendAsync(new PlanDto(plan.Id, plan.Name, plan.SubTitle, plan.Description, plan.Cost, plan.Features?.Select(f => new PlanFeatureDto(f.Id, f.Description)) ?? []), 200, cancellationToken);
    }
}