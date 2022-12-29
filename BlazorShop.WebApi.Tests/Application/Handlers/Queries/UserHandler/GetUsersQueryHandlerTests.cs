// <copyright file="GetUsersQueryHandlerTests.cs" author="Beniamin Jitca">
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
        private readonly IUserService UserService;

        /// <summary>
        /// Gets the <see cref="ILogger<GetUsersQueryHandlerTests>"/> instance to use.
        /// </summary>
        private readonly ILogger<GetUsersQueryHandlerTests> Logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUsersQueryHandlerTests"/> class.
        /// </summary>
        /// <param name="userService">The <see cref="IUserService"/> instance to use.</param>
        /// <param name="logger">The <see cref="ILogger<GetUsersQueryHandlerTests>"/> instance to use.</param>
        public GetUsersQueryHandlerTests(IUserService userService, ILogger<GetUsersQueryHandlerTests> logger)
        {
            this.UserService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>

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
