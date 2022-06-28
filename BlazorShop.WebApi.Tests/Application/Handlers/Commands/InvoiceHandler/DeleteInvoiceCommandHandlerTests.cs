// <copyright file="DeleteInvoiceCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.InvoiceHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteInvoiceCommandHandler"/>.
    /// </summary>
    public class DeleteInvoiceCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteInvoiceCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteInvoiceCommandHandlerTests"/> class.
        /// </summary>
        public DeleteInvoiceCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteInvoiceCommandHandlerTests> logger)
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
        public async Task Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
