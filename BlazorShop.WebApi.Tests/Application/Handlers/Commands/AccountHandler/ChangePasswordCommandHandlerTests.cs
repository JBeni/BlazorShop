// <copyright file="ChangePasswordCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.AccountHandler
{
    /// <summary>
    /// Tests for <see cref="ChangePasswordCommandHandler"/>.
    /// </summary>
    public class ChangePasswordCommandHandlerTests
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<ChangePasswordCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePasswordCommandHandlerTests"/> class.
        /// </summary>
        public ChangePasswordCommandHandlerTests(IAccountService accountService, ILogger<ChangePasswordCommandHandlerTests> logger)
        {
            _accountService = accountService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
