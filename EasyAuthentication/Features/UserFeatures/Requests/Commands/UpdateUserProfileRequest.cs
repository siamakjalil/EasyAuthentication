
using MediatR;
using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Response;

namespace EasyAuthentication.Features.User.Requests.Commands
{
    public class UpdateUserProfileRequest : IRequest<ServiceMessage>
    {
        public UpdateUserProfileDto UserProfileDto { get; set; }
    }
}
