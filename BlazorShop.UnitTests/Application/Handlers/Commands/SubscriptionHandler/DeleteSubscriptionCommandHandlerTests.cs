// <copyright file="DeleteSubscriptionCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Application.Handlers.Commands.SubscriptionHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteSubscriptionCommandHandler"/> class.
    /// </summary>
    public class DeleteSubscriptionCommandHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSubscriptionCommandHandlerTests"/> class.
        /// </summary>
        public DeleteSubscriptionCommandHandlerTests()
        {
        }

        /// <summary>
        /// Gets the <see cref="DeleteSubscriptionCommandHandler"/> instance to use.
        /// </summary>
        private DeleteSubscriptionCommandHandler SUT { get; }

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
        /// Gets the <see cref="ILogger{DeleteSubscriptionCommandHandler}"/> under test.
        /// </summary>
        private ILogger<DeleteSubscriptionCommandHandler> Logger { get; }

        /// <summary>
        /// A test for <see cref="DeleteSubscriptionCommandHandler.Handle(DeleteSubscriptionCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="DeleteSubscriptionCommandHandler.Handle(DeleteSubscriptionCommand, CancellationToken)"/> method.
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
