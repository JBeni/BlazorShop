// <copyright file="DeleteRoleCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.RoleHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{DeleteRoleCommand, RequestResponse}"/>.
    /// </summary>
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteRoleCommandHandler"/> class.
        /// </summary>
        /// <param name="roleService">Gets An instance of <see cref="IRoleService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{DeleteRoleCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public DeleteRoleCommandHandler(IRoleService roleService, ILogger<DeleteRoleCommandHandler> logger)
        {
            this.RoleService = roleService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IRoleService"/>.
        /// </summary>
        private IRoleService RoleService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{DeleteRoleCommandHandler}"/>.
        /// </summary>
        private ILogger<DeleteRoleCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteRoleCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                response = await this.RoleService.DeleteRoleAsync(request.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.DeleteRoleCommand);
                response = RequestResponse.Failure($"{ErrorsManager.DeleteRoleCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
