namespace BlazorShop.Application.Commands.CategoryCommand
{
    public class CreateCategoryCommand : IRequest<RequestResponse>
    {
        public string? Name { get; set; }
    }
}
