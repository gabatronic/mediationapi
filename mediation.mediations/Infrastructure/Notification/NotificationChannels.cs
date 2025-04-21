using System.Threading.Channels;
using mediation.mediations.Application;
using mediation.mediations.Domain;
using MediationWorker;

namespace mediation.mediations.Infrastructure.Notification;

public class NotificationChannels(Channel<NewMediationItem> channel, 
    IMediationTermsRepository mediationTermsRepository,
    IApplicantRepository applicantRepository) : INotificationService<Mediation>
{
    public async Task SendMessage(Mediation message)
    {
        var jurisdiction = await mediationTermsRepository.GetJurisdiction(message.JurisdictionId);
        var scope = await mediationTermsRepository.GetScope(message.ScopeId);
        var applicant = await applicantRepository.GetById(message.ApplicantId);
        if (jurisdiction != null && scope != null && applicant != null)
        {
            var notification = new NewMediationItem(
                message.Id, 
                applicant.Email, 
                applicant.FirstName, 
                applicant.LastName, 
                message.Subject, 
                jurisdiction.Name,
                scope.Name, 
                DateTime.UtcNow);
            
            await channel.Writer.WriteAsync(notification);
        }
    }
}