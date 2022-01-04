namespace BlazorShop.Domain.Entities
{
    public class Product : EntityBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
