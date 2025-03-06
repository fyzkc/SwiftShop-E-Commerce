using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SwiftShop.Catalog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; }

        [BsonIgnore] //with this attribute, these datas will only be available for the code, they won't be added to the database. 
        public Category Category { get; set; }

        //mongodb isn't a relational database. so that, it won't be able to get the Category object with a join process. 
        //CategoryId is already representing the Category object. If Category object will add to the database, it will be unnecessary and repeated data. 
        //to prevent that, we are using BsonIgnore attribute.
    }
}
