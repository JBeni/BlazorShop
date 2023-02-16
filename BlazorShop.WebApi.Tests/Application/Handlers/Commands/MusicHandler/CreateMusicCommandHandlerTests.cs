// <copyright file="CreateMusicCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Tests.Application.Handlers.Commands.MusicHandler
{
    /// <summary>
    /// Tests for <see cref="CreateMusicCommandHandler"/> class.
    /// </summary>
    public class CreateMusicCommandHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMusicCommandHandlerTests"/> class.
        /// </summary>
        public CreateMusicCommandHandlerTests()
        {
        }

        /// <summary>
        /// Gets the <see cref="CreateMusicCommandHandler"/> instance to use.
        /// </summary>
        private CreateMusicCommandHandler SUT { get; }

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
        /// Gets the <see cref="ILogger{CreateMusicCommandHandler}"/> under test.
        /// </summary>
        private ILogger<CreateMusicCommandHandler> Logger { get; }

        /// <summary>
        /// A test for <see cref="CreateMusicCommandHandler.Handle(CreateMusicCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="CreateMusicCommandHandler.Handle(CreateMusicCommand, CancellationToken)"/> method.
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
