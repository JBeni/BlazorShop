namespace BlazorShop.Domain.Entities
{
    public class ReceiptProduct : EntityBase
    {
        public string? Item { get; set; }
        public DateTime Ordered { get; set; }
        public string? CouponCodes { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
    }
}
