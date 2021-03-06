// <copyright file="GetUsersQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.UserHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<UserResponse>>
    {
        private readonly IUserService _userService;
        private readonly ILogger<GetUsersQueryHandler> _logger;

        public GetUsersQueryHandler(IUserService userService, ILogger<GetUsersQueryHandler> logger)
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
        public Task<Result<UserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            Result<UserResponse>? response;

            try
            {
                var result = _userService.GetUsers(request);

                response = new Result<UserResponse>
                {
                    Successful = true,
                    Items = result ?? new List<UserResponse>()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetUsersQuery);
                response = new Result<UserResponse>
                {
                    Error = $"{ErrorsManager.GetUsersQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}
