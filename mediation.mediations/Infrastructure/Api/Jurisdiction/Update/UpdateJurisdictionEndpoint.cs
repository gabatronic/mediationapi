using FastEndpoints;
using mediation.mediations.Application;
using Microsoft.AspNetCore.Http;

namespace mediation.mediations.Infrastructure.Api.Jurisdiction.Update;

public class UpdateJurisdictionEndpoint(MediationTermsService termsService) : Endpoint<UpdateJurisdictionRequest>
{
    public override void Configure()
    {
        Put("/api/jurisdictions/{Id}");
        Description(e => e.Produces(200));
    }

    public override async Task HandleAsync(UpdateJurisdictionRequest req, CancellationToken ct)
    {
        try
        {
            await termsService.UpdateJurisdiction(req.Id, req.Name);
            await SendOkAsync(ct);
        }
        catch (ArgumentException)
        {
            await SendErrorsAsync(404, ct);
        }
    }
}