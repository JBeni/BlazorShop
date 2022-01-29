namespace BlazorShop.WebApi.Controllers
{
    [AllowAnonymous]
    public class HomeController : ApiControllerBase
    {
        static int _callCount;
        
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("test")]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("home")]
        public IActionResult Home()
        {
            return new PhysicalFileResult(Path.Combine(_webHostEnvironment.ContentRootPath, "Views/Home.html"),
                new MediaTypeHeaderValue("text/html").ToString());
        }

        [HttpGet("error")]
        public IActionResult Error()
        {
            return new PhysicalFileResult(Path.Combine(_webHostEnvironment.ContentRootPath, "Views/Error.html"),
                new MediaTypeHeaderValue("text/html").ToString());
        }
    }
}
