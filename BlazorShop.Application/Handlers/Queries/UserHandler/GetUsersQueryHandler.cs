// <copyright file="GetUsersQueryHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.UserHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetUsersQuery, UserResponse}"/>.
    /// </summary>
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<UserResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUsersQueryHandler"/> class.
        /// </summary>
        /// <param name="userService">Gets An instance of <see cref="IUserService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetUsersQueryHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetUsersQueryHandler(IUserService userService, ILogger<GetUsersQueryHandler> logger)
        {
            this.UserService = userService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IUserService"/>.
        /// </summary>
        private IUserService UserService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{GetUsersQueryHandler}"/>.
        /// </summary>
        private ILogger<GetUsersQueryHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetUsersQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{UserResponse}"/>.</returns>
        public Task<Result<UserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            Result<UserResponse>? response;

            try
            {
                var result = this.UserService.GetUsers(request);

                response = new Result<UserResponse>
                {
                    Successful = true,
                    Items = result ?? new List<UserResponse>(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetUsersQuery);
                response = new Result<UserResponse>
                {
                    Error = $"{ErrorsManager.GetUsersQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}
