namespace BlazorShop.Domain.Entities
{
    public class Music : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime DateRelease { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
    }
}
