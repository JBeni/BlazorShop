// <copyright file="CreateTodoListCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.TodoListHandler
{
    /// <summary>
    /// Tests for <see cref="CreateTodoListCommandHandler"/>.
    /// </summary>
    public class CreateTodoListCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateTodoListCommandHandlerTests> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTodoListCommandHandlerTests"/> class.
        /// </summary>
        public CreateTodoListCommandHandlerTests(IApplicationDbContext dbContext, ILogger<CreateTodoListCommandHandlerTests> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response =s></response =s>
        public async Task Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
