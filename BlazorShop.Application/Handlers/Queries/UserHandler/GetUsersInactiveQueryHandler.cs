// <copyright file="GetUsersInactiveQueryHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.UserHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetUsersInactiveQuery, Result{UserResponse}}"/>.
    /// </summary>
    public class GetUsersInactiveQueryHandler : IRequestHandler<GetUsersInactiveQuery, Result<UserResponse>>
    {
        /// <summary>
        /// An instance of <see cref="IUserService"/>.
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// An instance of <see cref="ILogger{GetUsersInactiveQueryHandler}"/>.
        /// </summary>
        private readonly ILogger<GetUsersInactiveQueryHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUsersInactiveQueryHandler"/> class.
        /// </summary>
        /// <param name="userService">An instance of <see cref="IUserService"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{GetUsersInactiveQueryHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetUsersInactiveQueryHandler(IUserService userService, ILogger<GetUsersInactiveQueryHandler> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="GetUsersInactiveQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{Result{UserResponse}}"/>.</returns>
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
