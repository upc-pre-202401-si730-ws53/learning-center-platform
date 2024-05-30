namespace ACME.LearningCenterPlatform.API.Profiles.Domain.Model.ValueObjects;

public record StreetAddress(string Street, string Number, string City, string PostalCode, string Country)
{
    public StreetAddress() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
    {
    }

    public StreetAddress(string street) : this(street, string.Empty, string.Empty, string.Empty,
        string.Empty)
    {
    }

    public StreetAddress(string street, string number, string city) : this(street, number, city,
        string.Empty, string.Empty)
    {
    }

    public StreetAddress(string street, string number, string city, string postalCode) : this(street, number, city, postalCode,
        string.Empty)
    {
    }

    public string FullAddress => $"{Street} {Number}, {City}, {PostalCode}, {Country}";
}