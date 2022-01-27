namespace BlazorShop.Application.Common.Models
{
    public class RequestResponse
    {
        public bool Successful { get; set; }
        public string? Error { get; set; }
        public int EntityId { get; set; }

        public static RequestResponse Success(int id = 0)
        {
            return new RequestResponse { Successful = true, EntityId = id, Error = null };
        }

        public static RequestResponse Failure(string error, int id = 0)
        {
            return new RequestResponse { Successful = false, EntityId = id, Error = error };
        }
    }
}
