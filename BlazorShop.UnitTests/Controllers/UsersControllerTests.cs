// <copyright file="UsersControllerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="UsersController"/> class.
    /// </summary>
    public class UsersControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly UsersController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersControllerTests"/> class.
        /// </summary>
        public UsersControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new UsersController(_mediatorMock.Object);
        }

        /// <summary>
        /// A test for <see cref="UsersController.CreateUser(CreateUserCommand)"/> method.
        /// </summary>
        [Fact]
        public async Task CreateUser_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new CreateUserCommand 
            { 
                Email = "test@example.com",
                UserName = "testuser",
                Password = "Password123!"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateUserCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.CreateUser(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
            _mediatorMock.Verify(m => m.Send(It.IsAny<CreateUserCommand>(), default), Times.Once);
        }

        /// <summary>
        /// A test for <see cref="UsersController.GetUserById(int)"/> method.
        /// </summary>
        [Fact]
        public async Task GetUserById_ExistingUser_ReturnsOkResult()
        {
            // Arrange
            var userId = 1;
            var userDto = new UserDto { Id = userId, Email = "test@example.com" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(), default))
                .ReturnsAsync(userDto);

            // Act
            var result = await _controller.GetUserById(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUser = Assert.IsType<UserDto>(okResult.Value);
            Assert.Equal(userId, returnedUser.Id);
        }

        /// <summary>
        /// A test for <see cref="UsersController.GetUsers()"/> method.
        /// </summary>
        [Fact]
        public async Task GetUsers_ReturnsListOfUsers()
        {
            // Arrange
            var users = new List<UserDto> 
            { 
                new UserDto { Id = 1, Email = "user1@example.com" },
                new UserDto { Id = 2, Email = "user2@example.com" }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetUsersQuery>(), default))
                .ReturnsAsync(users);

            // Act
            var result = await _controller.GetUsers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUsers = Assert.IsType<List<UserDto>>(okResult.Value);
            Assert.Equal(2, returnedUsers.Count);
        }

        /// <summary>
        /// A test for <see cref="UsersController.DeleteUser(int)"/> method.
        /// </summary>
        [Fact]
        public async Task DeleteUser_ExistingUser_ReturnsOkResult()
        {
            // Arrange
            var userId = 1;
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteUserCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.DeleteUser(userId);

            // Assert
            Assert.IsType<OkResult>(result);
            _mediatorMock.Verify(m => m.Send(It.Is<DeleteUserCommand>(c => c.Id == userId), default), Times.Once);
        }

        /// <summary>
        /// A test for <see cref="UsersController.UpdateUser(UpdateUserCommand)"/> method.
        /// </summary>
        [Fact]
        public async Task UpdateUser_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new UpdateUserCommand { Id = 1, Email = "updated@example.com" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateUserCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.UpdateUser(command);

            // Assert
            Assert.IsType<OkResult>(result);
            _mediatorMock.Verify(m => m.Send(command, default), Times.Once);
        }

        /// <summary>
        /// A test for <see cref="UsersController.ActivateUser(ActivateUserCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task ActivateUser()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UsersController.UpdateUserEmail(UpdateUserEmailCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUserEmail()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UsersController.GetUsersInactive()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetUsersInactive()
        {
            await Task.CompletedTask;
        }
    }
}
