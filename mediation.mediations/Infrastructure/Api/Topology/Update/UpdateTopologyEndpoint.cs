using FastEndpoints;
using mediation.mediations.Application;
using Microsoft.AspNetCore.Http;

namespace mediation.mediations.Infrastructure.Api.Topology.Update;

public class UpdateTopologyEndpoint(MediationTermsService termsService) : Endpoint<UpdateTopologyRequest>
{
    public override void Configure()
    {
        Put("/api/topologies/{Id}");
        Description(e => e.Produces(200));
    }

    public override async Task HandleAsync(UpdateTopologyRequest req, CancellationToken ct)
    {
        try
        {
            await termsService.UpdateTopology(req.Id, req.Name);
            await SendOkAsync(ct);
        }
        catch (ArgumentException)
        {
            await SendErrorsAsync(404, ct);
        }
    }
}