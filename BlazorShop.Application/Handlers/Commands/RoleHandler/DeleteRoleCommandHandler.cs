// <copyright file="DeleteRoleCommandHandler.cs" author="Beniamin Jitca">
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
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IRoleService _roleService;

        /// <summary>
        /// An instance of <see cref="ILogger{DeleteRoleCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<DeleteRoleCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteRoleCommandHandler"/> class.
        /// </summary>
        /// <param name="roleService">An instance of <see cref="IRoleService"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{DeleteRoleCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public DeleteRoleCommandHandler(IRoleService roleService, ILogger<DeleteRoleCommandHandler> logger)
        {
            _roleService = roleService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteRoleCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                response = await _roleService.DeleteRoleAsync(request.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.DeleteRoleCommand);
                response = RequestResponse.Failure($"{ErrorsManager.DeleteRoleCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
