namespace BlazorShop.Application.Queries.RoleQuery
{
    public class GetRoleByNormalizedNameQuery : IRequest<RoleResponse>
    {
        public string? NormalizedName { get; set; }
    }
}
