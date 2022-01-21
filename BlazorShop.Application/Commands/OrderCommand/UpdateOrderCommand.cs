namespace BlazorShop.Application.Commands.OrderCommand
{
    public class UpdateOrderCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public string LineItems { get; set; }
        public int AmountTotal { get; set; }

    }
}
