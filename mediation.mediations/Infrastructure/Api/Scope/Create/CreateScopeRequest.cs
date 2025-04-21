namespace mediation.mediations.Infrastructure.Api.Scope;

public record CreateScopeRequest(Guid JurisdictionId, Guid Id, string Name);