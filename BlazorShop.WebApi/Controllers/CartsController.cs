// <copyright file="CartsController.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// Controller for Carts.
    /// </summary>
    [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
    public class CartsController : ApiBaseController
    {
        /// <summary>
        /// Creating the cart.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost("cart")]
        public async Task<IActionResult> CreateCart([FromBody] CreateCartCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Updating the cart.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPut("cart")]
        public async Task<IActionResult> UpdateCart([FromBody] UpdateCartCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Deleting the cart.
        /// </summary>
        /// <param name="id">The id of the cart.</param>
        /// <param name="userId">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpDelete("cart/{id}/{userId}")]
        public async Task<IActionResult> DeleteCart(int id, int userId)
        {
            var result = await this.Mediator.Send(new DeleteCartCommand { Id = id, UserId = userId });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Deleting all the user carts.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpDelete("carts/{userId}")]
        public async Task<IActionResult> DeleteAllCarts(int userId)
        {
            var result = await this.Mediator.Send(new DeleteAllCartsCommand { UserId = userId });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get a cart.
        /// </summary>
        /// <param name="id">The id of the cart.</param>
        /// <param name="userId">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("cart/{id}/{userId}")]
        public async Task<IActionResult> GetCart(int id, int userId)
        {
            var result = await this.Mediator.Send(new GetCartByIdQuery { Id = id, UserId = userId });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get the user carts.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("carts/{userId}")]
        public async Task<IActionResult> GetCarts(int userId)
        {
            var result = await this.Mediator.Send(new GetCartsQuery { UserId = userId });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get the carts number.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("count/{userId}")]
        public async Task<IActionResult> GetCartsCount(int userId)
        {
            var result = await this.Mediator.Send(new GetCartsCountQuery { UserId = userId });
            return this.Ok(result);
        }
    }
}
