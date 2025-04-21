using FastEndpoints;
using Mediation.Plans.Application;

namespace Mediation.Plans.Infrastructure.Api.Plan.Update;

public class UpdatePlanEndpoint(PlansService plansService) : Endpoint<UpdatePlanRequest>
{
    public override void Configure()
    {
        Put("/api/plans/{Id}");
    }

    public override async Task HandleAsync(UpdatePlanRequest req, CancellationToken ct)
    {
        try
        {
            var result = await plansService.UpdatePlan(
                req.Id, 
                req.Name, 
                req.Description, 
                req.Cost);
                
            if (result)
                await SendOkAsync(cancellation: ct);
            else
                await SendErrorsAsync(500, ct);
        }
        catch (ArgumentException)
        {
            await SendNotFoundAsync(ct);
        }
        catch (Exception)
        {
            await SendErrorsAsync(500, cancellation: ct);
        }
    }
}