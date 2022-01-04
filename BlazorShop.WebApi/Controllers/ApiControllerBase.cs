namespace BlazorShop.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [AllowAnonymous]
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly ISender? _mediator;

        protected ISender Mediator => _mediator ?? HttpContext.RequestServices.GetService<ISender>();
    }
}
