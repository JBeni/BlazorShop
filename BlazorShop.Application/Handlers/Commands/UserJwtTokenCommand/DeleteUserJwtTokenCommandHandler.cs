namespace BlazorShop.Application.Handlers.Commands.UserJwtTokenCommand
{
    public class DeleteUserJwtTokenCommandHandler : IRequestHandler<DeleteUserJwtTokenCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteUserJwtTokenCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(DeleteUserJwtTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.UserJwtTokens.SingleOrDefault(d => d.UserId == request.UserId);

                _dbContext.UserJwtTokens.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error deleting the user jwt token", ex));
            }
        }
    }
}
