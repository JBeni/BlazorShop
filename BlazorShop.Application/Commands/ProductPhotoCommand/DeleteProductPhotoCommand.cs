namespace BlazorShop.Application.Commands.ProductPhotoCommand
{
    public class DeleteProductPhotoCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }
}
