namespace mediation.mediations.Infrastructure.Api.Topology.Create;

public record CreateTopologyRequest(Guid ScopeId, Guid Id, string Name);