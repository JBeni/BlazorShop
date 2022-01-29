﻿namespace BlazorShop.Application.Handlers.Commands.UserHandler
{
    public class ActivateUserCommandHandler : IRequestHandler<ActivateUserCommand, RequestResponse>
    {
        private readonly IUserService _userService;
        private readonly ILogger<UpdateUserCommandHandler> _logger;

        public ActivateUserCommandHandler(IUserService userService, ILogger<UpdateUserCommandHandler> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<RequestResponse> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.ActivateUserAsync(request);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while activating the user");
                return RequestResponse.Failure($"There was an error while activating the user. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}