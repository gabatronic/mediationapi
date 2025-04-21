using FastEndpoints;
using mediation.mediations.Application;
using Microsoft.AspNetCore.Http;

namespace mediation.mediations.Infrastructure.Api.Mediation;

public class CreateMediationEndpoint(MediationService mediationService) : Endpoint<CreateMediationRequest>
{
    public override void Configure()
    {
        Post("/api/mediation/");
        Description(endpoint => endpoint.Produces(200));
    }

    public override async Task HandleAsync(CreateMediationRequest request, CancellationToken ct)
    {
        try
        {
            var builder = mediationService.GetMediationBuilder();
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
                .Build();
            
            await mediationService.CreateMediation(mediation);

            await SendOkAsync(cancellation: ct);
        }
        catch (ArgumentException)
        {
            await SendErrorsAsync(400, cancellation: ct);
        }
    }
}