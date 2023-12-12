
using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.AuthenticationFeatures.Requests.Commands
{
    public class SetPassRequest : IRequest<ServiceMessage>
    {
        public SetPass SetPass { get; set; }
    }
}
