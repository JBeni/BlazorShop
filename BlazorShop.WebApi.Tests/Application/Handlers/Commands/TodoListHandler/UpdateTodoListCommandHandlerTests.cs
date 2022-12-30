// <copyright file="UpdateTodoListCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.TodoListHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateTodoListCommandHandler"/>.
    /// </summary>
    public class UpdateTodoListCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<UpdateTodoListCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTodoListCommandHandlerTests"/> class.
        /// </summary>
        public UpdateTodoListCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateTodoListCommandHandlerTests> logger)
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
        public Task Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
