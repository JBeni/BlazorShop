namespace BlazorShop.Application.Queries.ClotheQuery
{
    public class GetClotheByIdQuery : IRequest<ClotheResponse>
    {
        public int Id { get; set; }
    }
}
