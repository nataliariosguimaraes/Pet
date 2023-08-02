using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace API.PET.Dominio.Entidades
{
    public class Pet
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();


        [BsonElement("CodigoPet")]
        [BsonRepresentation(BsonType.Int32)]
        public int CodigoPet { get; set; }

        [BsonElement("nome")]
        [BsonRepresentation(BsonType.String)]
        public string? Nome { get; set; }

    }
}
