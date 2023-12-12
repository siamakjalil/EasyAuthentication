using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.RoleFeatures.Requests.Queries
{
    public class GetRoleRequest : IRequest<RoleDto>
    {
        public int Id { get; set; }
    }
}
