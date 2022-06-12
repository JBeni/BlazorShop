namespace BlazorShop.Domain.Entities
{
    public class Order : EntityBase
    {
        /// <summary>
        /// .
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string OrderName { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string LineItems { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int AmountTotal { get; set; }
    }
}
