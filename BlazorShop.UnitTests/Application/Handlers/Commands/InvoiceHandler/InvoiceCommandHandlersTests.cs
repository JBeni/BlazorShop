// <copyright file="InvoiceCommandHandlersTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Common.Interfaces;
using BlazorShop.Application.Common.Models;
using BlazorShop.Application.Handlers.Commands.InvoiceHandler;
using BlazorShop.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;

namespace BlazorShop.UnitTests.Application.Handlers.Commands.InvoiceHandler
{
    /// <summary>
    /// Tests for Invoice command handlers.
    /// </summary>
    public class InvoiceCommandHandlersTests
    {
        private readonly Mock<IApplicationDbContext> _dbContextMock;
        private readonly Mock<ILogger<CreateInvoiceCommandHandler>> _createLoggerMock;
        private readonly Mock<ILogger<UpdateInvoiceCommandHandler>> _updateLoggerMock;
        private readonly Mock<ILogger<DeleteInvoiceCommandHandler>> _deleteLoggerMock;
        private readonly Mock<DbSet<Invoice>> _invoicesDbSetMock;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceCommandHandlersTests"/> class.
        /// </summary>
        public InvoiceCommandHandlersTests()
        {
            _dbContextMock = new Mock<IApplicationDbContext>();
            _createLoggerMock = new Mock<ILogger<CreateInvoiceCommandHandler>>();
            _updateLoggerMock = new Mock<ILogger<UpdateInvoiceCommandHandler>>();
            _deleteLoggerMock = new Mock<ILogger<DeleteInvoiceCommandHandler>>();
            _invoicesDbSetMock = new Mock<DbSet<Invoice>>();
            
            _dbContextMock.Setup(x => x.Invoices).Returns(_invoicesDbSetMock.Object);
        }

        [Fact]
        public async Task CreateInvoiceCommandHandler_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new CreateInvoiceCommand
            {
                UserEmail = "test@example.com",
                Name = "Test Invoice",
                AmountSubTotal = 100.0m,
                AmountTotal = 120.0m,
                Quantity = 2
            };

            var invoice = new Invoice { Id = 1 };

            _invoicesDbSetMock.Setup(x => x.Add(It.IsAny<Invoice>()))
                .Callback<Invoice>(i => invoice = i);
            _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var handler = new CreateInvoiceCommandHandler(_dbContextMock.Object, _createLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Succeeded);
            Assert.Equal(invoice.Id, result.Data);
            Assert.Equal(command.UserEmail, invoice.UserEmail);
            Assert.Equal(command.Name, invoice.Name);
            Assert.Equal(command.AmountSubTotal, invoice.AmountSubTotal);
            Assert.Equal(command.AmountTotal, invoice.AmountTotal);
            Assert.Equal(command.Quantity, invoice.Quantity);
            _invoicesDbSetMock.Verify(x => x.Add(It.IsAny<Invoice>()), Times.Once);
            _dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task CreateInvoiceCommandHandler_ExceptionThrown_ReturnsFailureResponse()
        {
            // Arrange
            var command = new CreateInvoiceCommand
            {
                UserEmail = "test@example.com",
                Name = "Test Invoice"
            };

            _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Database error"));

            var handler = new CreateInvoiceCommandHandler(_dbContextMock.Object, _createLoggerMock.Object);

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
        public async Task UpdateInvoiceCommandHandler_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new UpdateInvoiceCommand
            {
                Id = 1,
                UserEmail = "updated@example.com",
                Name = "Updated Invoice",
                AmountSubTotal = 200.0m,
                AmountTotal = 240.0m,
                Quantity = 4
            };

            var invoice = new Invoice { Id = command.Id };

            _invoicesDbSetMock.Setup(x => x.SingleOrDefault(It.IsAny<Expression<Func<Invoice, bool>>>()))
                .Returns(invoice);
            _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var handler = new UpdateInvoiceCommandHandler(_dbContextMock.Object, _updateLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Succeeded);
            Assert.Equal(command.UserEmail, invoice.UserEmail);
            Assert.Equal(command.Name, invoice.Name);
            Assert.Equal(command.AmountSubTotal, invoice.AmountSubTotal);
            Assert.Equal(command.AmountTotal, invoice.AmountTotal);
            Assert.Equal(command.Quantity, invoice.Quantity);
            _invoicesDbSetMock.Verify(x => x.Update(invoice), Times.Once);
            _dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateInvoiceCommandHandler_InvoiceNotFound_ReturnsFailureResponse()
        {
            // Arrange
            var command = new UpdateInvoiceCommand
            {
                Id = 1,
                UserEmail = "updated@example.com"
            };

            _invoicesDbSetMock.Setup(x => x.SingleOrDefault(It.IsAny<Expression<Func<Invoice, bool>>>()))
                .Returns((Invoice)null);

            var handler = new UpdateInvoiceCommandHandler(_dbContextMock.Object, _updateLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Contains("invoice does not exists", result.Error);
            _invoicesDbSetMock.Verify(x => x.Update(It.IsAny<Invoice>()), Times.Never);
        }

        [Fact]
        public async Task DeleteInvoiceCommandHandler_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new DeleteInvoiceCommand { Id = 1 };
            var invoice = new Invoice { Id = command.Id };

            _invoicesDbSetMock.Setup(x => x.SingleOrDefault(It.IsAny<Expression<Func<Invoice, bool>>>()))
                .Returns(invoice);
            _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var handler = new DeleteInvoiceCommandHandler(_dbContextMock.Object, _deleteLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Succeeded);
            _invoicesDbSetMock.Verify(x => x.Remove(invoice), Times.Once);
            _dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteInvoiceCommandHandler_InvoiceNotFound_ReturnsFailureResponse()
        {
            // Arrange
            var command = new DeleteInvoiceCommand { Id = 1 };

            _invoicesDbSetMock.Setup(x => x.SingleOrDefault(It.IsAny<Expression<Func<Invoice, bool>>>()))
                .Returns((Invoice)null);

            var handler = new DeleteInvoiceCommandHandler(_dbContextMock.Object, _deleteLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Contains("invoice does not exists", result.Error);
            _invoicesDbSetMock.Verify(x => x.Remove(It.IsAny<Invoice>()), Times.Never);
        }
    }
} 