// <copyright file="GetInvoicesQueryHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.InvoiceHandler
{
    /// <summary>
    /// Tests for <see cref="GetInvoicesQueryHandler"/> class.
    /// </summary>
    public class GetInvoicesQueryHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvoicesQueryHandlerTests"/> class.
        /// </summary>
        public GetInvoicesQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            this.ApplicationDbContext = new ApplicationDbContext(options);

            this.SUT = new GetInvoicesQueryHandler(
                this.ApplicationDbContext,
                this.Logger,
                this.Mapper);
        }

        /// <summary>
        /// Gets the instance of <see cref="GetInvoicesQueryHandler"/> to use.
        /// </summary>
        private GetInvoicesQueryHandler SUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="ApplicationDbContext"/> to use.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; } = Mock.Of<ApplicationDbContext>();

        /// <summary>
        /// Gets the instance of  <see cref="ILogger{GetInvoicesQueryHandler}"/> to use.
        /// </summary>
        private ILogger<GetInvoicesQueryHandler> Logger { get; } = Mock.Of<ILogger<GetInvoicesQueryHandler>>();

        /// <summary>
        /// Gets the instance of  <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; } = Mock.Of<IMapper>();

        /// <summary>
        /// A test for <see cref="GetInvoicesQueryHandler.Handle(GetInvoicesQuery, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Result{ClotheResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="GetInvoicesQueryHandler.Handle(GetInvoicesQuery, CancellationToken)"/> method.
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
