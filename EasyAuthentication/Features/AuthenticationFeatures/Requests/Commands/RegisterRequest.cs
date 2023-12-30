
using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.AuthenticationFeatures.Requests.Commands
{
    public class RegisterRequest : IRequest<ServiceMessage>
    {
        public RegisterDto RegisterDto { get; set; }
    }
}
