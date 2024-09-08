// <copyright file="CartsController.cs" company="Beniamin Jitca">
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
        /// Initializes a new instance of the <see cref="CartsController"/> class.
        /// </summary>
        /// <param name="mediator">The instance of the <see cref="IMediator"/> to use.</param>
        public CartsController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Creating the cart.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [ProducesResponseType(typeof(RequestResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost(ApiEndpoints.Carts.Create)]
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
        /// <param name="id">The cart id.</param>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [ProducesResponseType(typeof(RequestResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut(ApiEndpoints.Carts.Update)]
        public async Task<IActionResult> UpdateCart(int id, [FromBody] UpdateCartCommand command)
        {
            command.UserId = id;
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
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [ProducesResponseType(typeof(RequestResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete(ApiEndpoints.Carts.Delete)]
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
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [ProducesResponseType(typeof(RequestResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete(ApiEndpoints.Carts.DeleteAll)]
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
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [ProducesResponseType(typeof(Result<CartResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet(ApiEndpoints.Carts.GetCart)]
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
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [ProducesResponseType(typeof(Result<CartResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet(ApiEndpoints.Carts.GetUserCarts)]
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
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet(ApiEndpoints.Carts.GetUserCartCount)]
        public async Task<IActionResult> GetCartsCount(int userId)
        {
            var result = await this.Mediator.Send(new GetCartsCountQuery { UserId = userId });
            return this.Ok(result);
        }
    }
}
