namespace mediation.mediations.Domain;

public interface IDefendantRepository
{
    public Task<bool> Create(Defendant defendant);
    public Task<bool> Update(Defendant defendant);
    public Task<bool> Delete(Defendant defendant);
    public Task<Defendant?> GetById(Guid id);
    public Task<IEnumerable<Defendant>> GetAll();
}