// <copyright file="GetUserByEmailQueryHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Application.Handlers.Queries.UserHandler
{
    /// <summary>
    /// Tests for <see cref="GetUserByEmailQueryHandler"/> class.
    /// </summary>
    public class GetUserByEmailQueryHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserByEmailQueryHandlerTests"/> class.
        /// </summary>
        public GetUserByEmailQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            this.ApplicationDbContext = new ApplicationDbContext(options);

            this.SUT = new GetUserByEmailQueryHandler(
                this.UserService,
                this.Logger);
        }

        /// <summary>
        /// Gets the instance of <see cref="GetUserByEmailQueryHandler"/> to use.
        /// </summary>
        private GetUserByEmailQueryHandler SUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="ApplicationDbContext"/> to use.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; } = Mock.Of<ApplicationDbContext>();

        /// <summary>
        /// Gets the instance of  <see cref="IUserService"/> to use.
        /// </summary>
        private IUserService UserService { get; } = Mock.Of<IUserService>();

        /// <summary>
        /// Gets the instance of  <see cref="ILogger{GetUserByEmailQueryHandler}"/> to use.
        /// </summary>
        private ILogger<GetUserByEmailQueryHandler> Logger { get; } = Mock.Of<ILogger<GetUserByEmailQueryHandler>>();

        /// <summary>
        /// Gets the instance of  <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; } = Mock.Of<IMapper>();

        /// <summary>
        /// A test for <see cref="GetUserByEmailQueryHandler.Handle(GetUserByEmailQuery, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Result{ClotheResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="GetUserByEmailQueryHandler.Handle(GetUserByEmailQuery, CancellationToken)"/> method.
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
