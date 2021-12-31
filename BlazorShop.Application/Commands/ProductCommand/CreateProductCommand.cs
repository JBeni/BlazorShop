namespace BlazorShop.Application.Commands.ProductCommand
{
    public class CreateProductCommand : IRequest<RequestResponse>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
