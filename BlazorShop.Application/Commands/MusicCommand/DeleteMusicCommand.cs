namespace BlazorShop.Application.Commands.MusicCommand
{
    public class DeleteMusicCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}
