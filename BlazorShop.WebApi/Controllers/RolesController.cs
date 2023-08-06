// <copyright file="RolesController.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// Controller for Roles.
    /// </summary>
    [Authorize(Roles = $"{StringRoleResources.Admin}")]
    public class RolesController : ApiBaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RolesController"/> class.
        /// </summary>
        /// <param name="mediator">The instance of the <see cref="IMediator"/> to use.</param>
        public RolesController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Create a role.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpPost("role")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Update a role.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpPut("role")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Delete a role.
        /// </summary>
        /// <param name="id">The id of the role.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpDelete("role/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await this.Mediator.Send(new DeleteRoleCommand { Id = id });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get the role.
        /// </summary>
        /// <param name="id">The id of the role.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("role/{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var result = await this.Mediator.Send(new GetRoleByIdQuery { Id = id });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get the user roles for a non admin role.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            var result = await this.Mediator.Send(new GetRolesQuery { });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get the roles for an admin user.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("rolesAdmin")]
        public async Task<IActionResult> GetRolesForAdmin()
        {
            var result = await this.Mediator.Send(new GetRolesForAdminQuery { });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }
    }
}
