// <copyright file="UpdateUserCommandHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{UpdateUserCommand, RequestResponse}"/>.
    /// </summary>
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, RequestResponse>
    {
        /// <summary>
        /// An instance of <see cref="IUserService"/>.
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// An instance of <see cref="ILogger{UpdateUserCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<UpdateUserCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResetPasswordCommandHandler"/> class.
        /// </summary>
        /// <param name="userService">An instance of <see cref="IUserService"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{UpdateUserCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateUserCommandHandler(IUserService userService, ILogger<UpdateUserCommandHandler> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateUserCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var result = await _userService.UpdateUserAsync(request);
                response = result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateUserCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateUserCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
