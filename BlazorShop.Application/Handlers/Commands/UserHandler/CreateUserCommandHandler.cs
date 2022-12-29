// <copyright file="CreateUserCommandHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{CreateUserCommand, RequestResponse}"/>.
    /// </summary>
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, RequestResponse>
    {
        /// <summary>
        /// An instance of <see cref="IUserService"/>.
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// An instance of <see cref="ILogger{CreateUserCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<CreateUserCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserCommandHandler"/> class.
        /// </summary>
        /// <param name="userService">An instance of <see cref="IUserService"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{CreateUserCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public CreateUserCommandHandler(IUserService userService, ILogger<CreateUserCommandHandler> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="CreateUserCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                response = await _userService.CreateUserAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.CreateUserCommand);
                response = RequestResponse.Failure($"{ErrorsManager.CreateUserCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
