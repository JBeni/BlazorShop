// <copyright file="GetTodoItemByIdQueryHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Tests.Application.Handlers.Queries.TodoItemHandler
{
    /// <summary>
    /// Tests for <see cref="GetTodoItemByIdQueryHandler"/> class.
    /// </summary>
    public class GetTodoItemByIdQueryHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTodoItemByIdQueryHandlerTests"/> class.
        /// </summary>
        public GetTodoItemByIdQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            this.ApplicationDbContext = new ApplicationDbContext(options);

            this.SUT = new GetTodoItemByIdQueryHandler(
                this.ApplicationDbContext,
                this.Logger,
                this.Mapper);
        }

        /// <summary>
        /// Gets the instance of <see cref="GetTodoItemByIdQueryHandler"/> to use.
        /// </summary>
        private GetTodoItemByIdQueryHandler SUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="ApplicationDbContext"/> to use.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; } = Mock.Of<ApplicationDbContext>();

        /// <summary>
        /// Gets the instance of  <see cref="ILogger{GetTodoItemByIdQueryHandler}"/> to use.
        /// </summary>
        private ILogger<GetTodoItemByIdQueryHandler> Logger { get; } = Mock.Of<ILogger<GetTodoItemByIdQueryHandler>>();

        /// <summary>
        /// Gets the instance of  <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; } = Mock.Of<IMapper>();

        /// <summary>
        /// A test for <see cref="GetTodoItemByIdQueryHandler.Handle(GetTodoItemByIdQuery, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Result{ClotheResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="GetTodoItemByIdQueryHandler.Handle(GetTodoItemByIdQuery, CancellationToken)"/> method.
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
