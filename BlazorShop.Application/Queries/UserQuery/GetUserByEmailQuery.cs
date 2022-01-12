namespace BlazorShop.Application.Queries.UserQuery
{
    public class GetUserByEmailQuery : IRequest<UserResponse>
    {
        public string? Email { get; set; }
    }
}
