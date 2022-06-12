namespace BlazorShop.Application.Commands.ClotheCommand
{
    public class UpdateClotheCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? ImageName { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? ImagePath { get; set; }
    }
}
