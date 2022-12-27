// <copyright file="DeleteRoleCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.RoleHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteRoleCommandHandler"/>.
    /// </summary>
    public class DeleteRoleCommandHandlerTests
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<DeleteRoleCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteRoleCommandHandlerTests"/> class.
        /// </summary>
        public DeleteRoleCommandHandlerTests(IRoleService roleService, ILogger<DeleteRoleCommandHandlerTests> logger)
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
        public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
