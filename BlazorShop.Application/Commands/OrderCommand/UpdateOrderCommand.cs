namespace BlazorShop.Application.Commands.OrderCommand
{
    public class UpdateOrderCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? ShippingAddress { get; set; }
        public string? SupplierName { get; set; }
        public string? BuyerName { get; set; }
        public int Quantity { get; set; }
    }
}
