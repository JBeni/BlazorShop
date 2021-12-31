namespace BlazorShop.Application.Commands.ProductCommand
{
    public class DeleteProductCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }
}
