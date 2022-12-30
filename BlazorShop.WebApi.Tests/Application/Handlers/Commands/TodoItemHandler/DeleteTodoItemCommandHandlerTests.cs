// <copyright file="DeleteTodoItemCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.TodoItemHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteTodoItemCommandHandler"/>.
    /// </summary>
    public class DeleteTodoItemCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<DeleteTodoItemCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTodoItemCommandHandlerTests"/> class.
        /// </summary>
        public DeleteTodoItemCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteTodoItemCommandHandlerTests> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response =s></response =s>
        public Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
