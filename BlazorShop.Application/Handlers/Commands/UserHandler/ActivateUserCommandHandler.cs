// <copyright file="ActivateUserCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class ActivateUserCommandHandler : IRequestHandler<ActivateUserCommand, RequestResponse>
    {
        private readonly IUserService _userService;
        private readonly ILogger<ActivateUserCommandHandler> _logger;

        public ActivateUserCommandHandler(IUserService userService, ILogger<ActivateUserCommandHandler> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response =s></response =s>
        public async Task<RequestResponse> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                response = await _userService.ActivateUserAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.ActivateUserCommand);
                response = RequestResponse.Failure($"{ErrorsManager.ActivateUserCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
