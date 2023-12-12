
using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.AuthenticationFeatures.Requests.Commands
{
    public class LoginByPassRequest : IRequest<ServiceMessage>
    {
        public LoginByPass LoginByPass { get; set; }
    }
}
