// <copyright file="GetRoleByNormalizedNameQueryHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.RoleHandler
{
    /// <summary>
    /// Tests for <see cref="GetRoleByNormalizedNameQueryHandler"/>.
    /// </summary>
    public class GetRoleByNormalizedNameQueryHandlerTests
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<GetRoleByNormalizedNameQueryHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRoleByNormalizedNameQueryHandlerTests"/> class.
        /// </summary>
        public GetRoleByNormalizedNameQueryHandlerTests(IRoleService roleService, ILogger<GetRoleByNormalizedNameQueryHandlerTests> logger)
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
        public async Task Handle(GetRoleByNormalizedNameQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
