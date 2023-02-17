// <copyright file="WorkerServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.WorkerService
{
    /// <summary>
    /// Tests for <see cref="Worker"/> class.
    /// </summary>
    public class WorkerServiceTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkerServiceTests"/> class.
        /// </summary>
        public WorkerServiceTests()
        {
            this.Worker = new Worker(
                this.Logger,
                this.ServiceScopeFactory,
                this.HttpClient);
        }

        /// <summary>
        /// Gets the instance of the <see cref="Worker"/> to use.
        /// </summary>
        private Worker Worker { get; }

        /// <summary>
        /// Gets the instance of the <see cref="ILogger{Worker}"/> to use.
        /// </summary>
        private ILogger<Worker> Logger { get; } = Mock.Of<ILogger<Worker>>();

        /// <summary>
        /// Gets the instance of the <see cref="IServiceScopeFactory"/> to use.
        /// </summary>
        private IServiceScopeFactory ServiceScopeFactory { get; }

        /// <summary>
        /// Gets the instance of the <see cref="HttpClient"/> to use.
        /// </summary>
        private HttpClient HttpClient { get; } = Mock.Of<HttpClient>();

        /// <summary>
        /// A test for <see cref="Worker.ExecuteAsync(CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task ExecuteAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="Worker.ExecuteAsync(CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task ExecuteAsync_ThrowException()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="Worker.ExecuteAsync(CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task ExecuteAsync_TryToSaveDuplicateData()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="Worker.ExecuteAsync(CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task ExecuteAsync_EnsureDatabase()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// Ensure garbage collector.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
