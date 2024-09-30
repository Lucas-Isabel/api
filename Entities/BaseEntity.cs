using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // Usar string para MongoDB ObjectId

        public DateTime CreatedAt { get; protected set; }
        public bool IsDeleted { get; protected set; }

        public void SetAsDeleted() => IsDeleted = true;
    }
}


