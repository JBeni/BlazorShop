namespace BlazorShop.Application.Handlers.Queries.AppRoleQuery
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<AppRoleResponse>>
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public GetRolesQueryHandler(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public Task<List<AppRoleResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var role = _roleManager.Roles
                    .ProjectTo<AppRoleResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return Task.FromResult(role);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error getting the roles... " + ex.Message ?? ex.InnerException.Message);
            }
        }
    }
}
