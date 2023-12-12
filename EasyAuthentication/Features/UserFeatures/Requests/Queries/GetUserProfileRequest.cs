
using MediatR;
using EasyAuthentication.Models.Response;

namespace EasyAuthentication.Features.User.Requests.Queries
{
    public class GetUserProfileRequest : IRequest<GetUserProfileDto>
    {
        public Guid UserId { get; set; }
    }
}
