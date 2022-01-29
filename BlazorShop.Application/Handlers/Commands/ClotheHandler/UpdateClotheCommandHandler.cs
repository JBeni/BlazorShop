namespace BlazorShop.Application.Handlers.Commands.ClotheHandler
{
    public class UpdateClotheCommandHandler : IRequestHandler<UpdateClotheCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateClotheCommandHandler> _logger;

        public UpdateClotheCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateClotheCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<RequestResponse> Handle(UpdateClotheCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Clothes.SingleOrDefault(d => d.Id == request.Id && d.IsActive == true);

                entity.Name = request.Name;
                entity.Description = request.Description;
                entity.Price = request.Price;
                entity.Amount = request.Amount;
                entity.ImageName = request.ImageName;
                entity.ImagePath = request.ImagePath;

                _dbContext.Clothes.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error updating the clothe");
                return RequestResponse.Failure("There was an error updating the clothe. " + ex.Message ?? ex.InnerException.Message);
            }
        }
    }
}
