namespace mediation.mediations.Domain;

public interface IApplicantRepository
{
    public Task<bool> Create(Applicant defendant);
    public Task<bool> Update(Applicant defendant);
    public Task<bool> Delete(Applicant defendant);
    public Task<Applicant?> GetById(Guid id);
    public Task<Applicant?> GetByEmail(string email);
    public Task<IEnumerable<Applicant>> GetAll();
}