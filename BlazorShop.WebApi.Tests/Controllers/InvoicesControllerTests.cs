// <copyright file="InvoicesControllerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Tests.Controllers
{
    /// <summary>
    /// Tests for <see cref="InvoicesController"/> class.
    /// </summary>
    public class InvoicesControllerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoicesControllerTests"/> class.
        /// </summary>
        public InvoicesControllerTests()
        {
            this.InvoicesController = new InvoicesController(this.Mediator);
        }

        /// <summary>
        /// Gets the instance of the <see cref="InvoicesController"/> to use.
        /// </summary>
        private InvoicesController InvoicesController { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IMediator"/> to use.
        /// </summary>
        private IMediator Mediator { get; } = Mock.Of<IMediator>();

        /// <summary>
        /// A test for <see cref="InvoicesController.CreateInvoice(CreateInvoiceCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateInvoice()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="InvoicesController.UpdateInvoice(UpdateInvoiceCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateInvoice()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="InvoicesController.DeleteInvoice(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteInvoice()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="InvoicesController.GetInvoice(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetInvoice()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="InvoicesController.GetInvoices()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetInvoices()
        {
            await Task.CompletedTask;
        }
    }
}
