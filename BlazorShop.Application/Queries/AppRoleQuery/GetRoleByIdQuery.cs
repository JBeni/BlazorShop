namespace BlazorShop.Application.Queries.AppRoleQuery
{
    public class GetRoleByIdQuery : IRequest<AppRoleResponse>
    {
        public int Id { get; set; }
    }
}
