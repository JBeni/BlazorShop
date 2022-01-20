namespace BlazorShop.Application.Commands.MusicCommand
{
    public class DeleteMusicCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }
}
