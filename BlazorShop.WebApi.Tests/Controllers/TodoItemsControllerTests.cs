// <copyright file="TodoItemsControllerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Tests.Controllers
{
    /// <summary>
    /// Tests for <see cref="TodoItemsController"/> class.
    /// </summary>
    public class TodoItemsControllerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TodoItemsControllerTests"/> class.
        /// </summary>
        public TodoItemsControllerTests()
        {
            this.TodoItemsController = new TodoItemsController(this.Mediator);
        }

        /// <summary>
        /// Gets the instance of the <see cref="TodoItemsController"/> to use.
        /// </summary>
        private TodoItemsController TodoItemsController { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IMediator"/> to use.
        /// </summary>
        private IMediator Mediator { get; } = Mock.Of<IMediator>();

        /// <summary>
        /// A test for <see cref="TodoItemsController.CreateTodoItem(CreateTodoItemCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateTodoItem()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="TodoItemsController.UpdateTodoItem(UpdateTodoItemCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTodoItem()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="TodoItemsController.DeleteTodoItem(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteTodoItem()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="TodoItemsController.GetTodoItemById(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetTodoItemById()
        {
            await Task.CompletedTask;
        }
    }
}
