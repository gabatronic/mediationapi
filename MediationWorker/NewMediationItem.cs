namespace MediationWorker;

public record NewMediationItem(Guid Id, string Email, string FirstName, string LastName, string Subject, string Jurisdiction, string Scope, DateTime Created);