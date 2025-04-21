using FastEndpoints;
using mediation.mediations.Application;
using Microsoft.AspNetCore.Http;

namespace mediation.mediations.Infrastructure.Api.Topology.Delete;

public class DeleteTopologyEndpoint(MediationTermsService termsService) : Endpoint<DeleteTopologyRequest>
{
    public override void Configure()
    {
        Delete("/api/topologies/{Id}");
        Description(e => e.Produces(201).WithTags("Topologies"));
    }

    public override async Task HandleAsync(DeleteTopologyRequest req, CancellationToken ct)
    {
        try
        {
            var result = await termsService.DeleteTopology(req.Id);
            if (result)
                await SendNoContentAsync(ct);
            else
                await SendNotFoundAsync(ct);
        }
        catch (ArgumentException)
        {
            await SendErrorsAsync(404, ct);
        }
    }
}