using mediation.mediations.Domain;
using Microsoft.AspNetCore.Builder;

namespace mediation.mediations.Application;

public class MediationBuilder()
{
    private Applicant? _applicant;
    private Defendant? _defendant;
    private Guid? _jurisdictionId;
    private Guid? _scopeId;
    private Guid? _topologyId;
    private string? _subject;
    private string? _description;
    private Guid _plan;
    public MediationBuilder AddApplicant(Guid id, string firstName, string lastName, string email,
        string phone, string address, string city, string postalCode, string bornPlace, string country, DateTime dateOfBird)
    {
        _applicant = new Applicant()
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Phone = phone,
            Address = address,
            City = city,
            PostalCode = postalCode,
            BornPlace = bornPlace,
            Country = country,
            DateOfBirth = dateOfBird
        };
        
        return this;
    }
    public Applicant? GetApplicant() => _applicant;
    
    public MediationBuilder AddDefendant(Guid id, string firstName, string lastName, string email,string phone, string country)
    {
        _defendant = new Defendant()
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Phone = phone,
            Country = country
        };
        
        return this;
    }
    public Defendant? GetDefendant() => _defendant;

    public MediationBuilder SetJurisdiction(Guid id)
    {
        _jurisdictionId = id;
        return this;
    }
    public MediationBuilder SetScope(Guid id)
    {
        _scopeId = id;
        return this;
    }
    public MediationBuilder SetTopology(Guid id)
    {
        _topologyId = id;
        return this;
    }

    public MediationBuilder SetSubject(string subject)
    {
        _subject = subject;
        return this;
    }

    public MediationBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public MediationBuilder SetPlan(Guid id)
    {
        _plan = id;
        return this;
    }

    public Mediation Build()
    {
        ArgumentNullException.ThrowIfNull(_applicant, nameof(_applicant));
        ArgumentNullException.ThrowIfNull(_defendant, nameof(_defendant));
        
        if (_jurisdictionId == null)
            throw new ArgumentNullException(nameof(_jurisdictionId), "Jurisdiction id is null");
        if (_scopeId == null)
            throw new ArgumentNullException(nameof(_scopeId), "Scope id is null");
        if (_topologyId == null)
            throw new ArgumentNullException(nameof(_topologyId), "Topology id is null");
        
        ArgumentNullException.ThrowIfNull(_subject, nameof(_subject));
        ArgumentNullException.ThrowIfNull(_description, nameof(_description));

        var mediation = new Mediation()
        {
            ApplicantId = _applicant.Id,
            DefendantId = _defendant.Id,
            JurisdictionId = _jurisdictionId.Value,
            ScopeId = _scopeId.Value,
            TopologyId = _topologyId,
            Subject = _subject,
            Description = _description,
            PlanId = _plan,
        };
        
        return mediation;
    }
}