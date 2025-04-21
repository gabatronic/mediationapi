using FastEndpoints;
using mediation.mediations.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace mediation.mediations.Infrastructure.Api.Jurisdiction.Create;

public class CreateJurisdictionEndpoint(MediationTermsService  termsService) : Endpoint<CreateJurisdictionRequest>
{
    public override void Configure()
    {
        Post("/api/jurisdictions");
        Description(e => e.Produces(201).WithGroupName("Jurisdictions"));
    }

    public override async Task HandleAsync(CreateJurisdictionRequest req, CancellationToken ct)
    {
        try
        {
            await termsService.CreateJurisdiction(req.Id, req.Name);
            await SendOkAsync(ct);
        }
        catch (ArgumentException)
        {
            await SendErrorsAsync(400, ct);
        }
    }
}