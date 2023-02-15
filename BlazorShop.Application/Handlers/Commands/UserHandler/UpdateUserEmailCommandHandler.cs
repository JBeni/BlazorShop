// <copyright file="UpdateUserEmailCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{UpdateUserEmailCommand, RequestResponse}"/>.
    /// </summary>
    public class UpdateUserEmailCommandHandler : IRequestHandler<UpdateUserEmailCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserEmailCommandHandler"/> class.
        /// </summary>
        /// <param name="userService">Gets An instance of <see cref="IUserService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{UpdateUserEmailCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateUserEmailCommandHandler(IUserService userService, ILogger<UpdateUserEmailCommandHandler> logger)
        {
            this.UserService = userService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IUserService"/>.
        /// </summary>
        private IUserService UserService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{UpdateUserEmailCommandHandler}"/>.
        /// </summary>
        private ILogger<UpdateUserEmailCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateUserEmailCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(UpdateUserEmailCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var result = await this.UserService.UpdateUserEmailAsync(request);
                response = result;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.UpdateUserEmailCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateUserEmailCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
