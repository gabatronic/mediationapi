namespace mediation.mediations.Domain;

public class Topology
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid ScopeId { get; set; }
}