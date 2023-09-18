// <copyright file="UpdateClaimCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.ClaimHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{UpdateClaimCommand, RequestResponse}"/>.
    /// </summary>
    public class UpdateClaimCommandHandler : IRequestHandler<UpdateClaimCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateClaimCommandHandler"/> class.
        /// </summary>
        /// <param name="claimService">Gets An instance of <see cref="IClaimService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{UpdateClaimCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateClaimCommandHandler(IClaimService claimService, ILogger<UpdateClaimCommandHandler> logger)
        {
            this.ClaimService = claimService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IClaimService"/>.
        /// </summary>
        private IClaimService ClaimService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{UpdateClaimCommandHandler}"/>.
        /// </summary>
        private ILogger<UpdateClaimCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateClaimCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(UpdateClaimCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                response = await this.ClaimService.UpdateClaimAsync(request);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.UpdateClaimCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateClaimCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
