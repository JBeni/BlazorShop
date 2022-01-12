namespace BlazorShop.Application.Commands.CartCommand
{
    public class DeleteAllCartsCommand : IRequest<RequestResponse>
    {
        public int UserId { get; set; }
    }
}
