namespace BlazorShop.Domain.Entities
{
    public class Color : EntityBase
    {
        public string? Name { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
