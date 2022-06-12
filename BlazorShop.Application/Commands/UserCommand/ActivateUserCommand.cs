namespace BlazorShop.Application.Commands.UserCommand
{
    public class ActivateUserCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}
