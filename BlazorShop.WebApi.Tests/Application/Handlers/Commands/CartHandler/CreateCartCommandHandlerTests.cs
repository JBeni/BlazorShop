// <copyright file="CreateCartCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Handlers.Commands.CartHandler;
using Moq;
using Xunit;

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.CartHandler
{
    /// <summary>
    /// Tests for <see cref="CreateCartCommandHandler"/> class.
    /// </summary>
    public class CreateCartCommandHandlerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCartCommandHandlerTests"/> class.
        /// </summary>
        public CreateCartCommandHandlerTests()
        {
            this.SUT = new CreateCartCommandHandler(
                this.DbContext,
                this.Logger,
                this.UserManager);
        }

        /// <summary>
        /// Gets the <see cref="CreateCartCommandHandler"/> instance to use.
        /// </summary>
        private CreateCartCommandHandler SUT { get; }

        /// <summary>
        /// Gets the <see cref="IApplicationDbContext"/> instance to use.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets the <see cref="UserManager{User}"/> under test.
        /// </summary>
        private UserManager<User> UserManager { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IAccountService"/> to use.
        /// </summary>
        private IAccountService AccountService { get; } = Mock.Of<IAccountService>();

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

            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == true &&
                x.Error == string.Empty &&
                x.EntityId == 0);

            //Mock.Get(this.DbContext)
            //    .Setup(x => x.Carts(createCartCommand))
            //    .ReturnsAsync(response);

            var result = await this.SUT.Handle(createCartCommand, default);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Equal(result.Error, response.Error);
            Assert.Equal(result.EntityId, response.EntityId);
        }

        /// <summary>
        /// A test for <see cref="ResetPasswordCommandHandler.Handle(CreateCartCommand, CancellationToken)"/> method.
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
            Assert.Equal(result.EntityId, response.EntityId);
        }
    }
}
