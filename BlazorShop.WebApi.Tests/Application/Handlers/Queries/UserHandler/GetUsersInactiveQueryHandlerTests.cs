    // <copyright file="GetUsersInactiveQueryHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.UserHandler
{
    /// <summary>
    /// Tests for <see cref="GetUsersInactiveQueryHandler"/>.
    /// </summary>
    public class GetUsersInactiveQueryHandlerTests
    {
        private readonly IUserService _userService;
        private readonly ILogger<GetUsersInactiveQueryHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUsersInactiveQueryHandlerTests"/> class.
        /// </summary>
        public GetUsersInactiveQueryHandlerTests(IUserService userService, ILogger<GetUsersInactiveQueryHandlerTests> logger)
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
        public async Task Handle(GetUsersInactiveQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
