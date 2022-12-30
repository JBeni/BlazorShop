// <copyright file="GetRolesForAdminQueryHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.RoleHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetRolesForAdminQuery, Result{RoleResponse}}"/>.
    /// </summary>
    public class GetRolesForAdminQueryHandler : IRequestHandler<GetRolesForAdminQuery, Result<RoleResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetRolesForAdminQueryHandler"/> class.
        /// </summary>
        /// <param name="roleService">Gets An instance of <see cref="IRoleService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetRolesForAdminQueryHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetRolesForAdminQueryHandler(IRoleService roleService, ILogger<GetRolesForAdminQueryHandler> logger)
        {
            this.RoleService = roleService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IRoleService"/>.
        /// </summary>
        private IRoleService RoleService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{GetRolesForAdminQueryHandler}"/>.
        /// </summary>
        private ILogger<GetRolesForAdminQueryHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetRolesForAdminQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{Result{RoleResponse}}"/>.</returns>
        public Task<Result<RoleResponse>> Handle(GetRolesForAdminQuery request, CancellationToken cancellationToken)
        {
            Result<RoleResponse>? response;

            try
            {
                var result = this.RoleService.GetRolesForAdmin();

                response = new Result<RoleResponse>
                {
                    Successful = true,
                    Items = result ?? new List<RoleResponse>(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetRolesForAdminQuery);
                response = new Result<RoleResponse>
                {
                    Error = $"{ErrorsManager.GetRolesForAdminQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}
