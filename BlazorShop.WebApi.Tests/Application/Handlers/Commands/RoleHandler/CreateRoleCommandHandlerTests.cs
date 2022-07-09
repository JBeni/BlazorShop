// <copyright file="CreateRoleCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.RoleHandler
{
    /// <summary>
    /// Tests for <see cref="CreateRoleCommandHandler"/>.
    /// </summary>
    public class CreateRoleCommandHandlerTests
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<CreateRoleCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRoleCommandHandlerTests"/> class.
        /// </summary>
        public CreateRoleCommandHandlerTests(IRoleService roleService, ILogger<CreateRoleCommandHandlerTests> logger)
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
        public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
