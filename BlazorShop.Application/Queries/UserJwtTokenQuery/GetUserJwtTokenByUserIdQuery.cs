namespace BlazorShop.Application.Queries.UserJwtTokenQuery
{
    public class GetUserJwtTokenByUserIdQuery : IRequest<UserJwtTokenResponse>
    {
        public int UserId { get; set; }
    }
}
