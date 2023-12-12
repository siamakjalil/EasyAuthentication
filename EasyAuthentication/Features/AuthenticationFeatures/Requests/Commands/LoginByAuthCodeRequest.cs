
using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.AuthenticationFeatures.Requests.Commands
{
    public class LoginByAuthCodeRequest : IRequest<ServiceMessage>
    { 
        public LoginByAuthCode LoginByAuthCode { get; set; }
    }
}
