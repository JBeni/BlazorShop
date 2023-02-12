// <copyright file="GetUserByIdQueryHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.UserHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetUserByIdQuery, UserResponse}"/>.
    /// </summary>
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="userService">Gets An instance of <see cref="IUserService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetUserByIdQueryHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetUserByIdQueryHandler(IUserService userService, ILogger<GetUserByIdQueryHandler> logger)
        {
            this.UserService = userService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IUserService"/>.
        /// </summary>
        private IUserService UserService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{GetUserByIdQueryHandler}"/>.
        /// </summary>
        private ILogger<GetUserByIdQueryHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetUserByIdQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{UserResponse}"/>.</returns>
        public Task<Result<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            Result<UserResponse>? response;

            try
            {
                var result = this.UserService.GetUserById(request);

                response = new Result<UserResponse>
                {
                    Successful = true,
                    Item = result ?? new UserResponse(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetUserByIdQuery);
                response = new Result<UserResponse>
                {
                    Error = $"{ErrorsManager.GetUserByIdQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}
