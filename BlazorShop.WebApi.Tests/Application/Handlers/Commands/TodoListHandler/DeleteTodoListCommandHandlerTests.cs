// <copyright file="DeleteTodoListCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.TodoListHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteTodoListCommandHandler"/>.
    /// </summary>
    public class DeleteTodoListCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteTodoListCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTodoListCommandHandlerTests"/> class.
        /// </summary>
        public DeleteTodoListCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteTodoListCommandHandlerTests> logger)
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
        public async Task Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
