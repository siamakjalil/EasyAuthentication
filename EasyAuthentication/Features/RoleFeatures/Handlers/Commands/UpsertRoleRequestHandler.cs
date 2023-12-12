using EasyAuthentication.Constants;
using EasyAuthentication.Contracts;
using EasyAuthentication.Features.RoleFeatures.Requests.Commands;
using EasyAuthentication.Models.Entity;
using EasyAuthentication.Models.Response;
using EasyAuthentication.Tools;
using MediatR;

namespace EasyAuthentication.Features.RoleFeatures.Handlers.Commands
{
    public class UpsertRoleRequestHandler : IRequestHandler<UpsertRoleRequest, ServiceMessage>
    {
        private readonly IRoleRepository _roleRepository;

        public UpsertRoleRequestHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        
        public async Task<ServiceMessage> Handle(UpsertRoleRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.RoleDto.Title))
            {
                return ResponseManager.DataError(IdentityMessages.WrongData);
            }

            if (request.RoleDto.Id == 0)
            {
                await _roleRepository.AddRole(new Role() { Title = request.RoleDto.Title });
            }
            else
            {
                var role = await _roleRepository.Get(request.RoleDto.Id);
                if (role==null)
                {
                    return ResponseManager.DataError(IdentityMessages.WrongData);
                }
                role.Title = request.RoleDto.Title;
                await _roleRepository.UpdateRole(role);
            }
            return ResponseManager.FillObject(IdentityMessages.SuccessMessage);
        }
    }
}
