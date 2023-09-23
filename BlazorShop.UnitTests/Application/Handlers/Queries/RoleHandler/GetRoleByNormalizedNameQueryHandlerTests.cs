// <copyright file="GetRoleByNormalizedNameQueryHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Application.Handlers.Queries.RoleHandler
{
    /// <summary>
    /// Tests for <see cref="GetRoleByNormalizedNameQueryHandler"/> class.
    /// </summary>
    public class GetRoleByNormalizedNameQueryHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetRoleByNormalizedNameQueryHandlerTests"/> class.
        /// </summary>
        public GetRoleByNormalizedNameQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            this.ApplicationDbContext = new ApplicationDbContext(options);

            this.SUT = new GetRoleByNormalizedNameQueryHandler(
                this.RoleService,
                this.Logger);
        }

        /// <summary>
        /// Gets the instance of <see cref="GetRoleByNormalizedNameQueryHandler"/> to use.
        /// </summary>
        private GetRoleByNormalizedNameQueryHandler SUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="ApplicationDbContext"/> to use.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; } = Mock.Of<ApplicationDbContext>();

        /// <summary>
        /// Gets the instance of  <see cref="IRoleService"/> to use.
        /// </summary>
        private IRoleService RoleService { get; } = Mock.Of<IRoleService>();

        /// <summary>
        /// Gets the instance of  <see cref="ILogger{GetRoleByNormalizedNameQueryHandler}"/> to use.
        /// </summary>
        private ILogger<GetRoleByNormalizedNameQueryHandler> Logger { get; } = Mock.Of<ILogger<GetRoleByNormalizedNameQueryHandler>>();

        /// <summary>
        /// Gets the instance of  <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; } = Mock.Of<IMapper>();

        /// <summary>
        /// A test for <see cref="GetRoleByNormalizedNameQueryHandler.Handle(GetClaimByValueQuery, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Result{ClotheResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="GetRoleByNormalizedNameQueryHandler.Handle(GetClaimByValueQuery, CancellationToken)"/> method.
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
