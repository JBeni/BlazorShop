// <copyright file="HomeController.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// Controller for Home.
    /// </summary>
    [AllowAnonymous]
    public class HomeController : ApiControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("test")]
        public IActionResult Index()
        {
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("home")]
        public IActionResult Home()
        {
            return new PhysicalFileResult(Path.Combine(_webHostEnvironment.ContentRootPath, "Views/Home.html"),
                new MediaTypeHeaderValue("text/html").ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("error")]
        public IActionResult Error()
        {
            return new PhysicalFileResult(Path.Combine(_webHostEnvironment.ContentRootPath, "Views/Error.html"),
                new MediaTypeHeaderValue("text/html").ToString());
        }
    }
}
