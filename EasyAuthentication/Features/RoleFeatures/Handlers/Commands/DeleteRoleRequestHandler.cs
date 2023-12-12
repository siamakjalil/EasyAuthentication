using EasyAuthentication.Constants;
using EasyAuthentication.Contracts;
using EasyAuthentication.Features.RoleFeatures.Requests.Commands;
using EasyAuthentication.Models.Response;
using EasyAuthentication.Tools;
using MediatR;

namespace EasyAuthentication.Features.RoleFeatures.Handlers.Commands
{
    public class DeleteRoleRequestHandler : IRequestHandler<DeleteRoleRequest, ServiceMessage>
    { 
        private readonly IRoleRepository _roleRepository;

        public DeleteRoleRequestHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ServiceMessage> Handle(DeleteRoleRequest request, CancellationToken cancellationToken)
        {
            await _roleRepository.RemoveRole(request.Id);
            return ResponseManager.FillObject(IdentityMessages.SuccessMessage);
        }
    }
}
