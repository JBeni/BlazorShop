namespace BlazorShop.Application.Queries.MusicQuery
{
    public class GetMusicByIdQuery : IRequest<Result<MusicResponse>>
    {
        public int Id { get; set; }
    }
}
