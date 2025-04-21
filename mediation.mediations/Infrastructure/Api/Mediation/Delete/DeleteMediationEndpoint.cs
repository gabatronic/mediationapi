using FastEndpoints;
using mediation.mediations.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace mediation.mediations.Infrastructure.Api.Mediation.Delete;

public class DeleteMediationEndpoint(MediationService mediationService) : Endpoint<DeleteMediationRequest>
{
    public override void Configure()
    {
        Delete("/api/mediation/{Id}");
        Description(e => e.Produces(200).WithTags("Mediation"));
    }

    public override async Task HandleAsync(DeleteMediationRequest req, CancellationToken ct)
    {
        try
        {
            var mediation = await mediationService.DeleteMediation(req.Id);
            await SendOkAsync(ct);
        }
        catch (ArgumentException)
        {
            await SendErrorsAsync(404, ct);
        }
    }
}