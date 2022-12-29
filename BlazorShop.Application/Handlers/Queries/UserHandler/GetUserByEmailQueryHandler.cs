// <copyright file="GetUserByEmailQueryHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.UserHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetUserByEmailQuery, Result{UserResponse}}"/>.
    /// </summary>
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, Result<UserResponse>>
    {
        /// <summary>
        /// An instance of <see cref="IUserService"/>.
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// An instance of <see cref="ILogger{GetUserByEmailQueryHandler}"/>.
        /// </summary>
        private readonly ILogger<GetUserByEmailQueryHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserByEmailQueryHandler"/> class.
        /// </summary>
        /// <param name="userService">An instance of <see cref="IUserService"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{GetUserByEmailQueryHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetUserByEmailQueryHandler(IUserService userService, ILogger<GetUserByEmailQueryHandler> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="GetUserByEmailQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{Result{UserResponse}}"/>.</returns>
        public Task<Result<UserResponse>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            Result<UserResponse>? response;

            try
            {
                var result = _userService.GetUserByEmail(request);

                response = new Result<UserResponse>
                {
                    Successful = true,
                    Item = result ?? new UserResponse()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetUserByEmailQuery);
                response = new Result<UserResponse>
                {
                    Error = $"{ErrorsManager.GetUserByEmailQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}
