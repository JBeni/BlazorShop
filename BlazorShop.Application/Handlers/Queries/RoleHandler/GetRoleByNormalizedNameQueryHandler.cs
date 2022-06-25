// <copyright file="GetRoleByNormalizedNameQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.RoleHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetRoleByNormalizedNameQueryHandler : IRequestHandler<GetRoleByNormalizedNameQuery, Result<RoleResponse>>
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<GetRoleByNormalizedNameQueryHandler> _logger;

        public GetRoleByNormalizedNameQueryHandler(IRoleService roleService, ILogger<GetRoleByNormalizedNameQueryHandler> logger)
        {
            _roleService = roleService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Result<RoleResponse>> Handle(GetRoleByNormalizedNameQuery request, CancellationToken cancellationToken)
        {
            Result<RoleResponse>? response;

            try
            {
                var result = _roleService.GetRoleByNormalizedName(request.NormalizedName);

                response = new Result<RoleResponse>
                {
                    Successful = true,
                    Item = result ?? new RoleResponse()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetRoleByNormalizedNameQuery);
                response = new Result<RoleResponse>
                {
                    Error = $"{ErrorsManager.GetRoleByNormalizedNameQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}
