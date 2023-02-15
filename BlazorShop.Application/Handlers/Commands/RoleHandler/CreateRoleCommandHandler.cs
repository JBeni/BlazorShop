// <copyright file="CreateRoleCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.RoleHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{CreateRoleCommand, RequestResponse}"/>.
    /// </summary>
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRoleCommandHandler"/> class.
        /// </summary>
        /// <param name="roleService">Gets An instance of <see cref="IRoleService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{CreateRoleCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public CreateRoleCommandHandler(IRoleService roleService, ILogger<CreateRoleCommandHandler> logger)
        {
            this.RoleService = roleService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IRoleService"/>.
        /// </summary>
        private IRoleService RoleService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{CreateRoleCommandHandler}"/>.
        /// </summary>
        private ILogger<CreateRoleCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="CreateRoleCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                response = await this.RoleService.CreateRoleAsync(request);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.CreateRoleCommand);
                response = RequestResponse.Failure($"{ErrorsManager.CreateRoleCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
