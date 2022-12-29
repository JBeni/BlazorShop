// <copyright file="CreateRoleCommandHandler.cs" author="Beniamin Jitca">
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
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IRoleService _roleService;

        /// <summary>
        /// An instance of <see cref="ILogger{CreateRoleCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<CreateRoleCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRoleCommandHandler"/> class.
        /// </summary>
        /// <param name="roleService">An instance of <see cref="IRoleService"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{CreateRoleCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public CreateRoleCommandHandler(IRoleService roleService, ILogger<CreateRoleCommandHandler> logger)
        {
            _roleService = roleService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="CreateRoleCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                response = await _roleService.CreateRoleAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.CreateRoleCommand);
                response = RequestResponse.Failure($"{ErrorsManager.CreateRoleCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
