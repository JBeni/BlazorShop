﻿// <copyright file="GetReceiptsQueryHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.ReceiptHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetReceiptsQuery, ReceiptResponse}"/>.
    /// </summary>
    public class GetReceiptsQueryHandler : IRequestHandler<GetReceiptsQuery, Result<ReceiptResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetReceiptsQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetReceiptsQueryHandler}"/>.</param>
        /// <param name="mapper">Gets An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetReceiptsQueryHandler(IApplicationDbContext dbContext, ILogger<GetReceiptsQueryHandler> logger, IMapper mapper)
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
        /// Gets An instance of <see cref="ILogger{GetReceiptsQueryHandler}"/>.
        /// </summary>
        private ILogger<GetReceiptsQueryHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IMapper"/>.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetReceiptsQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{ReceiptResponse}"/>.</returns>
        public Task<Result<ReceiptResponse>> Handle(GetReceiptsQuery request, CancellationToken cancellationToken)
        {
            Result<ReceiptResponse>? response;

            try
            {
                var result = this.DbContext.Receipts
                    .TagWith(nameof(GetReceiptsQueryHandler))
                    .Where(x => x.UserEmail == request.UserEmail)
                    .ProjectTo<ReceiptResponse>(this.Mapper.ConfigurationProvider)
                    .ToList();

                response = new Result<ReceiptResponse>
                {
                    Successful = true,
                    Items = result ?? new List<ReceiptResponse>(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetReceiptsQuery);
                response = new Result<ReceiptResponse>
                {
                    Error = $"{ErrorsManager.GetReceiptsQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}
