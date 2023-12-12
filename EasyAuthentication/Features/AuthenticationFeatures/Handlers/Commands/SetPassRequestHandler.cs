using EasyAuthentication.Constants;
using EasyAuthentication.Contracts;
using EasyAuthentication.Features.AuthenticationFeatures.Requests.Commands;
using EasyAuthentication.Models.Request.Validators;
using EasyAuthentication.Models.Response;
using EasyAuthentication.Tools;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace EasyAuthentication.Features.AuthenticationFeatures.Handlers.Commands
{
    public class SetPassRequestHandler : IRequestHandler<SetPassRequest, ServiceMessage>
    {
        private readonly IAuthenticationRepository _authenticationRepository; 
        private readonly IConfiguration _configuration;

        public SetPassRequestHandler(IAuthenticationRepository authenticationRepository, IConfiguration configuration)
        {
            _authenticationRepository = authenticationRepository;
            _configuration = configuration;
        }

        public async Task<ServiceMessage> Handle(SetPassRequest request, CancellationToken cancellationToken)
        {
            var validator = new SetPassValidators();
            var validationResult = await validator.ValidateAsync(request.SetPass, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseManager.DataError(string.Join(",", validationResult.Errors.ToList()));
            }

            await _authenticationRepository.SetPass(request.SetPass);
            return ResponseManager.FillObject(IdentityMessages.SuccessMessage);
        }
    }
}
