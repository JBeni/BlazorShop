namespace BlazorShop.Application.Commands.OrderCommand
{
    public class DeleteOrderCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}
