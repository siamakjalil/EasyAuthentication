using System.Security.AccessControl;

using MediatR;
using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Response;

namespace EasyAuthentication.Features.User.Requests.Queries
{
    public class GetUserRequest : IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
}
