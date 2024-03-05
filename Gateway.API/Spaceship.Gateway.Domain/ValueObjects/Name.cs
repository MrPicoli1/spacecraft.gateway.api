using Flunt.Validations;
using Spaceship.Gateway.Shared.ValueObject;

namespace Spaceship.Gateway.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Name>()
               .Requires()
               .IsGreaterThan(firstName, 3, "Nome deve conter pelo menos 3 Caracteres")
               .IsGreaterThan(lastName, 3, "Sobrenome deve conter pelo menos 3 Caracteres"));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
