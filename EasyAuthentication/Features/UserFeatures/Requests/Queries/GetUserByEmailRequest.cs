using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.UserFeatures.Requests.Queries
{
    public class GetUserByEmailRequest : IRequest<UserDto>
    {
        public string Email { get; set; }
    }
}
