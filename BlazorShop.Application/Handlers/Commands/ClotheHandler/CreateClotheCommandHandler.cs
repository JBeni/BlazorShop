// <copyright file="CreateClotheCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.ClotheHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class CreateClotheCommandHandler : IRequestHandler<CreateClotheCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateClotheCommandHandler> _logger;

        public CreateClotheCommandHandler(IApplicationDbContext dbContext, ILogger<CreateClotheCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<RequestResponse> Handle(CreateClotheCommand request, CancellationToken cancellationToken)
        {
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
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.CreateClotheCommand);
                return RequestResponse.Failure($"{ErrorsManager.CreateClotheCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}
