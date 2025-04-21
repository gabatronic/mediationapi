// filepath: mediation.mediations/Infrastructure/Api/Mediation/MediationResponseDto.cs
namespace mediation.mediations.Infrastructure.Api.Mediation;

public record MediationResponseDto(
    Guid Id, 
    string Subject, 
    string Description, 
    Guid ApplicantId, 
    Guid DefendantId, 
    Guid JurisdictionId, 
    Guid ScopeId, 
    Guid? TopologyId, 
    Guid PlanId);