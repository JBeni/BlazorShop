namespace BlazorShop.Domain.Entities
{
    public class Cart : EntityBase
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        public Clothe? Clothe { get; set; }
        public User? User { get; set; }
    }
}
