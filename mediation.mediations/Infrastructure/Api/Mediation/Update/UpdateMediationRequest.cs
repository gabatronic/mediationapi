namespace mediation.mediations.Infrastructure.Api.Mediation.Update;

public class UpdateMediationRequest
{
    public Guid Id { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid? TopologyId { get; set; }
}