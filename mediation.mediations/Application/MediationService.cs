using System.Threading.Channels;
using mediation.mediations.Domain;
using mediation.mediations.Infrastructure.Api.Mediation;

namespace mediation.mediations.Application;

public class MediationService(
    IMediationRepository mediationRepository, 
    IApplicantRepository applicantRepository, 
    IDefendantRepository defendantRepository,
    INotificationService<Mediation> notificationService)
{
    private readonly MediationBuilder _mediationBuilder = new MediationBuilder();
    
    public MediationBuilder GetMediationBuilder() => _mediationBuilder;
    
    public async Task CreateMediation(Mediation mediation)
    {
        var applicantExist = await applicantRepository.GetById(mediation.ApplicantId);
        
        if (applicantExist == null)
        {
            applicantExist = _mediationBuilder.GetApplicant();
            if (applicantExist == null)
                throw new InvalidOperationException($"Cannot create applicant with id {mediation.ApplicantId}");
            await applicantRepository.Create(applicantExist);
        }
        
        var defendantExists = await defendantRepository.GetById(mediation.DefendantId);
        if (defendantExists == null)
        {
            defendantExists = _mediationBuilder.GetDefendant();
            if (defendantExists == null)
                throw new InvalidOperationException($"Cannot create defendant with id {mediation.DefendantId}");
            await defendantRepository.Create(defendantExists);
        }
        
        await mediationRepository.Create(mediation);
        
        await notificationService.SendMessage(mediation);
    }

    public async Task<Mediation?> GetMediationById(Guid id) => await mediationRepository.GetById(id);
    
    public async Task<bool> UpdateMediation(Mediation mediation) => await mediationRepository.Update(mediation);
    
    public async Task<bool> DeleteMediation(Mediation mediation) => await mediationRepository.Delete(mediation);
    
    public async Task<IEnumerable<Mediation>> GetAllMediations() => await mediationRepository.GetAll();
}



