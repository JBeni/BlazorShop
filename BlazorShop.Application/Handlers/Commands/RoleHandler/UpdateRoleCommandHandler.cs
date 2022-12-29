// <copyright file="UpdateRoleCommandHandler.cs" author="Beniamin Jitca">
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
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IRoleService _roleService;

        /// <summary>
        /// An instance of <see cref="ILogger{UpdateRoleCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<UpdateRoleCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateRoleCommandHandler"/> class.
        /// </summary>
        /// <param name="roleService">An instance of <see cref="IRoleService"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{UpdateRoleCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>

        public UpdateRoleCommandHandler(IRoleService roleService, ILogger<UpdateRoleCommandHandler> logger)
        {
            _roleService = roleService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

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
                response = await _roleService.UpdateRoleAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateRoleCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateRoleCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
