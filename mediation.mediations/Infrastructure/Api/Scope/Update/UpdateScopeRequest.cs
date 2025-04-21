namespace mediation.mediations.Infrastructure.Api.Scope.Update;

public record UpdateScopeRequest(Guid JurisdictionId, Guid Id, string Name);