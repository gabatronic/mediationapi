using FastEndpoints;
using mediation.mediations.Domain;

namespace mediation.mediations.Infrastructure.Api.Scope;

public class GetScopesEndpoint(IMediationTermsRepository termsRepository) : Endpoint<GetScopesRequest>
{
    public override void Configure()
    {
        Get("/api/jurisdictions/{jurisdictionId}/scopes");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetScopesRequest req, CancellationToken ct)
    {
        var jurisdictionExists = await termsRepository.GetJurisdiction(req.JurisdictionId);
        if (jurisdictionExists == null)
        {
            await SendErrorsAsync(404, ct);
            return;
        }
        
        var scopes = await termsRepository.GetAllScopes(req.JurisdictionId);
        await SendAsync(scopes?.Select(s => new ScopeDto(s.Id, s.Name)) ?? [], 200, ct);
    }
}