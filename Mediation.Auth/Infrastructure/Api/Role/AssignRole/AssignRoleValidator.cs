using FastEndpoints;
using FluentValidation;

namespace Mediation.Auth.Infrastructure.Api.Role.AssignRole;

public class AssignRoleValidator : Validator<AssignRoleRequest>
{
    public AssignRoleValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required");
        
        RuleFor(x => x.RoleId)
            .NotEmpty().WithMessage("Role ID is required");
    }
}