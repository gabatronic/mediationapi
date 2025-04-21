using Mediation.Plans.Application;
using Mediation.Plans.Domain;
using Mediation.Plans.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mediation.Plans.Infrastructure;

public static class PlansServicesBuilder
{
    public static IServiceCollection AddPlansServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PlanDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddScoped<IPlanRepository, PostgresPlanRepository>();
        services.AddScoped<PlansService>();
        
        return services;
    }
}