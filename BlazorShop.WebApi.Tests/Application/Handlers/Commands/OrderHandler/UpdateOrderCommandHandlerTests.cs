// <copyright file="UpdateOrderCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.OrderHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateOrderCommandHandler"/> class.
    /// </summary>
    public class UpdateOrderCommandHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateOrderCommandHandlerTests"/> class.
        /// </summary>
        public UpdateOrderCommandHandlerTests()
        {
        }

        /// <summary>
        /// Gets the <see cref="UpdateOrderCommandHandler"/> instance to use.
        /// </summary>
        private UpdateOrderCommandHandler SUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="Microsoft.Extensions.DependencyInjection.ServiceProvider"/> to use.
        /// </summary>
        private ServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Gets the <see cref="ApplicationDbContext"/> under test.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; }

        /// <summary>
        /// Gets the <see cref="IUserStore{User}"/> under test.
        /// </summary>
        private IUserStore<User> UserStore { get; }

        /// <summary>
        /// Gets the <see cref="UserManager{User}"/> under test.
        /// </summary>
        private UserManager<User> UserManager { get; }

        /// <summary>
        /// Gets the <see cref="ILogger{UpdateOrderCommandHandler}"/> under test.
        /// </summary>
        private ILogger<UpdateOrderCommandHandler> Logger { get; }

        /// <summary>
        /// A test for <see cref="UpdateOrderCommandHandler.Handle(UpdateOrderCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UpdateOrderCommandHandler.Handle(UpdateOrderCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// Ensure garbage collector for db context.
        /// </summary>
        public void Dispose()
        {
            // this.ApplicationDbContext.Database.EnsureDeleted();
            GC.SuppressFinalize(this);
        }
    }
}
