// <copyright file="ApiBaseController.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// Controller for setting the Mediator.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public abstract class ApiBaseController : ControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiBaseController"/> class.
        /// </summary>
        /// <param name="mediator">The instance of the <see cref="IMediator"/> to use.</param>
        public ApiBaseController(IMediator mediator)
        {
            this.Mediator = mediator;
        }

        /// <summary>
        /// Gets the instance of the <see cref="IMediator"/> to use.
        /// </summary>
        protected IMediator Mediator { get; }
    }
}
