// <copyright file="CreateInvoiceCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.InvoiceHandler
{
    /// <summary>
    /// Tests for <see cref="CreateInvoiceCommandHandler"/>.
    /// </summary>
    public class CreateInvoiceCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateInvoiceCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateInvoiceCommandHandlerTests"/> class.
        /// </summary>
        public CreateInvoiceCommandHandlerTests(IApplicationDbContext dbContext, ILogger<CreateInvoiceCommandHandlerTests> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
