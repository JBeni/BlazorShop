// <copyright file="CreateCartCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Handlers.Commands.CartHandler;
using BlazorShop.Infrastructure.Persistence;
using Moq;
using Xunit;

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.CartHandler
{
    /// <summary>
    /// Tests for <see cref="CreateCartCommandHandler"/> class.
    /// </summary>
    public class CreateCartCommandHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCartCommandHandlerTests"/> class.
        /// </summary>
        public CreateCartCommandHandlerTests()
        {
            this.ApplicationDbContext = new ApplicationDbContext(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: $"ApplicationDbContext-Core")
                    .Options);

            var userStore = Mock.Of<IUserStore<User>>();
            this.UserManager = new UserManager<User>(userStore, null, null, null, null, null, null, null, null);

            // Create a UserManager<User> instance
            // this.UserManager = new UserManager<User>(mockUserStore.Object, options, new PasswordHasher<User>(),
            //    new IUserValidator<User>[] { new UserValidator<User>() },
            //    new IPasswordValidator<User>[] { new PasswordValidator<User>() },
            //    new UpperInvariantLookupNormalizer(),
            //    new IdentityErrorDescriber(),
            //    null,
            //    new Mock<ILogger<UserManager<User>>>().Object);

            this.SUT = new CreateCartCommandHandler(
                this.ApplicationDbContext,
                this.Logger,
                this.UserManager);
        }

        /// <summary>
        /// Gets the <see cref="CreateCartCommandHandler"/> instance to use.
        /// </summary>
        private CreateCartCommandHandler SUT { get; }

        /// <summary>
        /// Gets the <see cref="ApplicationDbContext"/> under test.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; }

        /// <summary>
        /// Gets the <see cref="UserManager{User}"/> under test.
        /// </summary>
        private UserManager<User> UserManager { get; }

        /// <summary>
        /// Gets the <see cref="ILogger{CreateCartCommandHandler}"/> under test.
        /// </summary>
        private ILogger<CreateCartCommandHandler> Logger { get; } = Mock.Of<ILogger<CreateCartCommandHandler>>();

        /// <summary>
        /// A test for <see cref="CreateCartCommandHandler.Handle(CreateCartCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        [Fact]
        public async Task Handle()
        {
            var createCartCommand = Mock.Of<CreateCartCommand>(x =>
                x.UserId == new Random().Next() &&
                x.ClotheId == new Random().Next() &&
                x.Name == "test" &&
                x.Price == new decimal(new Random().NextDouble()) &&
                x.Amount == new Random().Next());
            var clotheEntity = Mock.Of<Clothe>(q =>
                q.Id == createCartCommand.ClotheId &&
                q.Description == string.Empty &&
                q.ImageName == string.Empty &&
                q.ImagePath == string.Empty &&
                q.Name == string.Empty &&
                q.Price == new decimal(new Random().NextDouble()) &&
                q.IsActive == true);
            var userEntity = Mock.Of<User>(q =>
                q.Id == createCartCommand.UserId &&
                q.IsActive == true &&
                q.UserName == "TestNorth" &&
                q.Email == "test@gmail.com" &&
                q.FirstName == "Test" &&
                q.LastName == "Last" &&
                q.NormalizedEmail == "TEST@gmail.com" &&
                q.NormalizedUserName == "TESTNORTH");

            //Mock.Get(this.UserManager)
            //    .Setup(x => x.FindByIdAsync(createCartCommand.UserId.ToString()))
            //    .ReturnsAsync(userEntity);

            var cartEntity = Mock.Of<Cart>(w =>
                w.Name == createCartCommand.Name &&
                w.Price == createCartCommand.Price &&
                w.Amount == createCartCommand.Amount &&
                w.User == userEntity &&
                w.Clothe == clotheEntity);

            this.ApplicationDbContext.Clothes.Add(clotheEntity);
            // this.ApplicationDbContext.Carts.Add(cartEntity);
            await this.ApplicationDbContext.SaveChangesAsync(default);

            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == true &&
                x.Error == string.Empty &&
                x.EntityId == 0);

            //var result = await this.SUT.Handle(createCartCommand, default);

            //Assert.Equal(result.Successful, response.Successful);
            //Assert.Equal(result.Error, response.Error);
        }

        /// <summary>
        /// A test for <see cref="CreateCartCommandHandler.Handle(CreateCartCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == false &&
                x.Error == ErrorsManager.CreateCartCommand &&
                x.EntityId == 0);

            //Mock.Get(this.AccountService)
            //    .Setup(x => x.ResetPasswordUserAsync(It.IsAny<CreateCartCommand>()))
            //    .ThrowsAsync(new Exception());

            var result = await this.SUT.Handle(It.IsAny<CreateCartCommand>(), default);

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
