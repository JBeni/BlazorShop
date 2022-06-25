// <copyright file="GetUsersInactiveQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.UserHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetUsersInactiveQueryHandler : IRequestHandler<GetUsersInactiveQuery, Result<UserResponse>>
    {
        private readonly IUserService _userService;
        private readonly ILogger<GetUsersInactiveQueryHandler> _logger;

        public GetUsersInactiveQueryHandler(IUserService userService, ILogger<GetUsersInactiveQueryHandler> logger)
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
        public Task<Result<UserResponse>> Handle(GetUsersInactiveQuery request, CancellationToken cancellationToken)
        {
            Result<UserResponse>? response;

            try
            {
                var result = _userService.GetUsersInactive(request);

                response = new Result<UserResponse>
                {
                    Successful = true,
                    Items = result ?? new List<UserResponse>()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetUsersInactiveQuery);
                response = new Result<UserResponse>
                {
                    Error = $"{ErrorsManager.GetUsersInactiveQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}
