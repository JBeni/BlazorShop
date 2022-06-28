// <copyright file="DeleteTodoItemCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.TodoItemHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteTodoItemCommandHandler"/>.
    /// </summary>
    public class DeleteTodoItemCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteTodoItemCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTodoItemCommandHandlerTests"/> class.
        /// </summary>
        public DeleteTodoItemCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteTodoItemCommandHandlerTests> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response =s></response =s>
        public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
