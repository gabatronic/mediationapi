using FastEndpoints;
using mediation.mediations.Domain;
using Microsoft.AspNetCore.Http;

namespace mediation.mediations.Infrastructure.Api.Topology;

public class GetTopologiesEndpoint(IMediationTermsRepository termsRepository) : Endpoint<GetTopologiesRequest, IEnumerable<TopologyDto>>
{
    public override void Configure()
    {
        Get("/api/scopes/{id}/topologies");
        Description(e => e.Produces(200).WithTags("Topologies"));
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetTopologiesRequest req, CancellationToken ct)
    {
        var scopeExists = await termsRepository.GetScope(req.ScopeId);
        if (scopeExists == null)
        {
            await SendErrorsAsync(404, ct);
            return;
        }
        var topologies = await termsRepository.GetAllTopologies(req.ScopeId);
        await SendAsync(topologies?.Select(t => new TopologyDto(t.Id, t.Name)) ?? [], 200, ct);
    }
}