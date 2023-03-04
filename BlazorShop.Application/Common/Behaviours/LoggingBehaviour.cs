// <copyright file="LoggingBehaviour.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using MediatR.Pipeline;

namespace BlazorShop.Application.Common.Behaviours
{
    /// <summary>
    /// A service to configure the logging behaviour.
    /// </summary>
    /// <typeparam name="TRequest">The request type.</typeparam>
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
        where TRequest : notnull
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingBehaviour{TRequest}"/> class.
        /// </summary>
        /// <param name="logger">Gets an instance of <see cref="ILogger{TRequest}"/>.</param>
        /// <param name="currentUserService">Gets an instance of <see cref="ICurrentUserService"/>.</param>
        /// <param name="identityService">Gets an instance of <see cref="IUserService"/>.</param>
        public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService, IUserService identityService)
        {
            this.Logger = logger;
            this.CurrentUserService = currentUserService;
            this.IdentityService = identityService;
        }

        /// <summary>
        /// Gets an instance of <see cref="ILogger{TRequest}"/>.
        /// </summary>
        private ILogger Logger { get; }

        /// <summary>
        /// Gets an instance of <see cref="ICurrentUserService"/>.
        /// </summary>
        private ICurrentUserService CurrentUserService { get; }

        /// <summary>
        /// Gets an instance of <see cref="IUserService"/>.
        /// </summary>
        private IUserService IdentityService { get; }

        /// <summary>
        /// An implementation of the handler for logging behaviour.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{TResponse}"/>.</returns>
        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = this.CurrentUserService.UserId;
            string? userName = string.Empty;

            if (userId != 0)
            {
                userName = (await this.IdentityService.FindUserByIdAsync(userId))?.UserName;
            }

            this.Logger.LogInformation(
                "CleanArchitecture Request: {Name} {@UserId} {@UserName} {@Request}",
                requestName,
                userId,
                userName,
                request);
        }
    }
}
