// <copyright file="DeleteClotheCommandHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.ClotheHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{DeleteClotheCommand, RequestResponse}"/>.
    /// </summary>
    public class DeleteClotheCommandHandler : IRequestHandler<DeleteClotheCommand, RequestResponse>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{DeleteClotheCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<DeleteClotheCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteClotheCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{DeleteClotheCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>

        public DeleteClotheCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteClotheCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteClotheCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(DeleteClotheCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = _dbContext.Clothes
                    .TagWith(nameof(DeleteClotheCommandHandler))
                    .SingleOrDefault(d => d.Id == request.Id && d.IsActive == true);
                if (entity == null) throw new Exception("The clothe does not exists");

                entity.IsActive = false;

                _dbContext.Clothes.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.DeleteClotheCommand);
                response = RequestResponse.Failure($"{ErrorsManager.DeleteClotheCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
