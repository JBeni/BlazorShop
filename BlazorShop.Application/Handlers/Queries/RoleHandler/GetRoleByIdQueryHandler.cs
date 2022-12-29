// <copyright file="GetRoleByIdQueryHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.RoleHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetRoleByIdQuery, Result{RoleResponse}}"/>.
    /// </summary>
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, Result<RoleResponse>>
    {
        /// <summary>
        /// An instance of <see cref="IRoleService"/>.
        /// </summary>
        private readonly IRoleService _roleService;

        /// <summary>
        /// An instance of <see cref="ILogger{GetRoleByIdQueryHandler}"/>.
        /// </summary>
        private readonly ILogger<GetRoleByIdQueryHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRoleByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="roleService">An instance of <see cref="IRoleService"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{GetRoleByIdQueryHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetRoleByIdQueryHandler(IRoleService roleService, ILogger<GetRoleByIdQueryHandler> logger)
        {
            _roleService = roleService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="GetRoleByIdQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{Result{RoleResponse}}"/>.</returns>
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
