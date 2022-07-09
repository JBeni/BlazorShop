﻿// <copyright file="GetUserByEmailQueryHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.UserHandler
{
    /// <summary>
    /// Tests for <see cref="GetUserByEmailQueryHandler"/>.
    /// </summary>
    public class GetUserByEmailQueryHandlerTests
    {
        /// <summary>
        /// Gets the <see cref="IUserService"/> instance to use.
        /// </summary>
        private readonly IUserService UserService;

        /// <summary>
        /// Gets the <see cref="ILogger<GetUserByEmailQueryHandlerTests>"/> instance to use.
        /// </summary>
        private readonly ILogger<GetUserByEmailQueryHandlerTests> Logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserByEmailQueryHandlerTests"/> class.
        /// </summary>
        /// <param name="userService">The <see cref="IUserService"/> instance to use.</param>
        /// <param name="logger">The <see cref="ILogger<GetUserByEmailQueryHandlerTests>"/> instance to use.</param>
        public GetUserByEmailQueryHandlerTests(IUserService userService, ILogger<GetUserByEmailQueryHandlerTests> logger)
        {
            this.UserService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
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