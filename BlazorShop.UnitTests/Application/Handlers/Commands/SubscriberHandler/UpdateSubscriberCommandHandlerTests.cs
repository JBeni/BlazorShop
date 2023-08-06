// <copyright file="UpdateSubscriberCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Application.Handlers.Commands.SubscriberHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateSubscriberCommandHandler"/> class.
    /// </summary>
    public class UpdateSubscriberCommandHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriberCommandHandlerTests"/> class.
        /// </summary>
        public UpdateSubscriberCommandHandlerTests()
        {
        }

        /// <summary>
        /// Gets the <see cref="UpdateSubscriberCommandHandler"/> instance to use.
        /// </summary>
        private UpdateSubscriberCommandHandler SUT { get; }

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
        /// Gets the <see cref="ILogger{UpdateSubscriberCommandHandler}"/> under test.
        /// </summary>
        private ILogger<UpdateSubscriberCommandHandler> Logger { get; }

        /// <summary>
        /// A test for <see cref="UpdateSubscriberCommandHandler.Handle(UpdateSubscriberCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UpdateSubscriberCommandHandler.Handle(UpdateSubscriberCommand, CancellationToken)"/> method.
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
