// <copyright file="CreateClaimCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.ClaimHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{CreateClaimCommand, RequestResponse}"/>.
    /// </summary>
    public class CreateClaimCommandHandler : IRequestHandler<CreateClaimCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateClaimCommandHandler"/> class.
        /// </summary>
        /// <param name="claimService">Gets An instance of <see cref="IClaimService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{CreateClaimCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public CreateClaimCommandHandler(IClaimService claimService, ILogger<CreateClaimCommandHandler> logger)
        {
            this.ClaimService = claimService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IClaimService"/>.
        /// </summary>
        private IClaimService ClaimService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{CreateClaimCommandHandler}"/>.
        /// </summary>
        private ILogger<CreateClaimCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="CreateClaimCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(CreateClaimCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                response = await this.ClaimService.CreateClaimAsync(request);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.CreateClaimCommand);
                response = RequestResponse.Failure($"{ErrorsManager.CreateClaimCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
