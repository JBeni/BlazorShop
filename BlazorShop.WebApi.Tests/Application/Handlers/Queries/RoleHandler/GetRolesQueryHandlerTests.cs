// <copyright file="GetRolesQueryHandlerTests.cs" company="Beniamin Jitca">
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
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
