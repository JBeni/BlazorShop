// <copyright file="GetUsersQueryHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.UserHandler
{
    /// <summary>
    /// Tests for <see cref="GetUsersQueryHandler"/> class.
    /// </summary>
    public class GetUsersQueryHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUsersQueryHandlerTests"/> class.
        /// </summary>
        public GetUsersQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            this.ApplicationDbContext = new ApplicationDbContext(options);

            this.SUT = new GetUsersQueryHandler(
                this.UserService,
                this.Logger);
        }

        /// <summary>
        /// Gets the instance of <see cref="GetUsersQueryHandler"/> to use.
        /// </summary>
        private GetUsersQueryHandler SUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="ApplicationDbContext"/> to use.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; } = Mock.Of<ApplicationDbContext>();

        /// <summary>
        /// Gets the instance of  <see cref="IUserService"/> to use.
        /// </summary>
        private IUserService UserService { get; } = Mock.Of<IUserService>();

        /// <summary>
        /// Gets the instance of  <see cref="ILogger{GetUsersQueryHandler}"/> to use.
        /// </summary>
        private ILogger<GetUsersQueryHandler> Logger { get; } = Mock.Of<ILogger<GetUsersQueryHandler>>();

        /// <summary>
        /// Gets the instance of  <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; } = Mock.Of<IMapper>();

        /// <summary>
        /// A test for <see cref="GetUsersQueryHandler.Handle(GetUsersQuery, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Result{ClotheResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="GetUsersQueryHandler.Handle(GetUsersQuery, CancellationToken)"/> method.
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
