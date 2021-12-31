namespace BlazorShop.Application.Handlers.Commands.UserJwtTokenCommand
{
    public class CreateUserJwtTokenCommandHandler : IRequestHandler<CreateUserJwtTokenCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateUserJwtTokenCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(CreateUserJwtTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new UserJwtToken
                {
                    UserId = request.UserId,
                    JwtToken = request.JwtToken,
                    TokenTimestamp = request.TokenTimestamp,
                };

                _dbContext.UserJwtTokens.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error creating the user jwt token", ex));
            }
        }
    }
}
