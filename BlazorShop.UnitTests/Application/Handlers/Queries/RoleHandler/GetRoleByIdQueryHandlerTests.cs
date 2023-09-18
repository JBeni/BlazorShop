// <copyright file="GetRoleByIdQueryHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Application.Handlers.Queries.RoleHandler
{
    /// <summary>
    /// Tests for <see cref="GetRoleByIdQueryHandler"/> class.
    /// </summary>
    public class GetRoleByIdQueryHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetRoleByIdQueryHandlerTests"/> class.
        /// </summary>
        public GetRoleByIdQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            this.ApplicationDbContext = new ApplicationDbContext(options);

            this.SUT = new GetRoleByIdQueryHandler(
                this.RoleService,
                this.Logger);
        }

        /// <summary>
        /// Gets the instance of <see cref="GetRoleByIdQueryHandler"/> to use.
        /// </summary>
        private GetRoleByIdQueryHandler SUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="ApplicationDbContext"/> to use.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; } = Mock.Of<ApplicationDbContext>();

        /// <summary>
        /// Gets the instance of  <see cref="IRoleService"/> to use.
        /// </summary>
        private IRoleService RoleService { get; } = Mock.Of<IRoleService>();

        /// <summary>
        /// Gets the instance of  <see cref="ILogger{GetRoleByIdQueryHandler}"/> to use.
        /// </summary>
        private ILogger<GetRoleByIdQueryHandler> Logger { get; } = Mock.Of<ILogger<GetRoleByIdQueryHandler>>();

        /// <summary>
        /// Gets the instance of  <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; } = Mock.Of<IMapper>();

        /// <summary>
        /// A test for <see cref="GetRoleByIdQueryHandler.Handle(GetClaimByIdQuery, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Result{ClotheResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="GetRoleByIdQueryHandler.Handle(GetClaimByIdQuery, CancellationToken)"/> method.
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
