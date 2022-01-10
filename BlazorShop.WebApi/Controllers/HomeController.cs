namespace BlazorShop.WebApi.Controllers
{
    public class HomeController : ApiControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("home")]
        public IActionResult Home()
        {
            return Ok("Index pahe working");
            //return new PhysicalFileResult(Path.Combine(_webHostEnvironment.ContentRootPath, "Views/Home.html"),
            //    new MediaTypeHeaderValue("text/html").ToString());
        }

        [HttpGet("error")]
        public IActionResult Error()
        {
            return Ok("Index pahe working");
        }
    }
}
