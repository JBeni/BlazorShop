namespace BlazorShop.Application.Queries.AppUserQuery
{
    public class FindUserByIdQuery : IRequest<AppUser>
    {
        public int Id { get; set; }
    }
}
