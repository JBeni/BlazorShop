// <copyright file="GetCartByIdQueryHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Commands.CartCommand;
using BlazorShop.Application.Handlers.Queries.CartHandler;
using BlazorShop.Infrastructure.Persistence;
using BlazorShop.WebApi.Tests.Utils;
using Moq;
using Xunit;

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.CartHandler
{
    /// <summary>
    /// Tests for <see cref="GetCartByIdQueryHandler"/> class.
    /// </summary>
    public class GetCartByIdQueryHandlerTests : IClassFixture<IdentityDbContextFixture>, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCartByIdQueryHandlerTests"/> class.
        /// </summary>
        public GetCartByIdQueryHandlerTests()
        {
            this.ApplicationDbContext = new ApplicationDbContext(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: $"ApplicationDbContext-Core")
                    .Options);

            this.Fixture = new IdentityDbContextFixture();
            this.UserManager = this.Fixture.GetUserManager();

            this.SUT = new GetCartByIdQueryHandler(
                this.ApplicationDbContext,
                this.Logger,
                this.Mapper);
        }

        /// <summary>
        /// Gets the instance of <see cref="GetCartByIdQueryHandler"/> to use.
        /// </summary>
        private GetCartByIdQueryHandler SUT { get; }

        /// <summary>
        /// .
        /// </summary>
        private UserManager<User> UserManager { get; }

        /// <summary>
        /// .
        /// </summary>
        private IdentityDbContextFixture Fixture { get; }

        /// <summary>
        /// Gets the instance of <see cref="ApplicationDbContext"/> to use.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; }

        /// <summary>
        /// Gets the instance of  <see cref="ILogger{GetCartByIdQueryHandler}"/> to use.
        /// </summary>
        private ILogger<GetCartByIdQueryHandler> Logger { get; } = Mock.Of<ILogger<GetCartByIdQueryHandler>>();

        /// <summary>
        /// Gets the instance of <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; } = Mock.Of<IMapper>();

        /// <summary>
        /// A test for <see cref="GetCartByIdQueryHandler.Handle(GetCartByIdQuery, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle()
        {
            var getCartByIdQuery = Mock.Of<GetCartByIdQuery>(q =>
                q.Id == 1 &&
                q.UserId == 1);

            var clotheEntity = Mock.Of<Clothe>(q =>
                q.Id == getCartByIdQuery.UserId &&
                q.Description == string.Empty &&
                q.ImageName == string.Empty &&
                q.ImagePath == string.Empty &&
                q.Name == string.Empty &&
                q.Price == new decimal(new Random().NextDouble()) &&
                q.IsActive == true);
            var userEntity = Mock.Of<User>(q =>
                q.Id == getCartByIdQuery.UserId &&
                q.IsActive == true &&
                q.UserName == "TestNorth" &&
                q.NormalizedUserName == "TESTNORTH" &&
                q.Email == "test@gmail.com" &&
                q.NormalizedEmail == "TEST@gmail.com" &&
                q.FirstName == "Test" &&
                q.LastName == "Last");

            var cartEntity = Mock.Of<Cart>(q =>
                q.Name == "Test" &&
                q.Price == new decimal(new Random().NextDouble()) &&
                q.Amount == 5 &&
                q.User == userEntity &&
                q.Clothe == clotheEntity);

            var response = Mock.Of<Result<CartResponse>>(x =>
                x.Successful == true &&
                x.Error == null &&
                x.Items == null &&
                x.Item == new CartResponse());

            this.ApplicationDbContext.Carts.Add(cartEntity);
            await this.ApplicationDbContext.SaveChangesAsync(default);

            var result = await this.SUT.Handle(getCartByIdQuery, default);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Equal(result.Error, response.Error);
            Assert.Equal(result.Items, response.Items);
            Assert.Equal(result.Item, response.Item);

            //Assert.Equal(clotheEntity.Description, clotheEntityDb.Description);
            //Assert.Equal(clotheEntity.ImagePath, clotheEntityDb.ImagePath);
            //Assert.Equal(clotheEntity.ImageName, clotheEntityDb.ImageName);
            //Assert.Equal(clotheEntity.Name, clotheEntityDb.Name);
            //Assert.Equal(clotheEntity.Price, clotheEntityDb.Price);
            //Assert.Equal(clotheEntity.IsActive, clotheEntityDb.IsActive);
        }

        /// <summary>
        /// A test for <see cref="GetCartByIdQueryHandler.Handle(GetCartByIdQuery, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == false &&
                x.Error == ErrorsManager.GetCartByIdQuery &&
                x.EntityId == 0);

            var result = await this.SUT.Handle(It.IsAny<GetCartByIdQuery>(), default);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Contains(response.Error, result.Error);
        }

        /// <summary>
        /// Ensure garbage collector for db context.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Ensure the context is reset.
        /// </summary>
        /// <param name="disposing">A value indicating whether the class is disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            this.ApplicationDbContext.Database.EnsureDeleted();
        }
    }
}
