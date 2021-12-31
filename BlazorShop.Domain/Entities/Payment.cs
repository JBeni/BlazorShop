namespace BlazorShop.Domain.Entities
{
    public class Payment : EntityBase
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string? PaymentType { get; set; }
        public string? Provider { get; set; }
        public string? Account_No { get; set; }
        public string? ExpiryDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
