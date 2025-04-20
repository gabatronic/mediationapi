namespace mediation.mediations.Domain;

public class Mediation
{
    public Guid Id { get; set; }
    public Guid ApplicantId { get; set; }
    public Guid DefendantId { get; set; }
    
    public Guid JurisdictionId { get; set; }
    public Guid ScopeId { get; set; }
    public Guid? TopologyId { get; set; }
    
    public required string Subject { get; set; }
    public required string Description { get; set; }
    
    public Guid PlanId { get; set; }
}