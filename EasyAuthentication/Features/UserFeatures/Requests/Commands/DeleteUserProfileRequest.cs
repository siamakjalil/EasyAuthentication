using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.UserFeatures.Requests.Commands
{
    public class DeleteUserProfileRequest : IRequest<ServiceMessage>
    {
        public RemoveUserDto RemoveUserDto { get; set; }
    }
}
