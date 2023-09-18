// <copyright file="ClaimsController.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// Controller for Claims.
    /// </summary>
    [Authorize(Roles = $"{StringRoleResources.Admin}")]
    public class ClaimsController : ApiBaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimsController"/> class.
        /// </summary>
        /// <param name="mediator">The instance of the <see cref="IMediator"/> to use.</param>
        public ClaimsController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Create a Claim.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpPost("Claim")]
        public async Task<IActionResult> CreateClaim([FromBody] CreateClaimCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Update a Claim.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpPut("Claim")]
        public async Task<IActionResult> UpdateClaim([FromBody] UpdateClaimCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Delete a Claim.
        /// </summary>
        /// <param name="id">The id of the Claim.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpDelete("Claim/{id}")]
        public async Task<IActionResult> DeleteClaim(int id)
        {
            var result = await this.Mediator.Send(new DeleteClaimCommand { Id = id });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get the Claim.
        /// </summary>
        /// <param name="id">The id of the Claim.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("Claim/{id}")]
        public async Task<IActionResult> GetClaimById(int id)
        {
            var result = await this.Mediator.Send(new GetClaimByIdQuery { Id = id });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get the user Claims for a non admin Claim.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("Claims")]
        public async Task<IActionResult> GetClaims()
        {
            var result = await this.Mediator.Send(new GetClaimsQuery { });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }
    }
}
