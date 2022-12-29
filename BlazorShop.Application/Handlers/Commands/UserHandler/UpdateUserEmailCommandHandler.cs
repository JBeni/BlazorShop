// <copyright file="UpdateUserEmailCommandHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{UpdateUserEmailCommand, RequestResponse}"/>.
    /// </summary>
    public class UpdateUserEmailCommandHandler : IRequestHandler<UpdateUserEmailCommand, RequestResponse>
    {
        /// <summary>
        /// An instance of <see cref="IUserService"/>.
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// An instance of <see cref="ILogger{UpdateUserEmailCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<UpdateUserEmailCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserEmailCommandHandler"/> class.
        /// </summary>
        /// <param name="userService">An instance of <see cref="IUserService"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{UpdateUserEmailCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateUserEmailCommandHandler(IUserService userService, ILogger<UpdateUserEmailCommandHandler> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateUserEmailCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(UpdateUserEmailCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var result = await _userService.UpdateUserEmailAsync(request);
                response = result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateUserEmailCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateUserEmailCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
