using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.UserFeatures.Requests.Queries
{
    public class GetUserRequest : IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
}
