using FastEndpoints;
using FluentValidation;

namespace mediation.mediations.Infrastructure.Api.Scope.Update;

public class UpdateScopeValidator : Validator<UpdateScopeRequest>
{
    public UpdateScopeValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}