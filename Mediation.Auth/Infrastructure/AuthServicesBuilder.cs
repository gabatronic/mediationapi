using Mediation.Auth.Application;
using Mediation.Auth.Infrastructure.JwtTokenService;
using Mediation.Auth.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mediation.Auth.Infrastructure;

public static class AuthServicesBuilder
{
    public static IServiceCollection AddAuthServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AuthDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddScoped<IUserRepository, PostGresUserRepository>();
        services.AddScoped<IRoleRepository, PostgresRoleRepository>();
        services.AddScoped<ITokenService, JwtTokenService.JwtTokenService>();
        services.AddScoped<UserService>();
        
        return services;
    }
}