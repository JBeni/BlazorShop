// <copyright file="InvoicesControllerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="InvoicesController"/> class.
    /// </summary>
    public class InvoicesControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly InvoicesController _controller;

        public InvoicesControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new InvoicesController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateInvoice_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new CreateInvoiceCommand 
            { 
                OrderId = 1,
                Amount = 199.99m,
                InvoiceDate = DateTime.UtcNow
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateInvoiceCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.CreateInvoice(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task GetInvoiceById_ExistingInvoice_ReturnsOkResult()
        {
            // Arrange
            var invoiceId = 1;
            var invoiceDto = new InvoiceDto { Id = invoiceId, OrderId = 1 };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetInvoiceByIdQuery>(), default))
                .ReturnsAsync(invoiceDto);

            // Act
            var result = await _controller.GetInvoiceById(invoiceId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedInvoice = Assert.IsType<InvoiceDto>(okResult.Value);
            Assert.Equal(invoiceId, returnedInvoice.Id);
        }

        [Fact]
        public async Task GetInvoices_ReturnsListOfInvoices()
        {
            // Arrange
            var invoices = new List<InvoiceDto> 
            { 
                new InvoiceDto { Id = 1, OrderId = 1 },
                new InvoiceDto { Id = 2, OrderId = 2 }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetInvoicesQuery>(), default))
                .ReturnsAsync(invoices);

            // Act
            var result = await _controller.GetInvoices();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedInvoices = Assert.IsType<List<InvoiceDto>>(okResult.Value);
            Assert.Equal(2, returnedInvoices.Count);
        }

        [Fact]
        public async Task DeleteInvoice_ExistingInvoice_ReturnsOkResult()
        {
            // Arrange
            var invoiceId = 1;
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteInvoiceCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.DeleteInvoice(invoiceId);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
