namespace Mediation.Plans.Infrastructure.Api.Plan.Update;

public record UpdatePlanRequest(
    Guid Id, 
    string Name, 
    string Description, 
    double Cost,
    IEnumerable<FeatureRequest>? Features = null);
    
public record FeatureRequest(Guid Id, string Description);