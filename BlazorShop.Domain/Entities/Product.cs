namespace BlazorShop.Domain.Entities
{
    public class Product : EntityBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public int BrandId { get; set; }
        public Brand? Brand { get; set; }

        public virtual ICollection<ProductPhoto>? ProductPhotos { get; set; }
        public virtual ICollection<Color>? Colors { get; set; }
        public virtual ICollection<Size>? Sizes { get; set; }
    }
}
