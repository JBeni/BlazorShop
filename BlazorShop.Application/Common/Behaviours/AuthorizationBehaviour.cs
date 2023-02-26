// <copyright file="AuthorizationBehaviour.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Common.Exceptions;
using BlazorShop.Application.Common.Security;

namespace BlazorShop.Application.Common.Behaviours
{
    /// <summary>
    /// A service to configure the authorization behaviour.
    /// </summary>
    /// <typeparam name="TRequest">The request type.</typeparam>
    /// <typeparam name="TResponse">The response type.</typeparam>
    public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationBehaviour{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="currentUserService">Gets an instance of <see cref="ICurrentUserService"/>.</param>
        /// <param name="identityService">Gets an instance of <see cref="IUserService"/>.</param>
        public AuthorizationBehaviour(
            ICurrentUserService currentUserService,
            IUserService identityService)
        {
            this.CurrentUserService = currentUserService;
            this.IdentityService = identityService;
        }

        /// <summary>
        /// Gets an instance of <see cref="ICurrentUserService"/>.
        /// </summary>
        private ICurrentUserService CurrentUserService { get; }

        /// <summary>
        /// Gets an instance of <see cref="IUserService"/>.
        /// </summary>
        private IUserService IdentityService { get; }

        /// <summary>
        /// An implementation of the authorization handler.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="next">The next request to validate.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{TResponse}"/>.</returns>
        /// <exception cref="UnauthorizedAccessException">The user do not have valid credentials.</exception>
        /// <exception cref="ForbiddenAccessException">The user do not have the permission to access the resource.</exception>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

            if (authorizeAttributes.Any())
            {
                // Must be authenticated user
                if (this.CurrentUserService.UserId != 0)
                {
                    throw new UnauthorizedAccessException();
                }

                // Role-based authorization
                var authorizeAttributesWithRoles = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles));

                if (authorizeAttributesWithRoles.Any())
                {
                    var authorized = false;

                    foreach (var roles in authorizeAttributesWithRoles.Select(a => a.Roles.Split(',')))
                    {
                        foreach (var role in roles)
                        {
                            var isInRole = await this.IdentityService.IsInRoleAsync(this.CurrentUserService.UserId, role.Trim());
                            if (isInRole)
                            {
                                authorized = true;
                                break;
                            }
                        }
                    }

                    // Must be a member of at least one role in roles
                    if (!authorized)
                    {
                        throw new ForbiddenAccessException();
                    }
                }

                // Policy-based authorization
                var authorizeAttributesWithPolicies = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Policy));
                if (authorizeAttributesWithPolicies.Any())
                {
                    foreach (var policy in authorizeAttributesWithPolicies.Select(a => a.Policy))
                    {
                        var authorized = await this.IdentityService.AuthorizeAsync(this.CurrentUserService.UserId, policy);

                        if (!authorized)
                        {
                            throw new ForbiddenAccessException();
                        }
                    }
                }
            }

            // User is authorized / authorization not required
            return await next();
        }
    }
}
