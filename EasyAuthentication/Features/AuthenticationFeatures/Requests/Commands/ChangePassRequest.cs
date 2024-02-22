
using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.AuthenticationFeatures.Requests.Commands
{
    public class ChangePassRequest : IRequest<ServiceMessage>
    {
        public ChangePass ChangePass { get; set; }
    }
}
