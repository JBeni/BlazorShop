// <copyright file="MusicsControllerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="MusicsController"/> class.
    /// </summary>
    public class MusicsControllerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MusicsControllerTests"/> class.
        /// </summary>
        public MusicsControllerTests()
        {
            this.MusicsController = new MusicsController(this.Mediator);
        }

        /// <summary>
        /// Gets the instance of the <see cref="MusicsController"/> to use.
        /// </summary>
        private MusicsController MusicsController { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IMediator"/> to use.
        /// </summary>
        private IMediator Mediator { get; } = Mock.Of<IMediator>();

        /// <summary>
        /// A test for <see cref="MusicsController.CreateMusic(CreateMusicCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateMusic()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="MusicsController.UpdateMusic(UpdateMusicCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateMusic()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="MusicsController.DeleteMusic(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteMusic()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="MusicsController.GetMusic(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetMusic()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="MusicsController.GetMusics()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetMusics()
        {
            await Task.CompletedTask;
        }
    }
}
