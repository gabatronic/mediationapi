using FastEndpoints;
using mediation.mediations.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace mediation.mediations.Infrastructure.Api.Mediation.Update;

public class UpdateMediationEndpoint(MediationService service) : Endpoint<UpdateMediationRequest>
{
    public override void Configure()
    {
        Put("/api/mediation/{Id}");
        Description(e => e.Produces(201).WithTags("Mediation"));
    }
    public override async Task HandleAsync(UpdateMediationRequest request, CancellationToken cancellationToken)
    {
        var builder = service.GetMediationBuilder();
        var applicant = request.Applicant;
        var defendant = request.Defendant;
        var mediation = builder
            .AddApplicant(applicant.Id,
                applicant.FirstName,
                applicant.LastName,
                applicant.Email,
                applicant.Phone,
                applicant.Address,
                applicant.City,
                applicant.PostalCode,
                applicant.BornPlace,
                applicant.Country,
                applicant.DateOfBirth)
            .AddDefendant(defendant.Id, defendant.FirstName, defendant.LastName, defendant.Email,
                defendant.Phone,
                defendant.Country)
            .SetJurisdiction(request.JurisdictionId)
            .SetScope(request.ScopeId)
            .SetSubject(request.Subject)
            .SetDescription(request.Description)
            .Build();
        
        await service.UpdateMediation(mediation);
        await SendOkAsync(cancellationToken);
    }
}