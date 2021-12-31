namespace BlazorShop.Domain.Entities
{
    public class Brand : EntityBase
    {
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
