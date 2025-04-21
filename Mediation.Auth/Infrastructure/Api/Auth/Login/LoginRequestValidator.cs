using FastEndpoints;
using FluentValidation;

namespace Mediation.Auth.Infrastructure.Api.Auth.Login;

public class LoginRequestValidator : Validator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}