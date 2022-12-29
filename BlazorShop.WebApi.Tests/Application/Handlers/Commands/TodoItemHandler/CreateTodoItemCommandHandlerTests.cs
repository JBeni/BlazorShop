// <copyright file="CreateTodoItemCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.TodoItemHandler
{
    /// <summary>
    /// Tests for <see cref="CreateTodoItemCommandHandler"/>.
    /// </summary>
    public class CreateTodoItemCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTodoItemCommandHandlerTests"/> class.
        /// </summary>
        public CreateTodoItemCommandHandlerTests(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response></response>
        public async Task Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
