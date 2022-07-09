// <copyright file="CreateUserCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, RequestResponse>
    {
        private readonly IUserService _userService;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(IUserService userService, ILogger<CreateUserCommandHandler> logger)
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
