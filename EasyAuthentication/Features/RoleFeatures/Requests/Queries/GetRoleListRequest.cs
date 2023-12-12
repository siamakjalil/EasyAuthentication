using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.RoleFeatures.Requests.Queries
{
    public class GetRoleListRequest : IRequest<List<RoleDto>>
    { 
    }
}
