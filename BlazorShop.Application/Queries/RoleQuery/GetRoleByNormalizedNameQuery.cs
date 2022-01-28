namespace BlazorShop.Application.Queries.RoleQuery
{
    public class GetRoleByNormalizedNameQuery : IRequest<Result<RoleResponse>>
    {
        public string? NormalizedName { get; set; }
    }
}
