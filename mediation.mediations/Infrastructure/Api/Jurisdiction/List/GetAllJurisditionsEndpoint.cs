using FastEndpoints;
using mediation.mediations.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;


namespace mediation.mediations.Infrastructure.Api.Jurisdiction;

public class GetAllJurisdictionsEndpoint(IMediationTermsRepository termsRepository) : Endpoint<GetAllJurisdictionsRequest>
{
    public override void Configure()
    {
        Get("/api/jurisdictions/");
        Description(e => e.Produces(200).WithTags("Jurisdictions"));
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetAllJurisdictionsRequest request,
        CancellationToken cancellationToken)
    {
        var jurisdictions = await termsRepository.GetAllJurisdictions()
            .ConfigureAwait(false);
        
        await SendAsync(jurisdictions?.Select(j => new JurisdictionDto(j.Id, j.Name)) ?? [], 200,cancellationToken).ConfigureAwait(false);        
    }
}