using FastEndpoints;
using mediation.mediations.Application;
using Microsoft.AspNetCore.Http;

namespace mediation.mediations.Infrastructure.Api.Scope.Delete;

public class DeleteScopeEndpoint(MediationTermsService termsService) : Endpoint<DeleteScopeRequest>
{
    public override void Configure()
    {
        Delete("/api/scopes/{Id}");
        Description(endpoint => endpoint.Produces(201));
    }

    public override async Task HandleAsync(DeleteScopeRequest req, CancellationToken ct)
    {
        try
        {
            await termsService.DeleteScope(req.Id);
            await SendOkAsync(ct);
        }
        catch (ArgumentException)
        {
            await SendErrorsAsync(400, ct);
        }
    }
}