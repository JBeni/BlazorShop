namespace BlazorShop.Application.Commands.UserCommand
{
    public class UpdateUserCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Role { get; set; }
    }
}
