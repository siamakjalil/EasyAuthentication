using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.UserFeatures.Requests.Queries
{
    public class GetUserByMobileRequest : IRequest<UserDto>
    {
        public string Mobile { get; set; }
    }
}
