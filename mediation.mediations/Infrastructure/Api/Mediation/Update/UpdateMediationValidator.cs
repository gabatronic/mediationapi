using FastEndpoints;
using FluentValidation;

namespace mediation.mediations.Infrastructure.Api.Mediation.Update;

public class UpdateMediationValidator : Validator<UpdateMediationRequest>
{
    public UpdateMediationValidator()
    {
        RuleFor(r => r.Subject).NotEmpty().MaximumLength(200);
        RuleFor(r => r.Description).NotEmpty().MaximumLength(500);
    }
}