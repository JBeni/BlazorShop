// <copyright file="GetUsersQueryHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.UserHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetUsersQuery, Result{UserResponse}}"/>.
    /// </summary>
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<UserResponse>>
    {
        /// <summary>
        /// An instance of <see cref="IUserService"/>.
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// An instance of <see cref="ILogger{GetUsersQueryHandler}"/>.
        /// </summary>
        private readonly ILogger<GetUsersQueryHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUsersQueryHandler"/> class.
        /// </summary>
        /// <param name="userService">An instance of <see cref="IUserService"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{GetUsersQueryHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetUsersQueryHandler(IUserService userService, ILogger<GetUsersQueryHandler> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="GetUsersQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{Result{UserResponse}}"/>.</returns>
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
