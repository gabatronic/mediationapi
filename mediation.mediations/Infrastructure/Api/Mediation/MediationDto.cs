namespace mediation.mediations.Infrastructure.Api.Mediation;

public record MediationDto(
    Guid Id,
    Guid ApplicantId,
    Guid DefendantId,
    Guid JurisdictionId,
    Guid ScopeId,
    Guid? TopologyId,
    string Subject,
    string Description,
    Guid PlanId);
