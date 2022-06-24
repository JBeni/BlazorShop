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
        /// <returns></returns>
        public async Task<RequestResponse> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.ActivateUserAsync(request);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.ActivateUserCommand);
                return RequestResponse.Failure($"{ErrorsManager.ActivateUserCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}
