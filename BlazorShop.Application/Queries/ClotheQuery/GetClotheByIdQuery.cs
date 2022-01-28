namespace BlazorShop.Application.Queries.ClotheQuery
{
    public class GetClotheByIdQuery : IRequest<Result<ClotheResponse>>
    {
        public int Id { get; set; }
    }
}
