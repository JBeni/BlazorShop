// <copyright file="GetUserByEmailQueryHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.UserHandler
{
    /// <summary>
    /// Tests for <see cref="GetUserByEmailQueryHandler"/>.
    /// </summary>
    public class GetUserByEmailQueryHandlerTests
    {
        private readonly IUserService _userService;
        private readonly ILogger<GetUserByEmailQueryHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserByEmailQueryHandlerTests"/> class.
        /// </summary>
        public GetUserByEmailQueryHandlerTests(IUserService userService, ILogger<GetUserByEmailQueryHandlerTests> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
