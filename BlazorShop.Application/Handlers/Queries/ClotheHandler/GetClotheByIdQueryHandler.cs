// <copyright file="GetClotheByIdQueryHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.ClotheHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetClotheByIdQuery, Result{ClotheResponse}}"/>.
    /// </summary>
    public class GetClotheByIdQueryHandler : IRequestHandler<GetClotheByIdQuery, Result<ClotheResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetClotheByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetClotheByIdQueryHandler}"/>.</param>
        /// <param name="mapper">Gets An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetClotheByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetClotheByIdQueryHandler> logger, IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.Mapper = mapper;
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{GetClotheByIdQueryHandler}"/>.
        /// </summary>
        private ILogger<GetClotheByIdQueryHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IMapper"/>.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetClotheByIdQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{Result{ClotheResponse}}"/>.</returns>
        public Task<Result<ClotheResponse>> Handle(GetClotheByIdQuery request, CancellationToken cancellationToken)
        {
            Result<ClotheResponse>? response;

            try
            {
                var result = this.DbContext.Clothes
                    .TagWith(nameof(GetClotheByIdQueryHandler))
                    .Where(x => x.Id == request.Id && x.IsActive == true)
                    .ProjectTo<ClotheResponse>(this.Mapper.ConfigurationProvider)
                    .FirstOrDefault();

                response = new Result<ClotheResponse>
                {
                    Successful = true,
                    Item = result ?? new ClotheResponse(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetClotheByIdQuery);
                response = new Result<ClotheResponse>
                {
                    Error = $"{ErrorsManager.GetClotheByIdQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}
