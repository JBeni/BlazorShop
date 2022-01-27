namespace BlazorShop.Application.Responses
{
    public class RequestResponse
    {
        public bool Successful { get; set; }
        public Exception? Exception { get; set; }

        public static RequestResponse Success()
        {
            return new RequestResponse { Successful = true, Exception = null };
        }

        public static RequestResponse Error(Exception exception)
        {
            return new RequestResponse { Successful = false, Exception = exception };
        }
    }
}
