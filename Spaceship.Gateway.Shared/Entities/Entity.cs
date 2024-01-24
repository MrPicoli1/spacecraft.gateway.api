using Flunt.Notifications;

namespace Spaceship.Gateway.Shared.Entities
{
    public abstract class Entity : Notifiable<Notification>
    {

      public Entity() 
        { 
            Guid = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            Deleted = false;
        }


        public Guid Guid { get; private set; }

        public DateTime CreatedDate { get; private set; }
        public DateTime? DeletedDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }
        public bool Deleted { get; private set; }

        public void Updated()
        {
            UpdatedDate = DateTime.Now;
        }

    }
}
