namespace mediation.mediations.Domain;

public class Applicant
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string Country { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required string BornPlace { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public required string Address { get; set; }
}