namespace BlazorShop.Application.Queries.UserQuery
{
    public class GetUserByIdQuery : IRequest<UserResponse>
    {
        public int Id { get; set; }
    }
}
