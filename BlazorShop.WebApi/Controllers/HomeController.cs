namespace BlazorShop.WebApi.Controllers
{
    public class HomeController : ApiBaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("home-page")]
        public IActionResult Home()
        {
            return new PhysicalFileResult(Path.Combine(_webHostEnvironment.ContentRootPath, "Views/Home.html"),
                new MediaTypeHeaderValue("text/html").ToString());
        }

        [HttpGet("error-page")]
        public IActionResult Error()
        {
            return new PhysicalFileResult(Path.Combine(_webHostEnvironment.ContentRootPath, "Views/Error.html"),
                new MediaTypeHeaderValue("text/html").ToString());
        }
    }
}
