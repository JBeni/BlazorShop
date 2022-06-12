namespace BlazorShop.Application.Queries.UserQuery
{
    public class GetUserByIdQuery : IRequest<Result<UserResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}
