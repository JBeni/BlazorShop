// <copyright file="UpdateRoleCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.RoleHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, RequestResponse>
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<UpdateRoleCommandHandler> _logger;

        public UpdateRoleCommandHandler(IRoleService roleService, ILogger<UpdateRoleCommandHandler> logger)
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
        public async Task<RequestResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _roleService.UpdateRoleAsync(request);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateRoleCommand);
                return RequestResponse.Failure($"{ErrorsManager.UpdateRoleCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}
