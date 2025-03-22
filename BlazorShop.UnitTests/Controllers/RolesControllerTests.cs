// <copyright file="RolesControllerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="RolesController"/> class.
    /// </summary>
    public class RolesControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly RolesController _controller;

        public RolesControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new RolesController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateRole_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new CreateRoleCommand 
            { 
                Name = "TestRole",
                Description = "Test Role Description"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateRoleCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.CreateRole(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task GetRoleById_ExistingRole_ReturnsOkResult()
        {
            // Arrange
            var roleId = 1;
            var roleDto = new RoleDto { Id = roleId, Name = "TestRole" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetRoleByIdQuery>(), default))
                .ReturnsAsync(roleDto);

            // Act
            var result = await _controller.GetRoleById(roleId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedRole = Assert.IsType<RoleDto>(okResult.Value);
            Assert.Equal(roleId, returnedRole.Id);
        }

        [Fact]
        public async Task GetRoles_ReturnsListOfRoles()
        {
            // Arrange
            var roles = new List<RoleDto> 
            { 
                new RoleDto { Id = 1, Name = "Admin" },
                new RoleDto { Id = 2, Name = "User" }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetRolesQuery>(), default))
                .ReturnsAsync(roles);

            // Act
            var result = await _controller.GetRoles();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedRoles = Assert.IsType<List<RoleDto>>(okResult.Value);
            Assert.Equal(2, returnedRoles.Count);
        }

        [Fact]
        public async Task UpdateRole_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new UpdateRoleCommand 
            { 
                Id = 1,
                Name = "UpdatedRole",
                Description = "Updated Description"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateRoleCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.UpdateRole(command);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteRole_ExistingRole_ReturnsOkResult()
        {
            // Arrange
            var roleId = 1;
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteRoleCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.DeleteRole(roleId);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
