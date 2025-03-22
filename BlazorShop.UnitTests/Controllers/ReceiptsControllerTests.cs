// <copyright file="ReceiptsControllerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="ReceiptsController"/> class.
    /// </summary>
    public class ReceiptsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly ReceiptsController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptsControllerTests"/> class.
        /// </summary>
        public ReceiptsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new ReceiptsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateReceipt_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new CreateReceiptCommand 
            { 
                OrderId = 1,
                Amount = 199.99m,
                ReceiptDate = DateTime.UtcNow,
                PaymentMethod = "Credit Card"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateReceiptCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.CreateReceipt(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
            _mediatorMock.Verify(m => m.Send(It.IsAny<CreateReceiptCommand>(), default), Times.Once);
        }

        [Fact]
        public async Task GetReceiptById_ExistingReceipt_ReturnsOkResult()
        {
            // Arrange
            var receiptId = 1;
            var receiptDto = new ReceiptDto 
            { 
                Id = receiptId, 
                OrderId = 1,
                Amount = 199.99m,
                PaymentMethod = "Credit Card"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetReceiptByIdQuery>(), default))
                .ReturnsAsync(receiptDto);

            // Act
            var result = await _controller.GetReceiptById(receiptId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedReceipt = Assert.IsType<ReceiptDto>(okResult.Value);
            Assert.Equal(receiptId, returnedReceipt.Id);
            _mediatorMock.Verify(m => m.Send(It.Is<GetReceiptByIdQuery>(q => q.Id == receiptId), default), Times.Once);
        }

        [Fact]
        public async Task GetReceipts_ReturnsListOfReceipts()
        {
            // Arrange
            var receipts = new List<ReceiptDto> 
            { 
                new ReceiptDto { Id = 1, OrderId = 1, Amount = 199.99m },
                new ReceiptDto { Id = 2, OrderId = 2, Amount = 299.99m }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetReceiptsQuery>(), default))
                .ReturnsAsync(receipts);

            // Act
            var result = await _controller.GetReceipts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedReceipts = Assert.IsType<List<ReceiptDto>>(okResult.Value);
            Assert.Equal(2, returnedReceipts.Count);
            _mediatorMock.Verify(m => m.Send(It.IsAny<GetReceiptsQuery>(), default), Times.Once);
        }

        [Fact]
        public async Task GetReceiptsByOrderId_ExistingOrder_ReturnsOkResult()
        {
            // Arrange
            var orderId = 1;
            var receipts = new List<ReceiptDto> 
            { 
                new ReceiptDto { Id = 1, OrderId = orderId, Amount = 199.99m },
                new ReceiptDto { Id = 2, OrderId = orderId, Amount = 299.99m }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetReceiptsByOrderIdQuery>(), default))
                .ReturnsAsync(receipts);

            // Act
            var result = await _controller.GetReceiptsByOrderId(orderId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedReceipts = Assert.IsType<List<ReceiptDto>>(okResult.Value);
            Assert.All(returnedReceipts, receipt => Assert.Equal(orderId, receipt.OrderId));
            _mediatorMock.Verify(m => m.Send(It.Is<GetReceiptsByOrderIdQuery>(q => q.OrderId == orderId), default), Times.Once);
        }

        [Fact]
        public async Task UpdateReceipt_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new UpdateReceiptCommand 
            { 
                Id = 1,
                Amount = 249.99m,
                PaymentMethod = "PayPal"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateReceiptCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.UpdateReceipt(command);

            // Assert
            Assert.IsType<OkResult>(result);
            _mediatorMock.Verify(m => m.Send(command, default), Times.Once);
        }

        [Fact]
        public async Task DeleteReceipt_ExistingReceipt_ReturnsOkResult()
        {
            // Arrange
            var receiptId = 1;
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteReceiptCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.DeleteReceipt(receiptId);

            // Assert
            Assert.IsType<OkResult>(result);
            _mediatorMock.Verify(m => m.Send(It.Is<DeleteReceiptCommand>(c => c.Id == receiptId), default), Times.Once);
        }

        [Fact]
        public async Task GetReceipt_NonExistingReceipt_ReturnsNotFound()
        {
            // Arrange
            var receiptId = 999;
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetReceiptByIdQuery>(), default))
                .ReturnsAsync((ReceiptDto)null);

            // Act
            var result = await _controller.GetReceiptById(receiptId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreateReceipt_InvalidCommand_ReturnsBadRequest()
        {
            // Arrange
            var command = new CreateReceiptCommand(); // Invalid command with no data
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateReceiptCommand>(), default))
                .ReturnsAsync(Result.Failure("Invalid data"));

            // Act
            var result = await _controller.CreateReceipt(command);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.NotNull(badRequestResult.Value);
        }
    }
}
