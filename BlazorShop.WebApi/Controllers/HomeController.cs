// <copyright file="HomeController.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// Controller for Home.
    /// </summary>
    [AllowAnonymous]
    public class HomeController : ApiBaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="webHostEnvironment">The instance of the <see cref="IWebHostEnvironment"/> to use.</param>
        /// <param name="mediator">The instance of the <see cref="IMediator"/> to use.</param>
        public HomeController(IWebHostEnvironment webHostEnvironment, IMediator mediator)
            : base(mediator)
        {
            this.WebHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Gets the instance of the <see cref="IWebHostEnvironment"/> to use.
        /// </summary>
        private IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary>
        /// A test request.
        /// </summary>
        /// <returns>An empty result.</returns>
        [HttpGet("test")]
        public IActionResult Index()
        {
            return this.Ok();
        }

        /// <summary>
        /// Get the home page from server.
        /// </summary>
        /// <returns>A default html page.</returns>
        [HttpGet("home")]
        public IActionResult Home()
        {
            return new PhysicalFileResult(
                Path.Combine(this.WebHostEnvironment.ContentRootPath, "Views/Home.html"),
                new MediaTypeHeaderValue("text/html").ToString());
        }

        /// <summary>
        /// Get the error page from server.
        /// </summary>
        /// <returns>A default error page.</returns>
        [HttpGet("error")]
        public IActionResult Error()
        {
            return new PhysicalFileResult(
                Path.Combine(this.WebHostEnvironment.ContentRootPath, "Views/Error.html"),
                new MediaTypeHeaderValue("text/html").ToString());
        }
    }
}
