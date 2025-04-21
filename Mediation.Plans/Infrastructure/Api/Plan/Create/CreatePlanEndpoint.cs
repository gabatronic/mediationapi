using FastEndpoints;
using Mediation.Plans.Application;
using Microsoft.AspNetCore.Http;

namespace Mediation.Plans.Infrastructure.Api.Plan.Create;

public class CreatePlanEndpoint(PlansService service) : Endpoint<CreatePlanRequest>
{
    public override void Configure()
    {
        Post("/api/plans");
        Description(e => e.Produces(200));
    }

    public override async Task HandleAsync(CreatePlanRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await service.CreatePlan(request.Id, request.Name);
            if (!result)
                throw new Exception("Failed to create plan");
        }
        catch (ArgumentException)
        {
            await SendErrorsAsync(400, cancellationToken);
        }
        catch (Exception)
        {
            await SendErrorsAsync(500, cancellationToken);
        }
    }
}