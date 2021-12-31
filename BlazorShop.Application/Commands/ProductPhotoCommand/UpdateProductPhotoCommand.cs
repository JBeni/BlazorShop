namespace BlazorShop.Application.Commands.ProductPhotoCommand
{
    public class UpdateProductPhotoCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
        public string? Image { get; set; }
    }
}
