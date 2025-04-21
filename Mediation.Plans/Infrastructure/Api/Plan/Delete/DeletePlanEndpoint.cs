using FastEndpoints;
using Mediation.Plans.Application;

namespace Mediation.Plans.Infrastructure.Api.Plan.Delete;

public class DeletePlanEndpoint(PlansService plansService) : Endpoint<DeletePlanRequest>
{
    public override void Configure()
    {
        Delete("/api/plans/{Id}");
    }

    public override async Task HandleAsync(DeletePlanRequest req, CancellationToken ct)
    {
        try
        {
            var result = await plansService.DeletePlan(req.Id);
            
            if (result)
                await SendNoContentAsync(ct);
            else
                await SendNotFoundAsync(ct);
        }
        catch (ArgumentException)
        {
            await SendNotFoundAsync(ct);
        }
        catch (Exception)
        {
            await SendErrorsAsync(500, ct);
        }
    }
}