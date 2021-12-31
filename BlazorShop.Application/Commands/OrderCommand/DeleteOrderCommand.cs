namespace BlazorShop.Application.Commands.OrderCommand
{
    public class DeleteOrderCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }
}
