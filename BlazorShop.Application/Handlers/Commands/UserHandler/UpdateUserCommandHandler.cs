// <copyright file="UpdateUserCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{UpdateUserCommand, RequestResponse}"/>.
    /// </summary>
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserCommandHandler"/> class.
        /// </summary>
        /// <param name="userService">Gets An instance of <see cref="IUserService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{UpdateUserCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateUserCommandHandler(IUserService userService, ILogger<UpdateUserCommandHandler> logger)
        {
            this.UserService = userService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IUserService"/>.
        /// </summary>
        private IUserService UserService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{UpdateUserCommandHandler}"/>.
        /// </summary>
        private ILogger<UpdateUserCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateUserCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var result = await this.UserService.UpdateUserAsync(request);
                response = result;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.UpdateUserCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateUserCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
