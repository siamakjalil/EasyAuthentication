
using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.AuthenticationFeatures.Requests.Commands
{
    public class ChangePassRequest : IRequest<ServiceMessage>
    {
    }
}
