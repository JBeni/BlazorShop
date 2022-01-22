namespace BlazorShop.Domain.Entities
{
    public class Order : EntityBase
    {
        public string UserEmail { get; set; }
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }
        public string LineItems { get; set; }
        public int AmountTotal { get; set; }
    }
}
