// <copyright file="GetUsersQueryHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.UserHandler
{
    /// <summary>
    /// Tests for <see cref="GetUsersQueryHandler"/>.
    /// </summary>
    public class GetUsersQueryHandlerTests
    {
        /// <summary>
        /// Gets the <see cref="IUserService"/> instance to use.
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// Gets the <see cref="ILogger<GetUsersQueryHandlerTests>"/> instance to use.
        /// </summary>
        private readonly ILogger<GetUsersQueryHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUsersQueryHandlerTests"/> class.
        /// </summary>
        public GetUsersQueryHandlerTests(IUserService userService, ILogger<GetUsersQueryHandlerTests> logger)
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

        /// <summary>
        /// Ensures that the <see cref="IAppointmentsRepository.GetOutstandingAppointmentIdsForUser(string)"/> method
        /// returns outstanding appointments for the current user.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
