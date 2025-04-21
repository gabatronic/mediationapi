
namespace mediation.mediations.Infrastructure.Api.Mediation;

public record CreateMediationRequest(Guid Id, ApplicantDto Applicant, DefendantDto Defendant, Guid PlainId, Guid JurisdictionId, Guid ScopeId, Guid? TopologyId, string Subject, string Description, Guid PlanId);
public record ApplicantDto(Guid Id, string FirstName, string LastName, string Email, string Phone, string Address, string City, string Country, string PostalCode, DateTime DateOfBirth, string BornPlace);
public record DefendantDto(Guid Id, string FirstName, string LastName, string Email, string Phone, string Address, string City, string Country);