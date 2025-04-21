using FastEndpoints;
using mediation.mediations.Application;
using mediation.mediations.Domain;
using Microsoft.AspNetCore.Http;

namespace mediation.mediations.Infrastructure.Api.Scope;

public class GetScopesEndpoint(MediationTermsService termsService) : Endpoint<GetScopesRequest, IEnumerable<ScopeDto>>
{
    public override void Configure()
    {
        Get("/api/jurisdictions/{JurisdictionId}/scopes");
        Description(endpoint => endpoint.Produces(404));
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetScopesRequest req, CancellationToken ct)
    {
        try
        {
            var scopes = await termsService.GetScopes(req.JurisdictionId);
            await SendAsync(scopes?.Select(s => new ScopeDto(s.Id, s.Name)) ?? [], 200, ct);
        }
        catch (ArgumentException)
        {
            await SendErrorsAsync(404, ct);
        }
    }
}