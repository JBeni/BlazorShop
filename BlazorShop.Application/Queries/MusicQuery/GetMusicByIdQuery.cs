namespace BlazorShop.Application.Queries.MusicQuery
{
    public class GetMusicByIdQuery : IRequest<Result<MusicResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}
