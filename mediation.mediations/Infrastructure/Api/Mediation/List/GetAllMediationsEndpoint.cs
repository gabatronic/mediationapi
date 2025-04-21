using FastEndpoints;
using mediation.mediations.Application;
using Microsoft.AspNetCore.Http;

namespace mediation.mediations.Infrastructure.Api.Mediation.List;

public class GetAllMediationsEndpoint(MediationService service) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/api/mediation");
        Description(e => e.Produces(200).WithTags("Mediation"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var mediations = await service.GetAllMediations();
        await SendAsync(mediations?.Select(m => new MediationDto(m.Id, m.ApplicantId, m.DefendantId, m.JurisdictionId, m.ScopeId, m.TopologyId, m.Subject, m.Description, m.PlanId)) ?? [], 200, cancellationToken);
    }
}