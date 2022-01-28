namespace BlazorShop.Application.Queries.UserQuery
{
    public class GetUserByEmailQuery : IRequest<Result<UserResponse>>
    {
        public string? Email { get; set; }
    }
}
