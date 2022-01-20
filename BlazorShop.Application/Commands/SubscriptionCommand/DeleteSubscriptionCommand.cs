namespace BlazorShop.Application.Commands.SubscriptionCommand
{
    public class DeleteSubscriptionCommand : IRequest<RequestResponse>
    {
		public int Id { get; set; }
	}
}
