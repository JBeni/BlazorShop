// <copyright file="CreateRoleCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.RoleHandler
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, RequestResponse>
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<CreateRoleCommandHandler> _logger;

        public CreateRoleCommandHandler(IRoleService roleService, ILogger<CreateRoleCommandHandler> logger)
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
        public async Task<RequestResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _roleService.CreateRoleAsync(request);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.CreateRoleCommand);
                return RequestResponse.Failure($"{ErrorsManager.CreateRoleCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}
