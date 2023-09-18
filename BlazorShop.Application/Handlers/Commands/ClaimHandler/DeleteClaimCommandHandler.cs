// <copyright file="DeleteClaimCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Common.Interfaces;

namespace BlazorShop.Application.Handlers.Commands.ClaimHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{DeleteClaimCommand, RequestResponse}"/>.
    /// </summary>
    public class DeleteClaimCommandHandler : IRequestHandler<DeleteClaimCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteClaimCommandHandler"/> class.
        /// </summary>
        /// <param name="claimService">Gets An instance of <see cref="IClaimService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{DeleteClaimCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public DeleteClaimCommandHandler(IClaimService claimService, ILogger<DeleteClaimCommandHandler> logger)
        {
            this.ClaimService = claimService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IClaimService"/>.
        /// </summary>
        private IClaimService ClaimService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{DeleteClaimCommandHandler}"/>.
        /// </summary>
        private ILogger<DeleteClaimCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteClaimCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(DeleteClaimCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                response = await this.ClaimService.DeleteClaimAsync(request.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.DeleteClaimCommand);
                response = RequestResponse.Failure($"{ErrorsManager.DeleteClaimCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
