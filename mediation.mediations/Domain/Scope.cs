namespace mediation.mediations.Domain;

public class Scope
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid JurisdictionId { get; set; }
}