using Mediation.Plans.Domain;

namespace Mediation.Plans.Infrastructure.Api.Plan.Create;

public record CreatePlanRequest(Guid Id, string Name, double Cost, string Description, ICollection<string> Features);