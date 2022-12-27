// <copyright file="UpdateRoleCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.RoleHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateRoleCommandHandler"/>.
    /// </summary>
    public class UpdateRoleCommandHandlerTests
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<UpdateRoleCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateRoleCommandHandlerTests"/> class.
        /// </summary>
        public UpdateRoleCommandHandlerTests(IRoleService roleService, ILogger<UpdateRoleCommandHandlerTests> logger)
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
        public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
