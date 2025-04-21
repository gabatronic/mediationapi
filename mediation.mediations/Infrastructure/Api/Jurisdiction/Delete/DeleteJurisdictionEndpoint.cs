using FastEndpoints;
using mediation.mediations.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace mediation.mediations.Infrastructure.Api.Jurisdiction.Delete;

public class DeleteJurisdictionEndpoint(MediationTermsService termsService) : Endpoint<DeleteJurisdictionRequest>
{
    public override void Configure()
    {
        Delete("/api/jurisdictions/{Id}");
        Description(e => e.Produces(200).WithGroupName("Jurisdictions"));
    }

    public override async Task HandleAsync(DeleteJurisdictionRequest req, CancellationToken ct)
    {
        try
        {
            var jurisdiction = await termsService.GetJurisdiction(req.Id);
            if (jurisdiction == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }
            
            await termsService.DeleteJurisdiction(req.Id);
            await SendOkAsync(ct);
        }
        catch (ArgumentException)
        {
            await SendErrorsAsync(404, ct);
        }
    }
}