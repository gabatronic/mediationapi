namespace mediation.mediations.Domain;

public interface IMediationRepository
{
    public Task<bool> Create(Mediation mediation);
    public Task<bool> Update(Mediation mediation);
    public Task<bool> Delete(Mediation mediation);
    public Task<Mediation?> GetById(Guid id);
    public Task<IEnumerable<Mediation>> GetAll();
}