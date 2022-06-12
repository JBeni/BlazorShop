namespace BlazorShop.Application.Queries.ClotheQuery
{
    public class GetClotheByIdQuery : IRequest<Result<ClotheResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}
