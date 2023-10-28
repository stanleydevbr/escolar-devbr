using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DevBr.Core.Mongo.Documents
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }
        DateTime DataCriacao { get; }
    }
}
