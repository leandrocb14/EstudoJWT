using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EstudoJWT.MongoDB.Model
{
    public class Usuario
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}