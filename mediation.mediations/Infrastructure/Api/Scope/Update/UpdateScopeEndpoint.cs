using FastEndpoints;
using mediation.mediations.Application;
using Microsoft.AspNetCore.Http;

namespace mediation.mediations.Infrastructure.Api.Scope.Update;

public class UpdateScopeEndpoint(MediationTermsService termsService) : Endpoint<UpdateScopeRequest>
{
    public override void Configure()
    {
        Put("/api/scopes/{Id}");
        Description(endpoint => endpoint.Produces(201).WithTags("Scopes"));
    }

    public override async Task HandleAsync(UpdateScopeRequest req, CancellationToken ct)
    {
        try
        {
            await termsService.UpdateScope(req.Id, req.Name);
            await SendOkAsync(ct);
        }
        catch (ArgumentException)
        {
            await SendErrorsAsync(400, ct);
        }
    }
}