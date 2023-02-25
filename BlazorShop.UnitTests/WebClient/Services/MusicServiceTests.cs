// <copyright file="MusicServiceTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using MusicService = BlazorShop.WebClient.Services.MusicService;

namespace BlazorShop.UnitTests.WebClient.Services
{
    /// <summary>
    /// Tests for <see cref="BlazorShop.WebClient.Services.MusicService"/> class.
    /// </summary>
    public class MusicServiceTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MusicServiceTests"/> class.
        /// </summary>
        public MusicServiceTests()
        {
            this.MusicService = new MusicService(
                this.HttpClient,
                this.SnackBar);
        }

        /// <summary>
        /// Gets the instance of the <see cref="MusicService"/> to use.
        /// </summary>
        private MusicService MusicService { get; }

        /// <summary>
        /// Gets the instance of the <see cref="HttpClient"/> to use.
        /// </summary>
        private HttpClient HttpClient { get; } = Mock.Of<HttpClient>();

        /// <summary>
        /// Gets the instance of the <see cref="ISnackbar"/> to use.
        /// </summary>
        private ISnackbar SnackBar { get; } = Mock.Of<ISnackbar>();

        /// <summary>
        /// Gets the instance of the <see cref="JsonSerializerOptions"/> to use.
        /// </summary>
        private JsonSerializerOptions Options { get; }

        /// <summary>
        /// A test for <see cref="MusicService.GetMusics()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetMusics()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="MusicService.GetMusic(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetMusic()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="MusicService.AddMusic(MusicResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task AddMusic()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="MusicService.UpdateMusic(MusicResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateMusic()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="MusicService.DeleteMusic(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteMusic()
        {
            await Task.CompletedTask;
        }
    }
}
