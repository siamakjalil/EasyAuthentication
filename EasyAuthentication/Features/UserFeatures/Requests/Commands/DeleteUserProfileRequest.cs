
using MediatR;
using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Response;

namespace EasyAuthentication.Features.User.Requests.Commands
{
    public class DeleteUserProfileRequest : IRequest<ServiceMessage>
    {
        public RemoveUserDto RemoveUserDto { get; set; }
    }
}
