// <copyright file="TodoListsControllerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Controllers
{
    /// <summary>
    /// Tests for <see cref="TodoListsController"/> class.
    /// </summary>
    public class TodoListsControllerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TodoListsControllerTests"/> class.
        /// </summary>
        public TodoListsControllerTests()
        {
            this.TodoListsController = new TodoListsController(this.Mediator);
        }

        /// <summary>
        /// Gets the instance of the <see cref="TodoListsController"/> to use.
        /// </summary>
        private TodoListsController TodoListsController { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IMediator"/> to use.
        /// </summary>
        private IMediator Mediator { get; } = Mock.Of<IMediator>();

        /// <summary>
        /// A test for <see cref="TodoListsController.CreateTodoList(CreateTodoListCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateTodoList()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="TodoListsController.UpdateTodoList(UpdateTodoListCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTodoList()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="TodoListsController.DeleteTodoList(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteTodoList()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="TodoListsController.GetTodoListById(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetTodoListById()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="TodoListsController.GetTodoLists()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetTodoLists()
        {
            await Task.CompletedTask;
        }
    }
}
