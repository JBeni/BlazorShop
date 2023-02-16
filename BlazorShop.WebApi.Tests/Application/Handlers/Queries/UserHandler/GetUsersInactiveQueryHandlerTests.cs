// <copyright file="GetUsersInactiveQueryHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Tests.Application.Handlers.Queries.UserHandler
{
    /// <summary>
    /// Tests for <see cref="GetUsersInactiveQueryHandler"/> class.
    /// </summary>
    public class GetUsersInactiveQueryHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUsersInactiveQueryHandlerTests"/> class.
        /// </summary>
        public GetUsersInactiveQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            this.ApplicationDbContext = new ApplicationDbContext(options);

            this.SUT = new GetUsersInactiveQueryHandler(
                this.UserService,
                this.Logger);
        }

        /// <summary>
        /// Gets the instance of <see cref="GetUsersInactiveQueryHandler"/> to use.
        /// </summary>
        private GetUsersInactiveQueryHandler SUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="ApplicationDbContext"/> to use.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; } = Mock.Of<ApplicationDbContext>();

        /// <summary>
        /// Gets the instance of  <see cref="IUserService"/> to use.
        /// </summary>
        private IUserService UserService { get; } = Mock.Of<IUserService>();

        /// <summary>
        /// Gets the instance of  <see cref="ILogger{GetUsersInactiveQueryHandler}"/> to use.
        /// </summary>
        private ILogger<GetUsersInactiveQueryHandler> Logger { get; } = Mock.Of<ILogger<GetUsersInactiveQueryHandler>>();

        /// <summary>
        /// Gets the instance of  <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; } = Mock.Of<IMapper>();

        /// <summary>
        /// A test for <see cref="GetUsersInactiveQueryHandler.Handle(GetUsersInactiveQuery, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Result{ClotheResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="GetUsersInactiveQueryHandler.Handle(GetUsersInactiveQuery, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Result{ClotheResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// Ensure garbage collector for db context and reset the database.
        /// </summary>
        public void Dispose()
        {
            this.ApplicationDbContext.Database.EnsureDeleted();
            GC.SuppressFinalize(this);
        }
    }
}
