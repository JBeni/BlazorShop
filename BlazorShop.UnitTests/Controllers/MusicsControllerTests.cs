// <copyright file="MusicsControllerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="MusicsController"/> class.
    /// </summary>
    public class MusicsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly MusicsController _controller;

        public MusicsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new MusicsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateMusic_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new CreateMusicCommand 
            { 
                Title = "Test Song",
                Artist = "Test Artist",
                Price = 0.99m
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateMusicCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.CreateMusic(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task GetMusicById_ExistingMusic_ReturnsOkResult()
        {
            // Arrange
            var musicId = 1;
            var musicDto = new MusicDto { Id = musicId, Title = "Test Song" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetMusicByIdQuery>(), default))
                .ReturnsAsync(musicDto);

            // Act
            var result = await _controller.GetMusicById(musicId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedMusic = Assert.IsType<MusicDto>(okResult.Value);
            Assert.Equal(musicId, returnedMusic.Id);
        }

        [Fact]
        public async Task GetMusics_ReturnsListOfMusics()
        {
            // Arrange
            var musics = new List<MusicDto> 
            { 
                new MusicDto { Id = 1, Title = "Song 1" },
                new MusicDto { Id = 2, Title = "Song 2" }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetMusicsQuery>(), default))
                .ReturnsAsync(musics);

            // Act
            var result = await _controller.GetMusics();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedMusics = Assert.IsType<List<MusicDto>>(okResult.Value);
            Assert.Equal(2, returnedMusics.Count);
        }

        [Fact]
        public async Task UpdateMusic_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new UpdateMusicCommand 
            { 
                Id = 1,
                Title = "Updated Song",
                Price = 1.99m
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateMusicCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.UpdateMusic(command);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteMusic_ExistingMusic_ReturnsOkResult()
        {
            // Arrange
            var musicId = 1;
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteMusicCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.DeleteMusic(musicId);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
