namespace BlazorShop.Application.Commands.SubscriberCommand
{
    public class DeleteSubscriberCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
		public int Id { get; set; }
	}
}
