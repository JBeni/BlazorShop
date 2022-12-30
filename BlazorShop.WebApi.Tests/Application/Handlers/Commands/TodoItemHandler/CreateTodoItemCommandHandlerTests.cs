// <copyright file="CreateTodoItemCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.TodoItemHandler
{
    /// <summary>
    /// Tests for <see cref="CreateTodoItemCommandHandler"/>.
    /// </summary>
    public class CreateTodoItemCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private IMapper Mapper { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTodoItemCommandHandlerTests"/> class.
        /// </summary>
        public CreateTodoItemCommandHandlerTests(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Mapper = mapper;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response></response>
        public Task Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
