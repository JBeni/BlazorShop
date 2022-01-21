namespace BlazorShop.Domain.Entities
{
    public class Invoice : EntityBase
    {
        public string UserEmail { get; set; }
        public string Name { get; set; }
        public int AmountSubTotal { get; set; }
        public int AmountTotal { get; set; }
        public int Quantity { get; set; }
    }
}
