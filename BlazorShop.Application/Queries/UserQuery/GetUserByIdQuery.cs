namespace BlazorShop.Application.Queries.UserQuery
{
    public class GetUserByIdQuery : IRequest<Result<UserResponse>>
    {
        public int Id { get; set; }
    }
}
