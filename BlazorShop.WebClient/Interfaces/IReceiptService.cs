namespace BlazorShop.WebClient.Interfaces
{
    public interface IReceiptService
    {
        Task<List<ReceiptResponse>> GetReceipts(string userEmail);
        Task<ReceiptResponse> GetReceipt(int id, string userEmail);
        Task<RequestResponse> AddReceipt(ReceiptResponse Receipt);
        Task<RequestResponse> UpdateReceipt(ReceiptResponse Receipt);
        Task<RequestResponse> DeleteReceipt(int id);
    }
}
