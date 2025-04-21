using FastEndpoints;
using mediation.mediations.Application;

namespace mediation.mediations.Infrastructure.Api.Mediation.Get;

public class GetMediationEndpoint(MediationService mediationService) : Endpoint<GetMediationRequest, MediationResponseDto>
{
    public override void Configure()
    {
        Get("/api/mediation/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetMediationRequest req, CancellationToken ct)
    {
        var mediation = await mediationService.GetMediationById(req.Id);
        
        if (mediation == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        await SendAsync(new MediationResponseDto(
            mediation.Id,
            mediation.Subject,
            mediation.Description,
            mediation.ApplicantId,
            mediation.DefendantId,
            mediation.JurisdictionId,
            mediation.ScopeId,
            mediation.TopologyId,
            mediation.PlanId
        ), cancellation: ct);
    }
}