namespace BlazorShop.Application.Queries.MusicQuery
{
    public class GetMusicByIdQuery : IRequest<MusicResponse>
    {
        public int Id { get; set; }
    }
}
