// <copyright file="UpdateTodoItemCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.TodoItemHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateTodoItemCommandHandler"/>.
    /// </summary>
    public class UpdateTodoItemCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateTodoItemCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTodoItemCommandHandlerTests"/> class.
        /// </summary>
        public UpdateTodoItemCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateTodoItemCommandHandlerTests> logger)
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
        public async Task Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
