using EasyAuthentication.Constants;
using EasyAuthentication.Contracts;
using EasyAuthentication.Features.RoleFeatures.Requests.Commands;
using EasyAuthentication.Models.Response;
using EasyAuthentication.Tools;
using MediatR;

namespace EasyAuthentication.Features.RoleFeatures.Handlers.Commands
{
    public class AddRoleToUserRequestHandler : IRequestHandler<AddRoleToUserRequest, ServiceMessage>
    {
        private readonly IRoleRepository _roleRepository;

        public AddRoleToUserRequestHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        
        public async Task<ServiceMessage> Handle(AddRoleToUserRequest request, CancellationToken cancellationToken)
        {
            await _roleRepository.AddRoleToUser(request.UserId,request.RoleId);
            return ResponseManager.FillObject(IdentityMessages.SuccessMessage);
        }
    }
}
