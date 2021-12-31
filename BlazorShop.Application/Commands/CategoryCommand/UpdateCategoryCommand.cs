namespace BlazorShop.Application.Commands.CategoryCommand
{
    public class UpdateCategoryCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
