namespace ACME.LearningCenterPlatform.API.Profiles.Interfaces.REST.Resources;

public record CreateProfileResource(string FirstName, string LastName, string Email, string Street, string Number, string City, string PostalCode, string Country);