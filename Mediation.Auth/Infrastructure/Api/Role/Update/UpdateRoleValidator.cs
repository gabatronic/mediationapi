using FastEndpoints;
using FluentValidation;

namespace Mediation.Auth.Infrastructure.Api.Role.Update;

public class UpdateRoleValidator : Validator<UpdateRoleRequest>
{
    public UpdateRoleValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Role ID is required");
        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Role name is required")
            .MaximumLength(50).WithMessage("Role name cannot exceed 50 characters");
        
        RuleFor(x => x.Description)
            .MaximumLength(200).WithMessage("Description cannot exceed 200 characters");
    }
}