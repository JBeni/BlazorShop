namespace BlazorShop.WebClient.Error
{
    public class ErrorView
    {
        public int Status { get; set; }
        public string? Title { get; set; }
        public string? Detail { get; set; }
        public string? Type { get; set; }

        public bool Successful { get; set; }
        public string? Error { get; set; }
    }
}
