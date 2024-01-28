using MongoDB.Bson.Serialization.Attributes;
using System.Globalization;

namespace AccountService.Data.Entities
{
    public class Player
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string FirstName { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string LastName { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Username { get; set; } = null!;



    }   
}
