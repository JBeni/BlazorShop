// <copyright file="InvoicesController.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// Controller for Invoices.
    /// </summary>
    [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
    public class InvoicesController : ApiBaseController
    {
        /// <summary>
        /// Create the invoice.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost("invoice")]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Update the invoice.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPut("invoice")]
        public async Task<IActionResult> UpdateInvoice([FromBody] UpdateInvoiceCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Delete the invoice.
        /// </summary>
        /// <param name="id">The id of the invoice.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpDelete("invoice/{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var result = await this.Mediator.Send(new DeleteInvoiceCommand { Id = id });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get the invoice.
        /// </summary>
        /// <param name="id">The id of the invoice.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("invoice/{id}")]
        public async Task<IActionResult> GetInvoice(int id)
        {
            var result = await this.Mediator.Send(new GetInvoiceByIdQuery { Id = id });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get the invoices.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("invoices")]
        public async Task<IActionResult> GetInvoices()
        {
            var result = await this.Mediator.Send(new GetInvoicesQuery { });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }
    }
}
