using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.UserFeatures.Requests.Commands
{
    public class UpdateUserProfileRequest : IRequest<ServiceMessage>
    {
        public UpdateUserProfileDto UserProfileDto { get; set; }
    }
}
