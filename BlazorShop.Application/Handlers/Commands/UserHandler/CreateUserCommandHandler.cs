// <copyright file="CreateUserCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{CreateUserCommand, RequestResponse}"/>.
    /// </summary>
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserCommandHandler"/> class.
        /// </summary>
        /// <param name="userService">Gets An instance of <see cref="IUserService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{CreateUserCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public CreateUserCommandHandler(IUserService userService, ILogger<CreateUserCommandHandler> logger)
        {
            this.UserService = userService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IUserService"/>.
        /// </summary>
        private IUserService UserService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{CreateUserCommandHandler}"/>.
        /// </summary>
        private ILogger<CreateUserCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="CreateUserCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                response = await this.UserService.CreateUserAsync(request);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.CreateUserCommand);
                response = RequestResponse.Failure($"{ErrorsManager.CreateUserCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
