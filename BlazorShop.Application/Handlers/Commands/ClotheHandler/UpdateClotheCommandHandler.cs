// <copyright file="UpdateClotheCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.ClotheHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateClotheCommandHandler : IRequestHandler<UpdateClotheCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateClotheCommandHandler> _logger;

        public UpdateClotheCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateClotheCommandHandler> logger)
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
        public async Task<RequestResponse> Handle(UpdateClotheCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = _dbContext.Clothes
                    .TagWith(nameof(UpdateClotheCommandHandler))
                    .SingleOrDefault(d => d.Id == request.Id && d.IsActive == true);
                if (entity == null) throw new Exception("The clothe does not exists");

                entity.Name = request.Name;
                entity.Description = request.Description;
                entity.Price = request.Price;
                entity.Amount = request.Amount;
                entity.ImageName = request.ImageName;
                entity.ImagePath = request.ImagePath;

                _dbContext.Clothes.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateClotheCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateClotheCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
