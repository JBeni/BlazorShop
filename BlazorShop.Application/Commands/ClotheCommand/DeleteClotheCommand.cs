namespace BlazorShop.Application.Commands.ClotheCommand
{
    public class DeleteClotheCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}
