namespace Mediation.Plans.Infrastructure.Api.Plan.List;

public record PlanDto(
    Guid Id, 
    string Name, 
    string Description, 
    double Cost, 
    IEnumerable<PlanFeatureDto> Features);

public record PlanFeatureDto(Guid Id, string Description);