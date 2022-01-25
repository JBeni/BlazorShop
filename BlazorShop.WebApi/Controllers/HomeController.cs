namespace BlazorShop.WebApi.Controllers
{
    [AllowAnonymous]
    public class HomeController : ApiControllerBase
    {
        static int _callCount;
        
        private readonly IWebHostEnvironment _webHostEnvironment;
        readonly ILogger<HomeController> _logger;
        readonly IDiagnosticContext _diagnosticContext;

        public HomeController(IWebHostEnvironment webHostEnvironment,
                              ILogger<HomeController> logger,
                              IDiagnosticContext diagnosticContext)
        {
            _webHostEnvironment = webHostEnvironment;

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _diagnosticContext = diagnosticContext ?? throw new ArgumentNullException(nameof(diagnosticContext));
        }

        [HttpGet("test")]
        public IActionResult Index()
        {
            _logger.LogInformation("Hello, world!");
            _diagnosticContext.Set("IndexCallCount", Interlocked.Increment(ref _callCount));

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
