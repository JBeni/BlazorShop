// <copyright file="GetRoleByNormalizedNameQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.RoleHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetRoleByNormalizedNameQuery, RoleResponse}"/>.
    /// </summary>
    public class GetRoleByNormalizedNameQueryHandler : IRequestHandler<GetRoleByNormalizedNameQuery, Result<RoleResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetRoleByNormalizedNameQueryHandler"/> class.
        /// </summary>
        /// <param name="roleService">Gets An instance of <see cref="IRoleService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetRoleByNormalizedNameQueryHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetRoleByNormalizedNameQueryHandler(IRoleService roleService, ILogger<GetRoleByNormalizedNameQueryHandler> logger)
        {
            this.RoleService = roleService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IRoleService"/>.
        /// </summary>
        private IRoleService RoleService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{GetRoleByNormalizedNameQueryHandler}"/>.
        /// </summary>
        private ILogger<GetRoleByNormalizedNameQueryHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetRoleByNormalizedNameQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{RoleResponse}"/>.</returns>
        public Task<Result<RoleResponse>> Handle(GetRoleByNormalizedNameQuery request, CancellationToken cancellationToken)
        {
            Result<RoleResponse>? response;

            try
            {
                var result = this.RoleService.GetRoleByNormalizedName(request.NormalizedName);

                response = new Result<RoleResponse>
                {
                    Successful = true,
                    Item = result ?? new RoleResponse(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetRoleByNormalizedNameQuery);
                response = new Result<RoleResponse>
                {
                    Error = $"{ErrorsManager.GetRoleByNormalizedNameQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}
