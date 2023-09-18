// <copyright file="GetClaimByValueQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.ClaimHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetClaimByValueQuery, ClaimResponse}"/>.
    /// </summary>
    public class GetClaimByValueQueryHandler : IRequestHandler<GetClaimByValueQuery, Result<ClaimResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetClaimByValueQueryHandler"/> class.
        /// </summary>
        /// <param name="claimService">Gets An instance of <see cref="IClaimService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetClaimByValueQueryHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetClaimByValueQueryHandler(IClaimService claimService, ILogger<GetClaimByValueQueryHandler> logger)
        {
            this.ClaimService = claimService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IClaimService"/>.
        /// </summary>
        private IClaimService ClaimService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{GetClaimByValueQueryHandler}"/>.
        /// </summary>
        private ILogger<GetClaimByValueQueryHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetClaimByValueQueryHandler"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{ClaimResponse}"/>.</returns>
        public Task<Result<ClaimResponse>> Handle(GetClaimByValueQuery request, CancellationToken cancellationToken)
        {
            Result<ClaimResponse>? response;

            try
            {
                var result = this.ClaimService.GetClaimByNormalizedName(request.Value);

                response = new Result<ClaimResponse>
                {
                    Successful = true,
                    Item = result ?? new ClaimResponse(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetClaimByValueQuery);
                response = new Result<ClaimResponse>
                {
                    Error = $"{ErrorsManager.GetClaimByValueQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}
