// <copyright file="UpdateUserEmailCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateUserEmailCommandHandler : IRequestHandler<UpdateUserEmailCommand, RequestResponse>
    {
        private readonly IUserService _userService;
        private readonly ILogger<UpdateUserEmailCommandHandler> _logger;

        public UpdateUserEmailCommandHandler(IUserService userService, ILogger<UpdateUserEmailCommandHandler> logger)
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
