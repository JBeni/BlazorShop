namespace BlazorShop.Application.Commands.CartCommand
{
    public class DeleteAllCartsCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int UserId { get; set; }
    }
}
