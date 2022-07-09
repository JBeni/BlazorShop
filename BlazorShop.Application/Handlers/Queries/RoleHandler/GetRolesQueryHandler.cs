// <copyright file="GetRolesQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.RoleHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, Result<RoleResponse>>
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<GetRolesQueryHandler> _logger;

        public GetRolesQueryHandler(IRoleService roleService, ILogger<GetRolesQueryHandler> logger)
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
        public Task<Result<RoleResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            Result<RoleResponse>? response;

            try
            {
                var result = _roleService.GetRoles();

                response = new Result<RoleResponse>
                {
                    Successful = true,
                    Items = result ?? new List<RoleResponse>()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetRolesQuery);
                response = new Result<RoleResponse>
                {
                    Error = $"{ErrorsManager.GetRolesQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}
