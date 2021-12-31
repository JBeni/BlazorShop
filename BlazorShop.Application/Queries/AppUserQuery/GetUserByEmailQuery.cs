namespace BlazorShop.Application.Queries.AppUserQuery
{
    public class GetUserByEmailQuery : IRequest<AppUserResponse>
    {
        public string? Email { get; set; }
    }
}
