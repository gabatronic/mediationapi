using FastEndpoints;
using mediation.mediations.Application;
using Microsoft.AspNetCore.Http;

namespace mediation.mediations.Infrastructure.Api.Mediation.Delete;

public class DeleteMediationEndpoint(MediationService mediationService) : Endpoint<DeleteMediationRequest>
{
    public override void Configure()
    {
        Delete("/api/mediations/{Id}");
        Description(e => e.Produces(200));
    }

    public override async Task HandleAsync(DeleteMediationRequest req, CancellationToken ct)
    {
        try
        {
            var mediation = await mediationService.GetMediationById(req.Id);
            if (mediation == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }
            
            await mediationService.DeleteMediation(mediation);
            await SendOkAsync(ct);
        }
        catch (Exception ex)
        {
            await SendErrorsAsync(500, ct);
        }
    }
}