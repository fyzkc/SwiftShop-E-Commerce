using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SwiftShop.Catalog.Entities
{
    public class ProductImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductImageId { get; set; }
        public List<string> Images { get; set; } // it can be more than one image so we're using a List
        public string ProductId { get; set; }

        [BsonIgnore]
        public Product Product { get; set; }
        
    }
}
