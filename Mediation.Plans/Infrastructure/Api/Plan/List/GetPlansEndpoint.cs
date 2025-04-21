using FastEndpoints;
using Mediation.Plans.Application;
using Microsoft.AspNetCore.Http;

namespace Mediation.Plans.Infrastructure.Api.Plan.List;

public class GetPlansEndpoint(PlansService plansService) : Endpoint<GetPlansRequest, IEnumerable<PlanDto>>
{
    public override void Configure()
    {
        Get("/api/plans");
        Description(e => e.Produces(200).WithTags("Plans"));
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetPlansRequest req, CancellationToken ct)
    {
        var plans = await plansService.GetAllPlans();
        
        var result = plans.Select(p => new PlanDto(
            p.Id,
            p.Name,
            p.Description,
            p.Cost,
            p.Features.Select(f => new PlanFeatureDto(f.Id, f.Description))
        ));
        
        await SendAsync(result, cancellation: ct);
    }
}