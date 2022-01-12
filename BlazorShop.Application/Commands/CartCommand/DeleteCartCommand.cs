namespace BlazorShop.Application.Commands.CartCommand
{
    public class DeleteCartCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
