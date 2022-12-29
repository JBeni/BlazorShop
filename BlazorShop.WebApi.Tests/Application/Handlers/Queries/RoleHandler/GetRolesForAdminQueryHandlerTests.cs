// <copyright file="GetRolesForAdminQueryHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.RoleHandler
{
    /// <summary>
    /// Tests for <see cref="GetRolesForAdminQueryHandler"/>.
    /// </summary>
    public class GetRolesForAdminQueryHandlerTests
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<GetRolesForAdminQueryHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRolesForAdminQueryHandlerTests"/> class.
        /// </summary>
        public GetRolesForAdminQueryHandlerTests(IRoleService roleService, ILogger<GetRolesForAdminQueryHandlerTests> logger)
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
        public async Task Handle(GetRolesForAdminQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
