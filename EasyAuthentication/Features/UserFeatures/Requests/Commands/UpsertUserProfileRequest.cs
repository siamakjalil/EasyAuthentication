using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.UserFeatures.Requests.Commands
{
    public class UpsertUserProfileRequest : IRequest<ServiceMessage>
    {
        public UserDto UserDto { get; set; }
    }
}
