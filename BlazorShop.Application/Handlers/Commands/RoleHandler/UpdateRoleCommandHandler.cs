// <copyright file="UpdateRoleCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.RoleHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{UpdateRoleCommand, RequestResponse}"/>.
    /// </summary>
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateRoleCommandHandler"/> class.
        /// </summary>
        /// <param name="roleService">Gets An instance of <see cref="IRoleService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{UpdateRoleCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateRoleCommandHandler(IRoleService roleService, ILogger<UpdateRoleCommandHandler> logger)
        {
            this.RoleService = roleService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IRoleService"/>.
        /// </summary>
        private IRoleService RoleService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{UpdateRoleCommandHandler}"/>.
        /// </summary>
        private ILogger<UpdateRoleCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateRoleCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                response = await this.RoleService.UpdateRoleAsync(request);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.UpdateRoleCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateRoleCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
