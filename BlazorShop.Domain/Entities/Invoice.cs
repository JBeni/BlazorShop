namespace BlazorShop.Domain.Entities
{
    public class Invoice
    {
        public string? Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? InvoicePlace { get; set; }
        public string? ProvidedBy { get; set; }
        public string? ProvidedTo { get; set; }
    }
}
