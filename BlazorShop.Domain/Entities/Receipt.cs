namespace BlazorShop.Domain.Entities
{
    public class Receipt : EntityBase
    {
        public DateTime ReceiptDate { get; set; }
        public string ReceiptName { get; set; }
        public string ReceiptUrl { get; set; }
    }
}
