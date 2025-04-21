namespace mediation.mediations.Infrastructure.Api.Mediation;

public class MediationDto
{
    public Guid Id { get; set; }
    public Guid ApplicantId { get; set; }
    public Guid DefendantId { get; set; }
    public Guid JurisdictionId { get; set; }
    public Guid ScopeId { get; set; }
    public Guid? TopologyId { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid PlanId { get; set; }
}