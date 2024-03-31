using Flunt.Validations;
using Spaceship.Gateway.Shared.ValueObject;

namespace Spaceship.Gateway.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string neigbourhood, string city, string postalCode, string country)
        {
            Street = street;
            Number = number;
            Neigbourhood = neigbourhood;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neigbourhood { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }
    }
}
