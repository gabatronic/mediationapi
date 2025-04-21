using FastEndpoints;
using FluentValidation;

namespace Mediation.Auth.Infrastructure.Api.Role.UnassignRole;

public class UnassignRoleValidator : Validator<UnassignRoleRequest>
{
    public UnassignRoleValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required");
        
        RuleFor(x => x.RoleId)
            .NotEmpty().WithMessage("Role ID is required");
    }
}