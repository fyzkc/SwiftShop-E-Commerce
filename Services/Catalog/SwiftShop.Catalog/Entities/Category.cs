using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SwiftShop.Catalog.Entities
{
    public class Category
    {
        /* 
        in mongodb, every document has aligned an id automatically. 
        in .NET environment, to define which property is the equivalent of this mongodb id field, we'll use BsonId attribute.
        if that attribute won't be used, then mongodb will accept the properties for identity value which has Id or _id names. 
        
        in centralized database management systems, id's were defining as an integer. But in distributed db systems, defining the id's as an integer
        may cause problems. Cause integer id's are starting from 1 and increasing 1 for every data. 
        But if you use this kind of id in a distributed db system, it will be difficult to senchronize this id pattern. 
        the id's must be uniqe in the global. 

        Because of that, mongodb uses ObjectId type for id's. For making the id's compatible in the .NET environment, we'll use string type for id's.
        Cause converting the string type to ObjectId type is more easy than converting them from integer type. 
        So that, we are using string type for defining the id's. 

        The BsonRepresentation(BsonType.ObjectId) attribute, allow us the id field in the mongodb which is ObjectId type, to use as a string in our C# environment. 
         */
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
