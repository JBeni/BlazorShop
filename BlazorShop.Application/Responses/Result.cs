namespace BlazorShop.Application.Responses
{
    public class Result<T> where T : class
    {
        public bool Successful { get; set; }
        public List<string>? Errors { get; set; }

        public T Item { get; set; }
        public List<T> Items { get; set; }


        //public Exception? Exception { get; set; }

        //public static RequestResponse<T> Success()
        //{
        //    return new RequestResponse<T> { Successful = true, Exception = null };
        //}

        //public static RequestResponse<T> Error(Exception exception)
        //{
        //    Errors.Add(exception.Message);
        //    Errors.Add(exception.InnerException.Message);
        //    return new RequestResponse<T> { Successful = false, Exception = exception };
        //}
    }
}
