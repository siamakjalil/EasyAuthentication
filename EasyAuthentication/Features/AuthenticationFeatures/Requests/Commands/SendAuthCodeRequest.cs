
using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.AuthenticationFeatures.Requests.Commands
{
    public class SendAuthCodeRequest : IRequest<ServiceMessage>
    {
        public SendAuthCode SendAuthCode { get; set; }
    }
}
