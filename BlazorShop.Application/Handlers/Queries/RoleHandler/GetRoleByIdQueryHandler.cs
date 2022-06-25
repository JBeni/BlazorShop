// <copyright file="GetRoleByIdQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.RoleHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, Result<RoleResponse>>
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<GetRoleByIdQueryHandler> _logger;

        public GetRoleByIdQueryHandler(IRoleService roleService, ILogger<GetRoleByIdQueryHandler> logger)
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
        public Task<Result<RoleResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            Result<RoleResponse>? response;

            try
            {
                var result = _roleService.GetRoleById(request.Id);

                response = new Result<RoleResponse>
                {
                    Successful = true,
                    Item = result ?? new RoleResponse()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetRoleByIdQuery);
                response = new Result<RoleResponse>
                {
                    Error = $"{ErrorsManager.GetRoleByIdQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}
