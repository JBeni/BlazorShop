// <copyright file="GetTodoItemByIdQueryHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.TodoItemHandler
{
    /// <summary>
    /// Tests for <see cref="GetTodoItemByIdQueryHandler"/>.
    /// </summary>
    public class GetTodoItemByIdQueryHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<GetTodoItemByIdQueryHandlerTests> Logger { get; }
        private IMapper Mapper { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTodoItemByIdQueryHandlerTests"/> class.
        /// </summary>
        public GetTodoItemByIdQueryHandlerTests(IApplicationDbContext dbContext, ILogger<GetTodoItemByIdQueryHandlerTests> logger, IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.Mapper = mapper;
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public Task Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
