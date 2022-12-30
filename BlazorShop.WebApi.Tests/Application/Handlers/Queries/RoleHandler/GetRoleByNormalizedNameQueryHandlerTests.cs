// <copyright file="GetRoleByNormalizedNameQueryHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.RoleHandler
{
    /// <summary>
    /// Tests for <see cref="GetRoleByNormalizedNameQueryHandler"/>.
    /// </summary>
    public class GetRoleByNormalizedNameQueryHandlerTests
    {
        private IRoleService RoleService { get; }
        private ILogger<GetRoleByNormalizedNameQueryHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRoleByNormalizedNameQueryHandlerTests"/> class.
        /// </summary>
        public GetRoleByNormalizedNameQueryHandlerTests(IRoleService roleService, ILogger<GetRoleByNormalizedNameQueryHandlerTests> logger)
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
        public Task Handle(GetRoleByNormalizedNameQuery request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
