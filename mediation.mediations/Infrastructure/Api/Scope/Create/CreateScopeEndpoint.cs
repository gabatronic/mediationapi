using FastEndpoints;
using mediation.mediations.Application;
using mediation.mediations.Domain;

namespace mediation.mediations.Infrastructure.Api.Scope;

public class CreateScopeEndpoint(MediationTermsService termsService) : Endpoint<CreateScopeRequest>
{
    public override void Configure()
    {
        Post("/api/jurisdictions/{JurisdictionId}/scopes");
    }

    public override async Task HandleAsync(CreateScopeRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await termsService.CreateScope(request.JurisdictionId, request.Id, request.Name);
            await SendOkAsync(cancellationToken);
        }
        catch (ArgumentException)
        {
            await SendErrorsAsync(404, cancellationToken);
        }
    }
}