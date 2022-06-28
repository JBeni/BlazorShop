// <copyright file="GetUserByIdQueryHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.UserHandler
{
    /// <summary>
    /// Tests for <see cref="GetUserByIdQueryHandler"/>.
    /// </summary>
    public class GetUserByIdQueryHandlerTests
    {
        private readonly IUserService _userService;
        private readonly ILogger<GetUserByIdQueryHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserByIdQueryHandlerTests"/> class.
        /// </summary>
        public GetUserByIdQueryHandlerTests(IUserService userService, ILogger<GetUserByIdQueryHandlerTests> logger)
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
        public async Task Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
