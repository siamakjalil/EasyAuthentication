using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.UserFeatures.Requests.Queries
{
    public class GetUserListRequest : IRequest<UserListDto>
    { 
        public FilterUserDto Filter { get; set; }
    }
}
