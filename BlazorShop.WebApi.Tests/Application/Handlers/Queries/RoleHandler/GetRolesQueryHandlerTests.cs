// <copyright file="GetRolesQueryHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.RoleHandler
{
    /// <summary>
    /// Tests for <see cref="GetRolesQueryHandler"/>.
    /// </summary>
    public class GetRolesQueryHandlerTests
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<GetRolesQueryHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRolesQueryHandlerTests"/> class.
        /// </summary>
        public GetRolesQueryHandlerTests(IRoleService roleService, ILogger<GetRolesQueryHandlerTests> logger)
        {
            _roleService = roleService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
