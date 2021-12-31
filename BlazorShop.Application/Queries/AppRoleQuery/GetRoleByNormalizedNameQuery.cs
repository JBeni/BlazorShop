namespace BlazorShop.Application.Queries.AppRoleQuery
{
    public class GetRoleByNormalizedNameQuery : IRequest<AppRoleResponse>
    {
        public string? NormalizedName { get; set; }
    }
}
