namespace BlazorShop.Domain.Entities
{
    public class Clothe : EntityBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int Amount { get; set; }
        public string? ImageName { get; set; }
        public string? ImagePath { get; set; }
        public bool? IsActive { get; set; }
    }
}
