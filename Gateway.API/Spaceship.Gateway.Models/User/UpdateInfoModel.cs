using Spaceship.Gateway.Models.ValueObjects;

namespace Spaceship.Gateway.Models.User
{
    public class UpdateInfoModel
    {
        public UpdateInfoModel(Guid id, AddressModel address, NameModel name)
        {
            Id = id;
            Address = address;
            Name = name;


        }

        public Guid Id { get; set; }
        public AddressModel Address { get; set; }
        public NameModel Name { get; set; }
    }
}
