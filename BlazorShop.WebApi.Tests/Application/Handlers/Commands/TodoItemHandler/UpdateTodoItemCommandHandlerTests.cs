// <copyright file="UpdateTodoItemCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.TodoItemHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateTodoItemCommandHandler"/>.
    /// </summary>
    public class UpdateTodoItemCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<UpdateTodoItemCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTodoItemCommandHandlerTests"/> class.
        /// </summary>
        public UpdateTodoItemCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateTodoItemCommandHandlerTests> logger)
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
        public Task Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
