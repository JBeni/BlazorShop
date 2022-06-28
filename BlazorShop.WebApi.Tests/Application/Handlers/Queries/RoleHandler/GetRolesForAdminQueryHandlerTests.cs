// <copyright file="GetRolesForAdminQueryHandlerTests.cs" company="Beniamin Jitca">
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
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(GetRolesForAdminQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
