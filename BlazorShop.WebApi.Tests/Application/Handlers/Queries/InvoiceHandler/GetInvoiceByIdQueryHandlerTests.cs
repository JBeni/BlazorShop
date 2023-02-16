// <copyright file="GetInvoiceByIdQueryHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Tests.Application.Handlers.Queries.InvoiceHandler
{
    /// <summary>
    /// Tests for <see cref="GetInvoiceByIdQueryHandler"/> class.
    /// </summary>
    public class GetInvoiceByIdQueryHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvoiceByIdQueryHandlerTests"/> class.
        /// </summary>
        public GetInvoiceByIdQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            this.ApplicationDbContext = new ApplicationDbContext(options);

            this.SUT = new GetInvoiceByIdQueryHandler(
                this.ApplicationDbContext,
                this.Logger,
                this.Mapper);
        }

        /// <summary>
        /// Gets the instance of <see cref="GetInvoiceByIdQueryHandler"/> to use.
        /// </summary>
        private GetInvoiceByIdQueryHandler SUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="ApplicationDbContext"/> to use.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; } = Mock.Of<ApplicationDbContext>();

        /// <summary>
        /// Gets the instance of  <see cref="ILogger{GetInvoiceByIdQueryHandler}"/> to use.
        /// </summary>
        private ILogger<GetInvoiceByIdQueryHandler> Logger { get; } = Mock.Of<ILogger<GetInvoiceByIdQueryHandler>>();

        /// <summary>
        /// Gets the instance of  <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; } = Mock.Of<IMapper>();

        /// <summary>
        /// A test for <see cref="GetInvoiceByIdQueryHandler.Handle(GetInvoiceByIdQuery, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Result{ClotheResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="GetInvoiceByIdQueryHandler.Handle(GetInvoiceByIdQuery, CancellationToken)"/> method.
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
