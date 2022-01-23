﻿namespace BlazorShop.Application.Handlers.Queries.ClotheHandler
{
    public class GetClotheByIdQueryHandler : IRequestHandler<GetClotheByIdQuery, ClotheResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetClotheByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<ClotheResponse> Handle(GetClotheByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Clothes
                    .Where(x => x.Id == request.Id && x.IsActive == true)
                    .ProjectTo<ClotheResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ClotheResponse
                {
                    Error = "There was an error while getting the clothe by id... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}