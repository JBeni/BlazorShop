// <copyright file="GetRoleByIdQueryHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.RoleHandler
{
    /// <summary>
    /// Tests for <see cref="GetRoleByIdQueryHandler"/>.
    /// </summary>
    public class GetRoleByIdQueryHandlerTests
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<GetRoleByIdQueryHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRoleByIdQueryHandlerTests"/> class.
        /// </summary>
        public GetRoleByIdQueryHandlerTests(IRoleService roleService, ILogger<GetRoleByIdQueryHandlerTests> logger)
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
        public async Task Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
