namespace mediation.mediations.Infrastructure.Api.Mediation.Update;
public record UpdateMediationRequest(Guid Id, ApplicantDto Applicant, DefendantDto Defendant, Guid PlainId, Guid JurisdictionId, Guid ScopeId, Guid? TopologyId, string Subject, string Description, Guid PlaGuid);
