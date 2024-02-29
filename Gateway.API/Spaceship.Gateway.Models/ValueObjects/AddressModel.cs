using Spaceship.Gateway.Shared.ValueObject;

namespace Spaceship.Gateway.Models.ValueObjects
{
    public class AddressModel : ValueObject
    {
        public AddressModel(string street, string number, string neigbourhood, string city, string postalCode, string country)
        {
            Street = street;
            Number = number;
            Neigbourhood = neigbourhood;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }

        public string Street { get;  set; }
        public string Number { get;  set; }
        public string Neigbourhood { get;  set; }
        public string City { get;  set; }
        public string PostalCode { get;  set; }
        public string Country { get;  set; }
    }
}
