namespace BlazorShop.Application.Queries.RoleQuery
{
    public class GetRoleByIdQuery : IRequest<Result<RoleResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}
