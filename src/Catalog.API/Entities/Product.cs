using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    public class Product
    {
        public Product()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // to convert string to ObjectId
        public string Id { get; set; }

        [BsonElement("Name")] // to change the name of the property in the database
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}
