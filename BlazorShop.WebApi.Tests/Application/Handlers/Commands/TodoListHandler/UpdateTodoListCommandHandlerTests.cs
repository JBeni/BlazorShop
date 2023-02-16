// <copyright file="UpdateTodoListCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Tests.Application.Handlers.Commands.TodoListHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateTodoListCommandHandler"/> class.
    /// </summary>
    public class UpdateTodoListCommandHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTodoListCommandHandlerTests"/> class.
        /// </summary>
        public UpdateTodoListCommandHandlerTests()
        {
        }

        /// <summary>
        /// Gets the <see cref="UpdateTodoListCommandHandler"/> instance to use.
        /// </summary>
        private UpdateTodoListCommandHandler SUT { get; }

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
        /// Gets the <see cref="ILogger{UpdateTodoListCommandHandler}"/> under test.
        /// </summary>
        private ILogger<UpdateTodoListCommandHandler> Logger { get; }

        /// <summary>
        /// A test for <see cref="UpdateTodoListCommandHandler.Handle(UpdateTodoListCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UpdateTodoListCommandHandler.Handle(UpdateTodoListCommand, CancellationToken)"/> method.
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
