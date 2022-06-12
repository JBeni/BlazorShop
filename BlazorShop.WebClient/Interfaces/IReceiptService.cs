namespace BlazorShop.WebClient.Interfaces
{
    public interface IReceiptService
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<List<ReceiptResponse>> GetReceipts(string userEmail);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<ReceiptResponse> GetReceipt(int id, string userEmail);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<RequestResponse> AddReceipt(ReceiptResponse Receipt);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<RequestResponse> UpdateReceipt(ReceiptResponse Receipt);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<RequestResponse> DeleteReceipt(int id);
    }
}
