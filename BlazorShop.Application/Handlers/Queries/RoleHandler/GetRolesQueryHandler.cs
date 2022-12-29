// <copyright file="GetRolesQueryHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.RoleHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetRolesQuery, Result{RoleResponse}}"/>.
    /// </summary>
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, Result<RoleResponse>>
    {
        /// <summary>
        /// An instance of <see cref="IRoleService"/>.
        /// </summary>
        private readonly IRoleService _roleService;

        /// <summary>
        /// An instance of <see cref="ILogger{GetRolesQueryHandler}"/>.
        /// </summary>
        private readonly ILogger<GetRolesQueryHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRolesQueryHandler"/> class.
        /// </summary>
        /// <param name="roleService">An instance of <see cref="IRoleService"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{GetRolesQueryHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetRolesQueryHandler(IRoleService roleService, ILogger<GetRolesQueryHandler> logger)
        {
            _roleService = roleService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="GetRolesQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{Result{RoleResponse}}"/>.</returns>
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
