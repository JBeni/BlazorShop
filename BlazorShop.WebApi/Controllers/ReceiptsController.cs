// <copyright file="ReceiptsController.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// Controller for Receipts.
    /// </summary>
    public class ReceiptsController : ApiBaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptsController"/> class.
        /// </summary>
        /// <param name="mediator">The instance of the <see cref="IMediator"/> to use.</param>
        public ReceiptsController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Create a receipt.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpPost("receipt")]
        public async Task<IActionResult> CreateReceipt([FromBody] CreateReceiptCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Update a receipt.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpPut("receipt")]
        public async Task<IActionResult> UpdateReceipt([FromBody] UpdateReceiptCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Delete a receipt.
        /// </summary>
        /// <param name="id">The id of the receipt.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpDelete("receipt/{id}")]
        public async Task<IActionResult> DeleteReceipt(int id)
        {
            var result = await this.Mediator.Send(new DeleteReceiptCommand { Id = id });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get a receipt.
        /// </summary>
        /// <param name="id">The id of the receipt.</param>
        /// <param name="userEmail">The email of the user.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("receipt/{id}/{userEmail}")]
        public async Task<IActionResult> GetReceipt(int id, string userEmail)
        {
            var result = await this.Mediator.Send(new GetReceiptByIdQuery { Id = id, UserEmail = userEmail });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get the receipts.
        /// </summary>
        /// <param name="userEmail">The email of the user.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("receipts/{userEmail}")]
        public async Task<IActionResult> GetReceipts(string userEmail)
        {
            var result = await this.Mediator.Send(new GetReceiptsQuery { UserEmail = userEmail });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }
    }
}
