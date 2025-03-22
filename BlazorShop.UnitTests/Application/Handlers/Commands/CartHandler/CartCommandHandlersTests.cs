// <copyright file="CartCommandHandlersTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Common.Interfaces;
using BlazorShop.Application.Common.Models;
using BlazorShop.Application.Handlers.Commands.CartHandler;
using BlazorShop.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;

namespace BlazorShop.UnitTests.Application.Handlers.Commands.CartHandler
{
    /// <summary>
    /// Tests for Cart command handlers.
    /// </summary>
    public class CartCommandHandlersTests
    {
        private readonly Mock<IApplicationDbContext> _dbContextMock;
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly Mock<ILogger<CreateCartCommandHandler>> _createLoggerMock;
        private readonly Mock<ILogger<UpdateCartCommandHandler>> _updateLoggerMock;
        private readonly Mock<ILogger<DeleteCartCommandHandler>> _deleteLoggerMock;
        private readonly Mock<ILogger<DeleteAllCartsCommandHandler>> _deleteAllLoggerMock;
        private readonly Mock<DbSet<Cart>> _cartsDbSetMock;
        private readonly Mock<DbSet<Clothe>> _clothesDbSetMock;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartCommandHandlersTests"/> class.
        /// </summary>
        public CartCommandHandlersTests()
        {
            var userStore = new Mock<IUserStore<User>>();
            _userManagerMock = new Mock<UserManager<User>>(
                userStore.Object, null, null, null, null, null, null, null, null);

            _dbContextMock = new Mock<IApplicationDbContext>();
            _createLoggerMock = new Mock<ILogger<CreateCartCommandHandler>>();
            _updateLoggerMock = new Mock<ILogger<UpdateCartCommandHandler>>();
            _deleteLoggerMock = new Mock<ILogger<DeleteCartCommandHandler>>();
            _deleteAllLoggerMock = new Mock<ILogger<DeleteAllCartsCommandHandler>>();
            
            _cartsDbSetMock = new Mock<DbSet<Cart>>();
            _clothesDbSetMock = new Mock<DbSet<Clothe>>();
            
            _dbContextMock.Setup(x => x.Carts).Returns(_cartsDbSetMock.Object);
            _dbContextMock.Setup(x => x.Clothes).Returns(_clothesDbSetMock.Object);
        }

        [Fact]
        public async Task CreateCartCommandHandler_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new CreateCartCommand
            {
                Name = "Test Cart",
                Price = 10.0m,
                Amount = 1,
                ClotheId = 1,
                UserId = 1
            };

            var clothe = new Clothe { Id = command.ClotheId };
            var user = new User { Id = command.UserId.ToString() };
            var cart = new Cart { Id = 1 };

