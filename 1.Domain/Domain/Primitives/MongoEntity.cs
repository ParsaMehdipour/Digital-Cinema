using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Primitives;
public class MongoEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
