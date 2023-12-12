using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.RoleFeatures.Requests.Commands
{
    public class DeleteRoleRequest : IRequest<ServiceMessage>
    {
        public int Id { get; set; }
    }
}
