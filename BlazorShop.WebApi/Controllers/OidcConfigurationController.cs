// <copyright file="OidcConfigurationController.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// A controler for open oid configurations.
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class OidcConfigurationController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OidcConfigurationController"/> class.
        /// </summary>
        /// <param name="clientRequestParametersProvider">The instance of the <see cref="IClientRequestParametersProvider"/>.</param>
        /// <param name="logger">The instance of the <see cref="ILogger{OidcConfigurationController}"/>.</param>
        public OidcConfigurationController(
            IClientRequestParametersProvider clientRequestParametersProvider,
            ILogger<OidcConfigurationController> logger)
        {
            this.ClientRequestParametersProvider = clientRequestParametersProvider;
            this.Logger = logger;
        }

        /// <summary>
        /// Gets the instance of the <see cref="IClientRequestParametersProvider"/>.
        /// </summary>
        public IClientRequestParametersProvider ClientRequestParametersProvider { get; }

        /// <summary>
        /// Gets the instance of the <see cref="ILogger{OidcConfigurationController}"/>.
        /// </summary>
        private ILogger<OidcConfigurationController> Logger { get; }

        /// <summary>
        /// Get client request configuration.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("_configuration/{clientId}")]
        public IActionResult GetClientRequestParameters([FromRoute] string clientId)
        {
            var parameters = this.ClientRequestParametersProvider.GetClientParameters(this.HttpContext, clientId);
            return this.Ok(parameters);
        }
    }
}
