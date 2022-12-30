// <copyright file="CreateTodoListCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.TodoListHandler
{
    /// <summary>
    /// Tests for <see cref="CreateTodoListCommandHandler"/>.
    /// </summary>
    public class CreateTodoListCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<CreateTodoListCommandHandlerTests> Logger { get; }
        private IMapper Mapper { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTodoListCommandHandlerTests"/> class.
        /// </summary>
        public CreateTodoListCommandHandlerTests(IApplicationDbContext dbContext, ILogger<CreateTodoListCommandHandlerTests> logger, IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.Mapper = mapper;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response =s></response =s>
        public Task Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
