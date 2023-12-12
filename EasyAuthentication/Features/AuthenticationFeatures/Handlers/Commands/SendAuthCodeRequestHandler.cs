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
    public class SendAuthCodeRequestHandler : IRequestHandler<SendAuthCodeRequest, ServiceMessage>
    {
        private readonly IAuthenticationRepository _authenticationRepository; 
        private readonly IConfiguration _configuration;

        public SendAuthCodeRequestHandler(IAuthenticationRepository authenticationRepository, IConfiguration configuration)
        {
            _authenticationRepository = authenticationRepository;
            _configuration = configuration;
        }

        public async Task<ServiceMessage> Handle(SendAuthCodeRequest request, CancellationToken cancellationToken)
        {
            var validator = new SendAuthCodeValidators();
            var validationResult = await validator.ValidateAsync(request.SendAuthCode, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseManager.DataError(string.Join(",", validationResult.Errors.ToList()));
            } 
            if (string.IsNullOrEmpty(request.SendAuthCode.MobileNumber) && string.IsNullOrEmpty(request.SendAuthCode.Email))
            {
                return ResponseManager.DataError(IdentityMessages.WrongMobile);
            }
            var response = await _authenticationRepository.SendAuthCode(request.SendAuthCode);
            return ResponseManager.FillObject(response);
        }
    }
}
