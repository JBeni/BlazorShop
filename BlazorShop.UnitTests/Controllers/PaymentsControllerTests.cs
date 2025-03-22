// <copyright file="PaymentsControllerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="PaymentsController"/> class.
    /// </summary>
    public class PaymentsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly PaymentsController _controller;

        public PaymentsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new PaymentsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreatePayment_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new CreatePaymentCommand 
            { 
                OrderId = 1,
                Amount = 199.99m,
                PaymentMethod = "Credit Card"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreatePaymentCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.CreatePayment(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task GetPaymentById_ExistingPayment_ReturnsOkResult()
        {
            // Arrange
            var paymentId = 1;
            var paymentDto = new PaymentDto { Id = paymentId, OrderId = 1 };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPaymentByIdQuery>(), default))
                .ReturnsAsync(paymentDto);

            // Act
            var result = await _controller.GetPaymentById(paymentId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedPayment = Assert.IsType<PaymentDto>(okResult.Value);
            Assert.Equal(paymentId, returnedPayment.Id);
        }

        [Fact]
        public async Task GetPayments_ReturnsListOfPayments()
        {
            // Arrange
            var payments = new List<PaymentDto> 
            { 
                new PaymentDto { Id = 1, OrderId = 1 },
                new PaymentDto { Id = 2, OrderId = 2 }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPaymentsQuery>(), default))
                .ReturnsAsync(payments);

            // Act
            var result = await _controller.GetPayments();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedPayments = Assert.IsType<List<PaymentDto>>(okResult.Value);
            Assert.Equal(2, returnedPayments.Count);
        }

        [Fact]
        public async Task ProcessPayment_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new ProcessPaymentCommand 
            { 
                PaymentId = 1,
                Status = "Completed"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<ProcessPaymentCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.ProcessPayment(command);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
