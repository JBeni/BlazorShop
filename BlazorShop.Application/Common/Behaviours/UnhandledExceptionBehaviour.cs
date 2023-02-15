// <copyright file="UnhandledExceptionBehaviour.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Behaviours
{
    /// <summary>
    /// A service to configure the unhandled exception behaviour.
    /// </summary>
    /// <typeparam name="TRequest">The request type.</typeparam>
    /// <typeparam name="TResponse">The response type.</typeparam>
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
         where TRequest : IRequest<TResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnhandledExceptionBehaviour{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="logger">Gets An instance of <see cref="ILogger{TRequest}"/>.</param>
        public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            this.Logger = logger;
        }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{TRequest}"/>.
        /// </summary>
        private ILogger<TRequest> Logger { get; }

        /// <summary>
        /// An implementation of the handler for unhandled exception behaviour.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="next">The next request to validate.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{TResponse}"/>.</returns>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                this.Logger.LogError(ex, "BlazorShop Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
                throw;
            }
        }
    }
}
