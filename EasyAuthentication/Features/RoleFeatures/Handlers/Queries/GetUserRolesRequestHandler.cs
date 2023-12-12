using EasyAuthentication.Contracts;
using EasyAuthentication.Features.RoleFeatures.Requests.Queries;
using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.RoleFeatures.Handlers.Queries
{
    public class GetUserRolesRequestHandler : IRequestHandler<GetUserRolesRequest, List<UserRoleDto>>
    {
        private IRoleRepository _roleRepository;

        public GetUserRolesRequestHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<UserRoleDto>> Handle(GetUserRolesRequest request, CancellationToken cancellationToken)
        {
            var model=  await _roleRepository.GetUserRoles(request.Id);
            return model.Select(u => new UserRoleDto()
            {
                RoleId = u.RoleId,
                RoleTitle = u.Role.Title,
                UserRoleId = u.Id,
            }).ToList();
        }
    }
}
