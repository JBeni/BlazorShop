namespace BlazorShop.Application.Commands.UserCommand
{
    public class CreateUserCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Role { get; set; }
    }
}
