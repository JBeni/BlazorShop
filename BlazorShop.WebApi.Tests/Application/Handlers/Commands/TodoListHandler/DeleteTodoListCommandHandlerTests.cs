// <copyright file="DeleteTodoListCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.TodoListHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteTodoListCommandHandler"/>.
    /// </summary>
    public class DeleteTodoListCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<DeleteTodoListCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTodoListCommandHandlerTests"/> class.
        /// </summary>
        public DeleteTodoListCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteTodoListCommandHandlerTests> logger)
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
        public Task Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
