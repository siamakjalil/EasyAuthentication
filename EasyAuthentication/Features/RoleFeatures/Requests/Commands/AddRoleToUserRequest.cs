using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.RoleFeatures.Requests.Commands
{
    public class AddRoleToUserRequest : IRequest<ServiceMessage>
    {
        public int RoleId { get; set; }
        public Guid UserId { get; set; }
    }
}
