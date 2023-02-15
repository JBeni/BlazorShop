// <copyright file="UpdateInvoiceCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.InvoiceHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateInvoiceCommandHandler"/> class.
    /// </summary>
    public class UpdateInvoiceCommandHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateInvoiceCommandHandlerTests"/> class.
        /// </summary>
        public UpdateInvoiceCommandHandlerTests()
        {
        }

        /// <summary>
        /// Gets the <see cref="UpdateInvoiceCommandHandler"/> instance to use.
        /// </summary>
        private UpdateInvoiceCommandHandler SUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="Microsoft.Extensions.DependencyInjection.ServiceProvider"/> to use.
        /// </summary>
        private ServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Gets the <see cref="ApplicationDbContext"/> under test.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; }

        /// <summary>
        /// Gets the <see cref="IUserStore{User}"/> under test.
        /// </summary>
        private IUserStore<User> UserStore { get; }

        /// <summary>
        /// Gets the <see cref="UserManager{User}"/> under test.
        /// </summary>
        private UserManager<User> UserManager { get; }

        /// <summary>
        /// Gets the <see cref="ILogger{UpdateInvoiceCommandHandler}"/> under test.
        /// </summary>
        private ILogger<UpdateInvoiceCommandHandler> Logger { get; }

        /// <summary>
        /// A test for <see cref="UpdateInvoiceCommandHandler.Handle(UpdateInvoiceCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UpdateInvoiceCommandHandler.Handle(UpdateInvoiceCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// Ensure garbage collector for db context.
        /// </summary>
        public void Dispose()
        {
            // this.ApplicationDbContext.Database.EnsureDeleted();
            GC.SuppressFinalize(this);
        }
    }
}
