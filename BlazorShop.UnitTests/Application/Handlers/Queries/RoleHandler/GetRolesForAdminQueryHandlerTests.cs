// <copyright file="GetRolesForAdminQueryHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Application.Handlers.Queries.RoleHandler
{
    /// <summary>
    /// Tests for <see cref="GetRolesForAdminQueryHandler"/> class.
    /// </summary>
    public class GetRolesForAdminQueryHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetRolesForAdminQueryHandlerTests"/> class.
        /// </summary>
        public GetRolesForAdminQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            this.ApplicationDbContext = new ApplicationDbContext(options);

            this.SUT = new GetRolesForAdminQueryHandler(
                this.RoleService,
                this.Logger);
        }

        /// <summary>
        /// Gets the instance of <see cref="GetRolesForAdminQueryHandler"/> to use.
        /// </summary>
        private GetRolesForAdminQueryHandler SUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="ApplicationDbContext"/> to use.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; } = Mock.Of<ApplicationDbContext>();

        /// <summary>
        /// Gets the instance of  <see cref="IRoleService"/> to use.
        /// </summary>
        private IRoleService RoleService { get; } = Mock.Of<IRoleService>();

        /// <summary>
        /// Gets the instance of  <see cref="ILogger{GetRolesForAdminQueryHandler}"/> to use.
        /// </summary>
        private ILogger<GetRolesForAdminQueryHandler> Logger { get; } = Mock.Of<ILogger<GetRolesForAdminQueryHandler>>();

        /// <summary>
        /// Gets the instance of  <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; } = Mock.Of<IMapper>();

        /// <summary>
        /// A test for <see cref="GetRolesForAdminQueryHandler.Handle(GetRolesForAdminQuery, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Result{ClotheResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="GetRolesForAdminQueryHandler.Handle(GetRolesForAdminQuery, CancellationToken)"/> method.
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
