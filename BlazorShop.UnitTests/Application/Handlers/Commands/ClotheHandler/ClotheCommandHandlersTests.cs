// <copyright file="ClotheCommandHandlersTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Common.Interfaces;
using BlazorShop.Application.Common.Models;
using BlazorShop.Application.Handlers.Commands.ClotheHandler;
using BlazorShop.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;

namespace BlazorShop.UnitTests.Application.Handlers.Commands.ClotheHandler
{
    /// <summary>
    /// Tests for Clothe command handlers.
    /// </summary>
    public class ClotheCommandHandlersTests
    {
        private readonly Mock<IApplicationDbContext> _dbContextMock;
        private readonly Mock<ILogger<CreateClotheCommandHandler>> _createLoggerMock;
        private readonly Mock<ILogger<UpdateClotheCommandHandler>> _updateLoggerMock;
        private readonly Mock<ILogger<DeleteClotheCommandHandler>> _deleteLoggerMock;
        private readonly Mock<DbSet<Clothe>> _clothesDbSetMock;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClotheCommandHandlersTests"/> class.
        /// </summary>
        public ClotheCommandHandlersTests()
        {
            _dbContextMock = new Mock<IApplicationDbContext>();
            _createLoggerMock = new Mock<ILogger<CreateClotheCommandHandler>>();
            _updateLoggerMock = new Mock<ILogger<UpdateClotheCommandHandler>>();
            _deleteLoggerMock = new Mock<ILogger<DeleteClotheCommandHandler>>();
            _clothesDbSetMock = new Mock<DbSet<Clothe>>();
            
            _dbContextMock.Setup(x => x.Clothes).Returns(_clothesDbSetMock.Object);
        }

        [Fact]
        public async Task CreateClotheCommandHandler_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new CreateClotheCommand
            {
                Name = "Test Clothe",
                Description = "Test Description",
                Price = 10.0m,
                Amount = 1,
                ImageName = "test.jpg",
                ImagePath = "/images/test.jpg"
            };

            var clothe = new Clothe { Id = 1 };

            _clothesDbSetMock.Setup(x => x.Add(It.IsAny<Clothe>()))
                .Callback<Clothe>(c => clothe = c);
            _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var handler = new CreateClotheCommandHandler(_dbContextMock.Object, _createLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Succeeded);
            Assert.Equal(clothe.Id, result.Data);
            Assert.Equal(command.Name, clothe.Name);
            Assert.Equal(command.Description, clothe.Description);
            Assert.Equal(command.Price, clothe.Price);
            Assert.Equal(command.Amount, clothe.Amount);
            Assert.Equal(command.ImageName, clothe.ImageName);
            Assert.Equal(command.ImagePath, clothe.ImagePath);
            Assert.True(clothe.IsActive);
            _clothesDbSetMock.Verify(x => x.Add(It.IsAny<Clothe>()), Times.Once);
            _dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task CreateClotheCommandHandler_ExceptionThrown_ReturnsFailureResponse()
        {
            // Arrange
            var command = new CreateClotheCommand
            {
                Name = "Test Clothe",
                Description = "Test Description",
                Price = 10.0m,
                Amount = 1
            };

            _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Database error"));

            var handler = new CreateClotheCommandHandler(_dbContextMock.Object, _createLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Contains("Database error", result.Error);
            _createLoggerMock.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => true),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Once);
        }

        [Fact]
        public async Task UpdateClotheCommandHandler_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new UpdateClotheCommand
            {
                Id = 1,
                Name = "Updated Clothe",
                Description = "Updated Description",
                Price = 20.0m,
                Amount = 2,
                ImageName = "updated.jpg",
                ImagePath = "/images/updated.jpg"
            };

            var clothe = new Clothe { Id = command.Id, IsActive = true };

            _clothesDbSetMock.Setup(x => x.SingleOrDefault(It.IsAny<Expression<Func<Clothe, bool>>>()))
                .Returns(clothe);
            _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var handler = new UpdateClotheCommandHandler(_dbContextMock.Object, _updateLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Succeeded);
            Assert.Equal(command.Name, clothe.Name);
            Assert.Equal(command.Description, clothe.Description);
            Assert.Equal(command.Price, clothe.Price);
            Assert.Equal(command.Amount, clothe.Amount);
            Assert.Equal(command.ImageName, clothe.ImageName);
            Assert.Equal(command.ImagePath, clothe.ImagePath);
            _clothesDbSetMock.Verify(x => x.Update(clothe), Times.Once);
            _dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateClotheCommandHandler_ClotheNotFound_ReturnsFailureResponse()
        {
            // Arrange
            var command = new UpdateClotheCommand
            {
                Id = 1,
                Name = "Updated Clothe"
            };

            _clothesDbSetMock.Setup(x => x.SingleOrDefault(It.IsAny<Expression<Func<Clothe, bool>>>()))
                .Returns((Clothe)null);

            var handler = new UpdateClotheCommandHandler(_dbContextMock.Object, _updateLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Contains("clothe does not exists", result.Error);
            _clothesDbSetMock.Verify(x => x.Update(It.IsAny<Clothe>()), Times.Never);
        }

        [Fact]
        public async Task DeleteClotheCommandHandler_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new DeleteClotheCommand { Id = 1 };
            var clothe = new Clothe { Id = command.Id, IsActive = true };

            _clothesDbSetMock.Setup(x => x.SingleOrDefault(It.IsAny<Expression<Func<Clothe, bool>>>()))
                .Returns(clothe);
            _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var handler = new DeleteClotheCommandHandler(_dbContextMock.Object, _deleteLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Succeeded);
            Assert.False(clothe.IsActive);
            _clothesDbSetMock.Verify(x => x.Update(clothe), Times.Once);
            _dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteClotheCommandHandler_ClotheNotFound_ReturnsFailureResponse()
        {
            // Arrange
            var command = new DeleteClotheCommand { Id = 1 };

            _clothesDbSetMock.Setup(x => x.SingleOrDefault(It.IsAny<Expression<Func<Clothe, bool>>>()))
                .Returns((Clothe)null);

            var handler = new DeleteClotheCommandHandler(_dbContextMock.Object, _deleteLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Contains("clothe does not exists", result.Error);
            _clothesDbSetMock.Verify(x => x.Update(It.IsAny<Clothe>()), Times.Never);
        }
    }
} 