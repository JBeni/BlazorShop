namespace BlazorShop.Application.Queries.UserQuery
{
    public class GetUserByEmailQuery : IRequest<Result<UserResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public string? Email { get; set; }
    }
}
