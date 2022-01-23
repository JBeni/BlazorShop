﻿namespace BlazorShop.Application.Handlers.Queries.ClotheHandler
{
    public class GetClothesQueryHandler : IRequestHandler<GetClothesQuery, List<ClotheResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetClothesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<List<ClotheResponse>> Handle(GetClothesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Clothes
                    .Where(x => x.IsActive == true)
                    .ProjectTo<ClotheResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                List<ClotheResponse> ordersView = new();
                ordersView.Add(new ClotheResponse
                {
                    Error = "There was an error while getting the clothes... " + ex.Message ?? ex.InnerException.Message
                });
                return Task.FromResult(ordersView);
            }
        }
    }
}