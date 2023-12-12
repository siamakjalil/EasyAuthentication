
using MediatR;
using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Response;

namespace EasyAuthentication.Features.User.Requests.Commands
{
    public class UpsertUserProfileRequest : IRequest<ServiceMessage>
    {
        public UserDto UserDto { get; set; }
    }
}
