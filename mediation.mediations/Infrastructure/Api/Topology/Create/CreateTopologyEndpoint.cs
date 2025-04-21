using FastEndpoints;
using mediation.mediations.Application;
using Microsoft.AspNetCore.Http;

namespace mediation.mediations.Infrastructure.Api.Topology.Create;

public class CreateTopologyEndpoint(MediationTermsService termsService) : Endpoint<CreateTopologyRequest>
{
    public override void Configure()
    {
        Post("/api/scopes/{ScopeId}/topologies");
        Description(e => e.Produces(201).WithTags("Topologies"));
    }

    public override async Task HandleAsync(CreateTopologyRequest req, CancellationToken ct)
    {
        try
        {
            await termsService.CreateTopology(req.ScopeId, req.Id, req.Name);
            await SendCreatedAtAsync($"/api/scopes/{req.ScopeId}/topologies/{req.Id}", null, ct);
        }
        catch (ArgumentException)
        {
            await SendErrorsAsync(400, ct);
        }
    }
}