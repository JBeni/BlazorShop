namespace BlazorShop.Application.Handlers.Commands.ClotheHandler
{
    public class CreateClotheCommandHandler : IRequestHandler<CreateClotheCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateClotheCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

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
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error creating the clothe", ex));
            }
        }
    }
}
