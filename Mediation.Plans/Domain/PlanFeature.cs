namespace Mediation.Plans.Domain;

public class PlanFeature
{
    public required Guid  PlanId { get; set; }
    public required Guid Id { get; set; }
    public required string Description { get; set; }
}