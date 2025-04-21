using FastEndpoints;
using FluentValidation;

namespace Mediation.Auth.Infrastructure.Api.Role.Delete;

public class DeleteRoleValidator : Validator<DeleteRoleRequest>
{
    public DeleteRoleValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Role ID is required");
    }
}