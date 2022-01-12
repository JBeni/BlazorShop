namespace BlazorShop.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    //[AllowAnonymous]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator = null!;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
