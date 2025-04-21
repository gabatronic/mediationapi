using System.Threading.Channels;
using mediation.mediations.Application;
using mediation.mediations.Domain;
using mediation.mediations.Infrastructure.Notification;
using mediation.mediations.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mediation.mediations.Infrastructure;

public static class MediationServicesBuilder
{
    public static IServiceCollection AddMediationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MediationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddScoped<IApplicantRepository, PostgresApplicantRepository>();
        services.AddScoped<IDefendantRepository, PostgresDefendantRepository>();
        services.AddScoped<IMediationRepository, PostgresMediationRepository>();
        services.AddScoped<IMediationTermsRepository, PostgresMediationTermsRepository>();
        services.AddScoped<INotificationService<Mediation>, NotificationChannels>();
        services.AddScoped<MediationService>();
        
        return services;
    }
}