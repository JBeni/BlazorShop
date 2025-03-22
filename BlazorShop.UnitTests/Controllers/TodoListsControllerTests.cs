// <copyright file="TodoListsControllerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="TodoListsController"/> class.
    /// </summary>
    public class TodoListsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly TodoListsController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoListsControllerTests"/> class.
        /// </summary>
        public TodoListsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new TodoListsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateTodoList_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new CreateTodoListCommand 
            { 
                Title = "Test List",
                Description = "Test Description",
                UserId = 1
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateTodoListCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.CreateTodoList(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
            _mediatorMock.Verify(m => m.Send(It.IsAny<CreateTodoListCommand>(), default), Times.Once);
        }

        [Fact]
        public async Task GetTodoListById_ExistingList_ReturnsOkResult()
        {
            // Arrange
            var listId = 1;
            var todoListDto = new TodoListDto 
            { 
                Id = listId, 
                Title = "Test List",
                UserId = 1
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetTodoListByIdQuery>(), default))
                .ReturnsAsync(todoListDto);

            // Act
            var result = await _controller.GetTodoListById(listId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedList = Assert.IsType<TodoListDto>(okResult.Value);
            Assert.Equal(listId, returnedList.Id);
            _mediatorMock.Verify(m => m.Send(It.Is<GetTodoListByIdQuery>(q => q.Id == listId), default), Times.Once);
        }

        [Fact]
        public async Task GetTodoLists_ReturnsListOfTodoLists()
        {
            // Arrange
            var todoLists = new List<TodoListDto> 
            { 
                new TodoListDto { Id = 1, Title = "List 1", UserId = 1 },
                new TodoListDto { Id = 2, Title = "List 2", UserId = 1 }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetTodoListsQuery>(), default))
                .ReturnsAsync(todoLists);

            // Act
            var result = await _controller.GetTodoLists();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedLists = Assert.IsType<List<TodoListDto>>(okResult.Value);
            Assert.Equal(2, returnedLists.Count);
            _mediatorMock.Verify(m => m.Send(It.IsAny<GetTodoListsQuery>(), default), Times.Once);
        }

        [Fact]
        public async Task GetUserTodoLists_ReturnsUserSpecificLists()
        {
            // Arrange
            var userId = 1;
            var todoLists = new List<TodoListDto> 
            { 
                new TodoListDto { Id = 1, Title = "List 1", UserId = userId },
                new TodoListDto { Id = 2, Title = "List 2", UserId = userId }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetUserTodoListsQuery>(), default))
                .ReturnsAsync(todoLists);

            // Act
            var result = await _controller.GetUserTodoLists(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedLists = Assert.IsType<List<TodoListDto>>(okResult.Value);
            Assert.All(returnedLists, list => Assert.Equal(userId, list.UserId));
            _mediatorMock.Verify(m => m.Send(It.Is<GetUserTodoListsQuery>(q => q.UserId == userId), default), Times.Once);
        }

        [Fact]
        public async Task UpdateTodoList_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new UpdateTodoListCommand 
            { 
                Id = 1,
                Title = "Updated List",
                Description = "Updated Description"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateTodoListCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.UpdateTodoList(command);

            // Assert
            Assert.IsType<OkResult>(result);
            _mediatorMock.Verify(m => m.Send(command, default), Times.Once);
        }

        [Fact]
        public async Task DeleteTodoList_ExistingList_ReturnsOkResult()
        {
            // Arrange
            var listId = 1;
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteTodoListCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.DeleteTodoList(listId);

            // Assert
            Assert.IsType<OkResult>(result);
            _mediatorMock.Verify(m => m.Send(It.Is<DeleteTodoListCommand>(c => c.Id == listId), default), Times.Once);
        }

        [Fact]
        public async Task GetTodoList_NonExistingList_ReturnsNotFound()
        {
            // Arrange
            var listId = 999;
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetTodoListByIdQuery>(), default))
                .ReturnsAsync((TodoListDto)null);

            // Act
            var result = await _controller.GetTodoListById(listId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreateTodoList_InvalidCommand_ReturnsBadRequest()
        {
            // Arrange
            var command = new CreateTodoListCommand(); // Invalid command with no data
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateTodoListCommand>(), default))
                .ReturnsAsync(Result.Failure("Invalid data"));

            // Act
            var result = await _controller.CreateTodoList(command);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.NotNull(badRequestResult.Value);
        }

        [Fact]
        public async Task UpdateTodoList_NonExistingList_ReturnsNotFound()
        {
            // Arrange
            var command = new UpdateTodoListCommand { Id = 999 };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateTodoListCommand>(), default))
                .ReturnsAsync(Result.Failure("List not found"));

            // Act
            var result = await _controller.UpdateTodoList(command);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
