namespace Mediation.Plans.Domain;

public class Plan
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public double Cost { get; set; }
    
    public ICollection<PlanFeature> Features { get; set; } = new List<PlanFeature>();
}