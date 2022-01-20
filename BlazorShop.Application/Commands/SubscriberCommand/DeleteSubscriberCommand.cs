namespace BlazorShop.Application.Commands.SubscriberCommand
{
    public class DeleteSubscriberCommand : IRequest<RequestResponse>
    {
		public int Id { get; set; }
	}
}
