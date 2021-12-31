namespace BlazorShop.Domain.Entities
{
    public class Order : EntityBase
    {
        public string? Description { get; set; }
        public string? ListPrice { get; set; }
        public string? Discount { get; set; }
        public string? SalePrice { get; set; }
        public int Quantity { get; set; }
        public string? Tax { get; set; }
        public string? Total { get; set; }
    }
}
