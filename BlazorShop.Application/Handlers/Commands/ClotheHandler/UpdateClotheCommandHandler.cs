namespace BlazorShop.Application.Handlers.Commands.ClotheHandler
{
    public class UpdateClotheCommandHandler : IRequestHandler<UpdateClotheCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateClotheCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error updating the clothe", ex));
            }
        }
    }
}
