namespace BlazorShop.Application.Commands.CategoryCommand
{
    public class DeleteCategoryCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }
}
