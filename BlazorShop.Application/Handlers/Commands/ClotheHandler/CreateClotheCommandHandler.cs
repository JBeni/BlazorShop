// <copyright file="CreateClotheCommandHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.ClotheHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{CreateClotheCommand, RequestResponse}"/>.
    /// </summary>
    public class CreateClotheCommandHandler : IRequestHandler<CreateClotheCommand, RequestResponse>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{CreateClotheCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<CreateClotheCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateClotheCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{CreateClotheCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>

        public CreateClotheCommandHandler(IApplicationDbContext dbContext, ILogger<CreateClotheCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="CreateClotheCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(CreateClotheCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = new Clothe
                {
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    Amount = request.Amount,
                    ImageName = request.ImageName,
                    ImagePath = request.ImagePath,
                    IsActive = true,
                };

                _dbContext.Clothes.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.CreateClotheCommand);
                response = RequestResponse.Failure($"{ErrorsManager.CreateClotheCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
