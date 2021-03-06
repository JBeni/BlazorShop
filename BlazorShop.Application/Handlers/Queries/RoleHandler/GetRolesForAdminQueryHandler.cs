// <copyright file="GetRolesForAdminQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.RoleHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetRolesForAdminQueryHandler : IRequestHandler<GetRolesForAdminQuery, Result<RoleResponse>>
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<GetRolesForAdminQueryHandler> _logger;

        public GetRolesForAdminQueryHandler(IRoleService roleService, ILogger<GetRolesForAdminQueryHandler> logger)
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
        public Task<Result<RoleResponse>> Handle(GetRolesForAdminQuery request, CancellationToken cancellationToken)
        {
            Result<RoleResponse>? response;

            try
            {
                var result = _roleService.GetRolesForAdmin();

                response = new Result<RoleResponse>
                {
                    Successful = true,
                    Items = result ?? new List<RoleResponse>()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetRolesForAdminQuery);
                response = new Result<RoleResponse>
                {
                    Error = $"{ErrorsManager.GetRolesForAdminQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}