            _clothesDbSetMock.Setup(x => x.FirstOrDefault(It.IsAny<Expression<Func<Clothe, bool>>>()))
                .Returns(clothe);
            _userManagerMock.Setup(x => x.FindByIdAsync(command.UserId.ToString()))
                .ReturnsAsync(user);
            _cartsDbSetMock.Setup(x => x.Add(It.IsAny<Cart>()))
                .Callback<Cart>(c => cart = c);
            _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var handler = new CreateCartCommandHandler(_dbContextMock.Object, _createLoggerMock.Object, _userManagerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Succeeded);
            Assert.Equal(cart.Id, result.Data);
            _cartsDbSetMock.Verify(x => x.Add(It.IsAny<Cart>()), Times.Once);
            _dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task CreateCartCommandHandler_UserNotFound_ReturnsFailureResponse()
        {
            // Arrange
            var command = new CreateCartCommand
            {
                Name = "Test Cart",
                Price = 10.0m,
                Amount = 1,
                ClotheId = 1,
                UserId = 1
            };

            _userManagerMock.Setup(x => x.FindByIdAsync(command.UserId.ToString()))
                .ReturnsAsync((User)null);

            var handler = new CreateCartCommandHandler(_dbContextMock.Object, _createLoggerMock.Object, _userManagerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Contains("user does not exists", result.Error);
            _cartsDbSetMock.Verify(x => x.Add(It.IsAny<Cart>()), Times.Never);
        }

        [Fact]
        public async Task UpdateCartCommandHandler_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new UpdateCartCommand
            {
                Id = 1,
                Name = "Updated Cart",
                Price = 20.0m,
                Amount = 2,
                UserId = 1
            };

            var cart = new Cart { Id = command.Id };

            _cartsDbSetMock.Setup(x => x.FirstOrDefault(It.IsAny<Expression<Func<Cart, bool>>>()))
                .Returns(cart);
            _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var handler = new UpdateCartCommandHandler(_dbContextMock.Object, _updateLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Succeeded);
            Assert.Equal(command.Name, cart.Name);
            Assert.Equal(command.Price, cart.Price);
            Assert.Equal(command.Amount, cart.Amount);
            _cartsDbSetMock.Verify(x => x.Update(cart), Times.Once);
            _dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateCartCommandHandler_CartNotFound_ReturnsFailureResponse()
        {
            // Arrange
            var command = new UpdateCartCommand
            {
                Id = 1,
                Name = "Updated Cart",
                UserId = 1
            };

            _cartsDbSetMock.Setup(x => x.FirstOrDefault(It.IsAny<Expression<Func<Cart, bool>>>()))
                .Returns((Cart)null);

            var handler = new UpdateCartCommandHandler(_dbContextMock.Object, _updateLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Contains("cart do not exists", result.Error);
            _cartsDbSetMock.Verify(x => x.Update(It.IsAny<Cart>()), Times.Never);
        }

        [Fact]
        public async Task DeleteCartCommandHandler_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new DeleteCartCommand
            {
                Id = 1,
                UserId = 1
            };

            var cart = new Cart { Id = command.Id };

            _cartsDbSetMock.Setup(x => x.FirstOrDefault(It.IsAny<Expression<Func<Cart, bool>>>()))
                .Returns(cart);
            _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var handler = new DeleteCartCommandHandler(_dbContextMock.Object, _deleteLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Succeeded);
            _cartsDbSetMock.Verify(x => x.Remove(cart), Times.Once);
            _dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteCartCommandHandler_CartNotFound_ReturnsFailureResponse()
        {
            // Arrange
            var command = new DeleteCartCommand
            {
                Id = 1,
                UserId = 1
            };

            _cartsDbSetMock.Setup(x => x.FirstOrDefault(It.IsAny<Expression<Func<Cart, bool>>>()))
                .Returns((Cart)null);

            var handler = new DeleteCartCommandHandler(_dbContextMock.Object, _deleteLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Contains("cart does not exists", result.Error);
            _cartsDbSetMock.Verify(x => x.Remove(It.IsAny<Cart>()), Times.Never);
        }

        [Fact]
        public async Task DeleteAllCartsCommandHandler_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new DeleteAllCartsCommand { UserId = 1 };
            var carts = new List<Cart> 
            { 
                new Cart { Id = 1 },
                new Cart { Id = 2 }
            }.AsQueryable();

            _cartsDbSetMock.Setup(x => x.Where(It.IsAny<Expression<Func<Cart, bool>>>()))
                .Returns(carts);
            _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var handler = new DeleteAllCartsCommandHandler(_dbContextMock.Object, _deleteAllLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Succeeded);
            _cartsDbSetMock.Verify(x => x.RemoveRange(It.IsAny<IEnumerable<Cart>>()), Times.Once);
            _dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAllCartsCommandHandler_ExceptionThrown_ReturnsFailureResponse()
        {
            // Arrange
            var command = new DeleteAllCartsCommand { UserId = 1 };

            _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Database error"));

            var handler = new DeleteAllCartsCommandHandler(_dbContextMock.Object, _deleteAllLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Contains("Database error", result.Error);
            _deleteAllLoggerMock.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => true),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Once);
        }
    }
} 