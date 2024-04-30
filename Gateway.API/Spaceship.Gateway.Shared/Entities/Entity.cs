using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Spaceship.Gateway.Shared.Entities
{
    public abstract class Entity
    {

        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            Deleted = false;
        }
        [BsonId]
        [BsonElement("_id")]
        public Guid Id { get; private set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedDate { get; private set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? DeletedDate { get; private set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedDate { get; private set; }
        [BsonDefaultValue(false)]
        public bool Deleted { get; private set; }

        public void Updated()
        {
            UpdatedDate = DateTime.Now;
        }

        public void Delete()
        {
            Deleted = true;
            DeletedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

    }
}
