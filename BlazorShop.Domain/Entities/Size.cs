namespace BlazorShop.Domain.Entities
{
    public class Size : EntityBase
    {
        public string? Name { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
