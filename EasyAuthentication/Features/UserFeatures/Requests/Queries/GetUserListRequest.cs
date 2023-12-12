using System.Security.AccessControl;

using MediatR;
using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Response;

namespace EasyAuthentication.Features.User.Requests.Queries
{
    public class GetUserListRequest : IRequest<UserListDto>
    { 
        public FilterUserDto Filter { get; set; }
    }
}
