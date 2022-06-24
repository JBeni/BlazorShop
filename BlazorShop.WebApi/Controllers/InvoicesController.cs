// <copyright file="InvoicesController.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
    public class InvoicesController : ApiControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("invoice")]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("invoice")]
        public async Task<IActionResult> UpdateInvoice([FromBody] UpdateInvoiceCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("invoice/{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var result = await Mediator.Send(new DeleteInvoiceCommand { Id = id });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("invoice/{id}")]
        public async Task<IActionResult> GetInvoice(int id)
        {
            var result = await Mediator.Send(new GetInvoiceByIdQuery { Id = id });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("invoices")]
        public async Task<IActionResult> GetInvoices()
        {
            var result = await Mediator.Send(new GetInvoicesQuery { });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }
    }
}
