using FastEndpoints;


namespace mediation.mediations.Infrastructure.Api.Jurisdition;

public class GetAllJurisdictionsEndpoint : Endpoint<GetAllJurisditionsRequest, IEnumerable<JurisditionDto>>
{
    public override void Configure()
    {
        Get("/jurisdition");
        AllowAnonymous();
    }
    public override async Task<IEnumerable<JurisditionDto>> HandleAsync(GetAllJurisditionsRequest request, CancellationToken cancellationToken)
}