namespace BlazorShop.Application.Commands.CartCommand
{
    public class UpdateCartCommand : IRequest<RequestResponse>
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public int ClotheId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
