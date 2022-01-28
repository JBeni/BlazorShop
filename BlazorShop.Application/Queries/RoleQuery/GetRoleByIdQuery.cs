namespace BlazorShop.Application.Queries.RoleQuery
{
    public class GetRoleByIdQuery : IRequest<Result<RoleResponse>>
    {
        public int Id { get; set; }
    }
}
