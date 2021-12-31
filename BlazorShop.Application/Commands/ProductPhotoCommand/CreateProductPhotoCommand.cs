namespace BlazorShop.Application.Commands.ProductPhotoCommand
{
    public class CreateProductPhotoCommand : IRequest<RequestResponse>
    {
        public string? Image { get; set; }
    }
}
