namespace BlazorShop.Application.Commands.AppUserCommand
{
    public class UpdateUserCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
        public string? NewEmail { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Role { get; set; }
    }
}
