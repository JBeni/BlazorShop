namespace BlazorShop.Application.Common.Models
{
    public class Result<T> where T : class
    {
        public bool Successful { get; set; } = false;
        public List<string>? Errors { get; set; } = null;
        public T? Item { get; set; } = null;
        public List<T>? Items { get; set; } = null;
    }
}
