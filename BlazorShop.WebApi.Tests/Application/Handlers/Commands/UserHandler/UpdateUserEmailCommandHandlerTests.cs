// <copyright file="UpdateUserEmailCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateUserEmailCommandHandler"/>.
    /// </summary>
    public class UpdateUserEmailCommandHandlerTests
    {
        private readonly IUserService _userService;
        private readonly ILogger<UpdateUserEmailCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserEmailCommandHandlerTests"/> class.
        /// </summary>
        public UpdateUserEmailCommandHandlerTests(IUserService userService, ILogger<UpdateUserEmailCommandHandlerTests> logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response =s></response =s>
        public async Task Handle(UpdateUserEmailCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
