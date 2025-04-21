using FastEndpoints;
using FluentValidation;
namespace mediation.mediations.Infrastructure.Api.Scope;

public class CreateScopeValidator : Validator<CreateScopeRequest>
{
    public CreateScopeValidator()
    {
        RuleFor(scope => scope.Name).NotEmpty().WithMessage("Scope name is required.");
    }
}