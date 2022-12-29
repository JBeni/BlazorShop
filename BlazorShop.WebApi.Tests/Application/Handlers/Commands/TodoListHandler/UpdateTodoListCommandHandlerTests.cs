// <copyright file="UpdateTodoListCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.TodoListHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateTodoListCommandHandler"/>.
    /// </summary>
    public class UpdateTodoListCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateTodoListCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTodoListCommandHandlerTests"/> class.
        /// </summary>
        public UpdateTodoListCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateTodoListCommandHandlerTests> logger)
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
        public async Task Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
