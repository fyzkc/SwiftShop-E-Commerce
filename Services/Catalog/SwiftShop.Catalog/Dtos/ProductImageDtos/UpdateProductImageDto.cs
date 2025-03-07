namespace SwiftShop.Catalog.Dtos.ProductImageDtos
{
    public class UpdateProductImageDto
    {
        public string ProductImageId { get; set; }
        public List<string> Images { get; set; }
        public string ProductId { get; set; }
    }
}
