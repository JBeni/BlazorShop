namespace BlazorShop.Application.Commands.ClotheCommand
{
    public class DeleteClotheCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }
}
