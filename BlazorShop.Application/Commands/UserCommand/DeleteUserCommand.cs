namespace BlazorShop.Application.Commands.UserCommand
{
    public class DeleteUserCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}
