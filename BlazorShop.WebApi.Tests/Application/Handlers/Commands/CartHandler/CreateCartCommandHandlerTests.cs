// <copyright file="CreateCartCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Handlers.Commands.CartHandler;
using BlazorShop.Infrastructure.Persistence;
using Moq;
using Xunit;

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.CartHandler
{
    /// <summary>
    /// Tests for <see cref="CreateCartCommandHandler"/> class.
    /// </summary>
    public class CreateCartCommandHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCartCommandHandlerTests"/> class.
        /// </summary>
        public CreateCartCommandHandlerTests()
        {
        }

        /// <summary>
        /// Gets the <see cref="CreateCartCommandHandler"/> instance to use.
        /// </summary>
        private CreateCartCommandHandler SUT { get; }

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
        /// Gets the <see cref="ILogger{CreateCartCommandHandler}"/> under test.
        /// </summary>
        private ILogger<CreateCartCommandHandler> Logger { get; }

        /// <summary>
        /// A test for <see cref="CreateCartCommandHandler.Handle(CreateCartCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Fact]
        public async Task Handle()
        {
        }

        /// <summary>
        /// A test for <see cref="CreateCartCommandHandler.Handle(CreateCartCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
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
