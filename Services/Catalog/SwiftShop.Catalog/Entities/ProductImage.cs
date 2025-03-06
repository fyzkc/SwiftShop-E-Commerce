namespace SwiftShop.Catalog.Entities
{
    public class ProductImage
    {
        public string ProductImageId { get; set; }
        public List<string> Images { get; set; } // it can be more than one image so we're using a List
        public string ProductId { get; set; }
        public Product Product { get; set; }
        
    }
}
