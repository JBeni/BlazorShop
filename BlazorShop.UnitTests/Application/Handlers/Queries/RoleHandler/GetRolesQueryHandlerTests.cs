// <copyright file="GetRolesQueryHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Application.Handlers.Queries.RoleHandler
{
    /// <summary>
    /// Tests for <see cref="GetRolesQueryHandler"/> class.
    /// </summary>
    public class GetRolesQueryHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetRolesQueryHandlerTests"/> class.
        /// </summary>
        public GetRolesQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            this.ApplicationDbContext = new ApplicationDbContext(options);

            this.SUT = new GetRolesQueryHandler(
                this.RoleService,
                this.Logger);
        }

        /// <summary>
        /// Gets the instance of <see cref="GetRolesQueryHandler"/> to use.
        /// </summary>
        private GetRolesQueryHandler SUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="ApplicationDbContext"/> to use.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; } = Mock.Of<ApplicationDbContext>();

        /// <summary>
        /// Gets the instance of  <see cref="IRoleService"/> to use.
        /// </summary>
        private IRoleService RoleService { get; } = Mock.Of<IRoleService>();

        /// <summary>
        /// Gets the instance of  <see cref="ILogger{GetRolesQueryHandler}"/> to use.
        /// </summary>
        private ILogger<GetRolesQueryHandler> Logger { get; } = Mock.Of<ILogger<GetRolesQueryHandler>>();

        /// <summary>
        /// Gets the instance of  <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; } = Mock.Of<IMapper>();

        /// <summary>
        /// A test for <see cref="GetRolesQueryHandler.Handle(GetClaimsQuery, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Result{ClotheResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="GetRolesQueryHandler.Handle(GetClaimsQuery, CancellationToken)"/> method.
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
