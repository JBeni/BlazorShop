namespace BlazorShop.Application.Commands.ClotheCommand
{
    public class UpdateClotheCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int Amount { get; set; }
        public string? ImageName { get; set; }
        public string? ImagePath { get; set; }
    }
}
