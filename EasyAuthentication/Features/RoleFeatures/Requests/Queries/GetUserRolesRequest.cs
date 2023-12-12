using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.RoleFeatures.Requests.Queries
{
    public class GetUserRolesRequest : IRequest<List<UserRoleDto>>
    {
        public Guid Id { get; set; }
    }
}
