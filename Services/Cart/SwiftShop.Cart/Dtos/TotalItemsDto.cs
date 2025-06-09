namespace SwiftShop.Cart.Dtos
{
    public class TotalItemsDto
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public int? DiscountRate { get; set; }
        public List<ItemDto> Items { get; set; }
        public decimal TotalPriceWithoutDiscount => Items.Sum(x => x.Price * x.Quantity); //the price when the DiscountRate is null
        public decimal TotalPriceWithDiscount => TotalPriceWithoutDiscount * (1 - (DiscountRate.GetValueOrDefault() / 100m));  //the price when the DiscountRate has applied.


    }
}
