// <copyright file="ReceiptsControllerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.WebApi.Controllers;
using Moq;
using Xunit;

namespace BlazorShop.WebApi.Tests.Controllers
{
    /// <summary>
    /// Tests for <see cref="ReceiptsController"/> class.
    /// </summary>
    public class ReceiptsControllerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptsControllerTests"/> class.
        /// </summary>
        public ReceiptsControllerTests()
        {
            this.ReceiptsController = new ReceiptsController(this.Mediator);
        }

        /// <summary>
        /// Gets the instance of the <see cref="ReceiptsController"/> to use.
        /// </summary>
        private ReceiptsController ReceiptsController { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IMediator"/> to use.
        /// </summary>
        private IMediator Mediator { get; } = Mock.Of<IMediator>();

        /// <summary>
        /// A test for <see cref="ReceiptsController.CreateReceipt(CreateReceiptCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Fact]
        public async Task CreateReceipt()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="ReceiptsController.UpdateReceipt(UpdateReceiptCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateReceipt()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="ReceiptsController.DeleteReceipt(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteReceipt()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="ReceiptsController.GetReceipts(string)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetReceipt()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="ReceiptsController.GetReceipts(string)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetReceipts()
        {
            await Task.CompletedTask;
        }
    }
}
