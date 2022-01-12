namespace BlazorShop.Application.Handlers.Commands.ClotheCommand
{
    public class DeleteClotheCommandHandler : IRequestHandler<DeleteClotheCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteClotheCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(DeleteClotheCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Clothes.SingleOrDefault(d => d.Id == request.Id && d.IsActive == true);
                entity.IsActive = false;

                _dbContext.Clothes.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error deleting the clothe", ex));
            }
        }
    }
}
