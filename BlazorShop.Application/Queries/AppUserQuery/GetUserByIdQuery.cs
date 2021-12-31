namespace BlazorShop.Application.Queries.AppUserQuery
{
    public class GetUserByIdQuery : IRequest<AppUserResponse>
    {
        public int Id { get; set; }
    }
}
