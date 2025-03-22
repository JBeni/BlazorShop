// <copyright file="TodoItemsControllerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="TodoItemsController"/> class.
    /// </summary>
    public class TodoItemsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly TodoItemsController _controller;

        public TodoItemsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new TodoItemsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateTodoItem_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new CreateTodoItemCommand 
            { 
                ListId = 1,
                Title = "Test Item",
                Description = "Test Description"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateTodoItemCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.CreateTodoItem(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task GetTodoItemById_ExistingItem_ReturnsOkResult()
        {
            // Arrange
            var itemId = 1;
            var itemDto = new TodoItemDto { Id = itemId, Title = "Test Item" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetTodoItemByIdQuery>(), default))
                .ReturnsAsync(itemDto);

            // Act
            var result = await _controller.GetTodoItemById(itemId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedItem = Assert.IsType<TodoItemDto>(okResult.Value);
            Assert.Equal(itemId, returnedItem.Id);
        }

        [Fact]
        public async Task GetTodoItems_ReturnsListOfItems()
        {
            // Arrange
            var items = new List<TodoItemDto> 
            { 
                new TodoItemDto { Id = 1, Title = "Item 1" },
                new TodoItemDto { Id = 2, Title = "Item 2" }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetTodoItemsQuery>(), default))
                .ReturnsAsync(items);

            // Act
            var result = await _controller.GetTodoItems();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedItems = Assert.IsType<List<TodoItemDto>>(okResult.Value);
            Assert.Equal(2, returnedItems.Count);
        }

        [Fact]
        public async Task UpdateTodoItem_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new UpdateTodoItemCommand 
            { 
                Id = 1,
                Title = "Updated Item",
                Done = true
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateTodoItemCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.UpdateTodoItem(command);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteTodoItem_ExistingItem_ReturnsOkResult()
        {
            // Arrange
            var itemId = 1;
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteTodoItemCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.DeleteTodoItem(itemId);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
