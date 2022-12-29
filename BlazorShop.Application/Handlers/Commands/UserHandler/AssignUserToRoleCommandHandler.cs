// <copyright file="AssignUserToRoleCommandHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{AssignUserToRoleCommand, RequestResponse}"/>.
    /// </summary>
    public class AssignUserToRoleCommandHandler : IRequestHandler<AssignUserToRoleCommand, RequestResponse>
    {
        /// <summary>
        /// An instance of <see cref="IUserService"/>.
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// An instance of <see cref="ILogger{AssignUserToRoleCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<AssignUserToRoleCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignUserToRoleCommandHandler"/> class.
        /// </summary>
        /// <param name="userService">An instance of <see cref="IUserService"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{AssignUserToRoleCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public AssignUserToRoleCommandHandler(IUserService userService, ILogger<AssignUserToRoleCommandHandler> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="AssignUserToRoleCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(AssignUserToRoleCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                response = await _userService.AssignUserToRoleAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.AssignUserToRoleCommand);
                response = RequestResponse.Failure($"{ErrorsManager.AssignUserToRoleCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
