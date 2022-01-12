namespace BlazorShop.Application.Queries.RoleQuery
{
    public class GetRoleByIdQuery : IRequest<RoleResponse>
    {
        public int Id { get; set; }
    }
}
