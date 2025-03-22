// <copyright file="ClothesControllerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="ClothesController"/> class.
    /// </summary>
    public class ClothesControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly ClothesController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClothesControllerTests"/> class.
        /// </summary>
        public ClothesControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new ClothesController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateClothes_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new CreateClothesCommand 
            { 
                Name = "Test Clothes",
                Description = "Test Description",
                Price = 99.99m
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateClothesCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.CreateClothes(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task GetClothesById_ExistingClothes_ReturnsOkResult()
        {
            // Arrange
            var clothesId = 1;
            var clothesDto = new ClothesDto { Id = clothesId, Name = "Test Clothes" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetClothesByIdQuery>(), default))
                .ReturnsAsync(clothesDto);

            // Act
            var result = await _controller.GetClothesById(clothesId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedClothes = Assert.IsType<ClothesDto>(okResult.Value);
            Assert.Equal(clothesId, returnedClothes.Id);
        }

        [Fact]
        public async Task GetClothes_ReturnsListOfClothes()
        {
            // Arrange
            var clothesList = new List<ClothesDto> 
            { 
                new ClothesDto { Id = 1, Name = "Clothes 1" },
                new ClothesDto { Id = 2, Name = "Clothes 2" }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetClothesQuery>(), default))
                .ReturnsAsync(clothesList);

            // Act
            var result = await _controller.GetClothes();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedClothes = Assert.IsType<List<ClothesDto>>(okResult.Value);
            Assert.Equal(2, returnedClothes.Count);
        }

        [Fact]
        public async Task UpdateClothes_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new UpdateClothesCommand 
            { 
                Id = 1, 
                Name = "Updated Clothes",
                Price = 149.99m
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateClothesCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.UpdateClothes(command);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteClothes_ExistingClothes_ReturnsOkResult()
        {
            // Arrange
            var clothesId = 1;
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteClothesCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.DeleteClothes(clothesId);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
