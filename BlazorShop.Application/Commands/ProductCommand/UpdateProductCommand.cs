namespace BlazorShop.Application.Commands.ProductCommand
{
    public class UpdateProductCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
