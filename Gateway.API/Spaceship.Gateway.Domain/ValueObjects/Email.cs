
using Spaceship.Gateway.Shared.ValueObject;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;


namespace Spaceship.Gateway.Domain.ValueObjects
{
    public partial class Email : ValueObject
    {
        private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; private set; }

        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();

        public bool IsValid()
        {
            if (!EmailRegex().IsMatch(Address))
                return false;
            return true;
        }

    }
}
