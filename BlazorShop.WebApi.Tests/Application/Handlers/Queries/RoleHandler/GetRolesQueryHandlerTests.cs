// <copyright file="GetRolesQueryHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.RoleHandler
{
    /// <summary>
    /// Tests for <see cref="GetRolesQueryHandler"/>.
    /// </summary>
    public class GetRolesQueryHandlerTests
    {
        private IRoleService RoleService { get; }
        private ILogger<GetRolesQueryHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRolesQueryHandlerTests"/> class.
        /// </summary>
        public GetRolesQueryHandlerTests(IRoleService roleService, ILogger<GetRolesQueryHandlerTests> logger)
        {
            this.RoleService = roleService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public Task Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
