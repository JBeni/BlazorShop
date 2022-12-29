// <copyright file="ReceiptsController.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// Controller for Receipts.
    /// </summary>
    public class ReceiptsController : ApiControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpPost("receipt")]
        public async Task<IActionResult> CreateReceipt([FromBody] CreateReceiptCommand command)
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
        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpPut("receipt")]
        public async Task<IActionResult> UpdateReceipt([FromBody] UpdateReceiptCommand command)
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
        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpDelete("receipt/{id}")]
        public async Task<IActionResult> DeleteReceipt(int id)
        {
            var result = await Mediator.Send(new DeleteReceiptCommand { Id = id });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("receipt/{id}/{userEmail}")]
        public async Task<IActionResult> GetReceipt(int id, string userEmail)
        {
            var result = await Mediator.Send(new GetReceiptByIdQuery { Id = id, UserEmail = userEmail });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("receipts/{userEmail}")]
        public async Task<IActionResult> GetReceipts(string userEmail)
        {
            var result = await Mediator.Send(new GetReceiptsQuery { UserEmail = userEmail });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }
    }
}
