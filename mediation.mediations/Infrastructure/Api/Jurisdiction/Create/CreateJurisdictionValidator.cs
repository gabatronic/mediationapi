using FastEndpoints;
using FluentValidation;

namespace mediation.mediations.Infrastructure.Api.Jurisdiction.Create;

public class CreateJurisdictionValidator : Validator<CreateJurisdictionRequest>
{
    public CreateJurisdictionValidator()
    {
        RuleFor(r => r.Name).NotEmpty();
    }
}