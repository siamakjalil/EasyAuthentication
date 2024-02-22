using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.UserFeatures.Requests.Queries
{
    public class GetUserProfileRequest : IRequest<GetUserProfileDto>
    {
        public Guid UserId { get; set; }
    }
}
