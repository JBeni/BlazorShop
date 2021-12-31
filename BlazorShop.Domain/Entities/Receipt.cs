namespace BlazorShop.Domain.Entities
{
    public class Receipt : EntityBase
    {
        public Order? Order { get; set; }

        public DateTime OrderDate { get; set; }
        public string? VendorName { get; set; }
        public string? VendorAddress { get; set; }

        public string? BuyerName { get; set; }
        public string? BuyerAddress { get; set; }

        public decimal Total { get; set; }
        public decimal Refunded { get; set; }
        public decimal TotalPaid { get; set; }
    }
}
