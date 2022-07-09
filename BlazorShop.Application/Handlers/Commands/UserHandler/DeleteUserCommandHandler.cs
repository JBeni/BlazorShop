// <copyright file="DeleteUserCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, RequestResponse>
    {
        private readonly IUserService _userService;
        private readonly ILogger<DeleteUserCommandHandler> _logger;

        public DeleteUserCommandHandler(IUserService userService, ILogger<DeleteUserCommandHandler> logger)
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
        public async Task<RequestResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                response = await _userService.DeleteUserAsync(request.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.DeleteUserCommand);
                response = RequestResponse.Failure($"{ErrorsManager.DeleteUserCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
