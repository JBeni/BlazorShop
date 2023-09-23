// <copyright file="GetClaimByIdQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.ClaimHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetClaimByIdQuery, ClaimResponse}"/>.
    /// </summary>
    public class GetClaimByIdQueryHandler : IRequestHandler<GetClaimByIdQuery, Result<ClaimResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetClaimByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="claimService">Gets An instance of <see cref="IClaimService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetClaimByIdQueryHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetClaimByIdQueryHandler(IClaimService claimService, ILogger<GetClaimByIdQueryHandler> logger)
        {
            this.ClaimService = claimService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IClaimService"/>.
        /// </summary>
        private IClaimService ClaimService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{GetClaimByIdQueryHandler}"/>.
        /// </summary>
        private ILogger<GetClaimByIdQueryHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetClaimByIdQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{ClaimResponse}"/>.</returns>
        public Task<Result<ClaimResponse>> Handle(GetClaimByIdQuery request, CancellationToken cancellationToken)
        {
            Result<ClaimResponse>? response;

            try
            {
                var result = this.ClaimService.GetClaimById(request.Id);

                response = new Result<ClaimResponse>
                {
                    Successful = true,
                    Item = result ?? new ClaimResponse(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetClaimByIdQuery);
                response = new Result<ClaimResponse>
                {
                    Error = $"{ErrorsManager.GetClaimByIdQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}
