// <copyright file="UsersController.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// Controller for Users.
    /// </summary>
    public class UsersController : ApiBaseController
    {
        /// <summary>
        /// Create the user.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpPost("user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Activate the user.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpPost("userActivate")]
        public async Task<IActionResult> ActivateUser([FromBody] ActivateUserCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Update the user.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}, {StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpPut("user")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Update the user email.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpPut("userEmail")]
        public async Task<IActionResult> UpdateUserEmail([FromBody] UpdateUserEmailCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Delete the user.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpDelete("user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await this.Mediator.Send(new DeleteUserCommand { Id = id });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get user.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}, {StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await this.Mediator.Send(new GetUserByIdQuery { Id = id });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get active users.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await this.Mediator.Send(new GetUsersQuery { });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get inactive users.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpGet("usersInactive")]
        public async Task<IActionResult> GetUsersInactive()
        {
            var result = await this.Mediator.Send(new GetUsersInactiveQuery { });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }
    }
}
