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
    public class ChangePassRequestHandler : IRequestHandler<ChangePassRequest, ServiceMessage>
    {
        private readonly IAuthenticationRepository _authenticationRepository; 
        private readonly IConfiguration _configuration;

        public ChangePassRequestHandler(IAuthenticationRepository authenticationRepository, IConfiguration configuration)
        {
            _authenticationRepository = authenticationRepository;
            _configuration = configuration;
        }

        public async Task<ServiceMessage> Handle(ChangePassRequest request, CancellationToken cancellationToken)
        {
            var validator = new ChangePassValidators();
            var validationResult = await validator.ValidateAsync(request.ChangePass, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseManager.DataError(string.Join(",", validationResult.Errors.ToList()));
            }

            var res = await _authenticationRepository.ChangePass(request.ChangePass);
            return res? ResponseManager.FillObject(IdentityMessages.SuccessMessage): ResponseManager.DataError(IdentityMessages.WrongData);
        }
    }
}
