namespace BlazorShop.Domain.Entities
{
    public class ProductPhoto : EntityBase
    {
        public string? RelativePathImage { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
