// <copyright file="ApiControllerBase.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// Controller for setting the this.Mediator.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public abstract class ApiControllerBase : ControllerBase
    {
        /// <summary>
        /// Gets the instance of the <see cref="ISender"/> to use.
        /// </summary>
        private ISender mediator = null!;

        /// <summary>
        /// Gets the instance of the <see cref="ISender"/> to use.
        /// </summary>
        protected ISender Mediator => this.mediator ??= this.HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
