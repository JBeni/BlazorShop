// <copyright file="UpdateClotheCommandHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.ClotheHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{UpdateClotheCommand, RequestResponse}"/>.
    /// </summary>
    public class UpdateClotheCommandHandler : IRequestHandler<UpdateClotheCommand, RequestResponse>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{UpdateClotheCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<UpdateClotheCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateClotheCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{UpdateClotheCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>

        public UpdateClotheCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateClotheCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateClotheCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
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
