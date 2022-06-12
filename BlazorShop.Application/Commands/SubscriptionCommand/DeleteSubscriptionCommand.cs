namespace BlazorShop.Application.Commands.SubscriptionCommand
{
    public class DeleteSubscriptionCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
		public int Id { get; set; }
	}
}
