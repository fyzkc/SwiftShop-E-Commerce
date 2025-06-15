using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SwiftShop.Catalog.Entities
{
    public class BrandCampaign
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BrandCampaignId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
