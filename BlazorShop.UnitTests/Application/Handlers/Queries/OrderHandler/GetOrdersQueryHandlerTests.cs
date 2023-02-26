// <copyright file="GetOrdersQueryHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Application.Handlers.Queries.OrderHandler
{
    /// <summary>
    /// Tests for <see cref="GetOrdersQueryHandler"/> class.
    /// </summary>
    public class GetOrdersQueryHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrdersQueryHandlerTests"/> class.
        /// </summary>
        public GetOrdersQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            this.ApplicationDbContext = new ApplicationDbContext(options);

            this.SUT = new GetOrdersQueryHandler(
                this.ApplicationDbContext,
                this.Logger,
                this.Mapper);
        }

        /// <summary>
        /// Gets the instance of <see cref="GetOrdersQueryHandler"/> to use.
        /// </summary>
        private GetOrdersQueryHandler SUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="ApplicationDbContext"/> to use.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; } = Mock.Of<ApplicationDbContext>();

        /// <summary>
        /// Gets the instance of  <see cref="ILogger{GetOrdersQueryHandler}"/> to use.
        /// </summary>
        private ILogger<GetOrdersQueryHandler> Logger { get; } = Mock.Of<ILogger<GetOrdersQueryHandler>>();

        /// <summary>
        /// Gets the instance of  <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; } = Mock.Of<IMapper>();

        /// <summary>
        /// A test for <see cref="GetOrdersQueryHandler.Handle(GetOrdersQuery, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Result{ClotheResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="GetOrdersQueryHandler.Handle(GetOrdersQuery, CancellationToken)"/> method.
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
