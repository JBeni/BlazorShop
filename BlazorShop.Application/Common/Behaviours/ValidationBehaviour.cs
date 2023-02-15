// <copyright file="ValidationBehaviour.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using ValidationException = BlazorShop.Application.Common.Exceptions.ValidationException;

namespace BlazorShop.Application.Common.Behaviours
{
    /// <summary>
    /// A service to configure the validation behaviour.
    /// </summary>
    /// <typeparam name="TRequest">The request type.</typeparam>
    /// <typeparam name="TResponse">The response type.</typeparam>
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationBehaviour{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="validators">The list of validators.</param>
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            this.Validators = validators;
        }

        /// <summary>
        /// Gets The list of validators to apply on models.
        /// </summary>
        private IEnumerable<IValidator<TRequest>> Validators { get; }

        /// <summary>
        /// An implementation of the handler validation of commands and queries.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="next">The next request to validate.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{TResponse}"/>.</returns>
        /// <exception cref="ValidationException">Thrown if there is a validation rule not being met.</exception>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (this.Validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(this.Validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    throw new ValidationException(failures);
                }
            }

            return await next();
        }
    }
}
