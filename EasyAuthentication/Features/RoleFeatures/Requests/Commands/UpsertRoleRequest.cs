using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.RoleFeatures.Requests.Commands
{
    public class UpsertRoleRequest : IRequest<ServiceMessage>
    {
        public RoleDto RoleDto { get; set; }
    }
}
