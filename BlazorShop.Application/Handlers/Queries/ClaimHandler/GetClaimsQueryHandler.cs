// <copyright file="GetClaimsQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.ClaimHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetClaimsQuery, ClaimResponse}"/>.
    /// </summary>
    public class GetClaimsQueryHandler : IRequestHandler<GetClaimsQuery, Result<ClaimResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetClaimsQueryHandler"/> class.
        /// </summary>
        /// <param name="claimService">Gets An instance of <see cref="IClaimService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetClaimsQueryHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetClaimsQueryHandler(IClaimService claimService, ILogger<GetClaimsQueryHandler> logger)
        {
            this.ClaimService = claimService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IClaimService"/>.
        /// </summary>
        private IClaimService ClaimService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{GetClaimsQueryHandler}"/>.
        /// </summary>
        private ILogger<GetClaimsQueryHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetClaimsQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{ClaimResponse}"/>.</returns>
        public Task<Result<ClaimResponse>> Handle(GetClaimsQuery request, CancellationToken cancellationToken)
        {
            Result<ClaimResponse>? response;

            try
            {
                var result = this.ClaimService.GetClaims();

                response = new Result<ClaimResponse>
                {
                    Successful = true,
                    Items = result ?? new List<ClaimResponse>(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetClaimsQuery);
                response = new Result<ClaimResponse>
                {
                    Error = $"{ErrorsManager.GetClaimsQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}
