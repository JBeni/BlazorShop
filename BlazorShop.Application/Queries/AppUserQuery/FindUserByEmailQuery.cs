namespace BlazorShop.Application.Queries.AppUserQuery
{
    public class FindUserByEmailQuery : IRequest<AppUser>
    {
        public string? Email { get; set; }
    }
}
