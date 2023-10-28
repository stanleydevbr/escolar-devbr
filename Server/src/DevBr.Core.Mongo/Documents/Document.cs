using MongoDB.Bson;

namespace DevBr.Core.Mongo.Documents
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }
        public DateTime DataCriacao => Id.CreationTime;
    }
}
