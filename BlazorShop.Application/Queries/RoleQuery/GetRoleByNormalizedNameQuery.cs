namespace BlazorShop.Application.Queries.RoleQuery
{
    public class GetRoleByNormalizedNameQuery : IRequest<Result<RoleResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public string? NormalizedName { get; set; }
    }
}
