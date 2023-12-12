using EasyAuthentication.Constants;
using EasyAuthentication.Contracts;
using EasyAuthentication.Features.RoleFeatures.Requests.Commands;
using EasyAuthentication.Models.Response;
using EasyAuthentication.Tools;
using MediatR;

namespace EasyAuthentication.Features.RoleFeatures.Handlers.Commands
{
    public class DeleteRoleFromUserRequestHandler : IRequestHandler<DeleteRoleFromUserRequest, ServiceMessage>
    { 
        private readonly IRoleRepository _roleRepository;

        public DeleteRoleFromUserRequestHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ServiceMessage> Handle(DeleteRoleFromUserRequest request, CancellationToken cancellationToken)
        {
            await _roleRepository.RemoveUserRole(request.Id);
            return ResponseManager.FillObject(IdentityMessages.SuccessMessage);
        }
    }
}
