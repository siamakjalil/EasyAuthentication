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
    public class LoginByAuthCodeRequestHandler : IRequestHandler<LoginByAuthCodeRequest, ServiceMessage>
    {
        private readonly IAuthenticationRepository _authenticationRepository; 
        private readonly IConfiguration _configuration;
        private readonly WebTools _webTools;

        public LoginByAuthCodeRequestHandler(IAuthenticationRepository authenticationRepository, IConfiguration configuration, WebTools webTools)
        {
            _authenticationRepository = authenticationRepository;
            _configuration = configuration;
            _webTools = webTools;
        }

        public async Task<ServiceMessage> Handle(LoginByAuthCodeRequest request, CancellationToken cancellationToken)
        {
            var validator = new LoginByAuthCodeValidators();
            var validationResult = await validator.ValidateAsync(request.LoginByAuthCode, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseManager.DataError(string.Join(",", validationResult.Errors.ToList()));
            }
            request.LoginByAuthCode.MobileNumber = request.LoginByAuthCode.MobileNumber;
            if (string.IsNullOrEmpty(request.LoginByAuthCode.MobileNumber))
            {
                return ResponseManager.DataError(IdentityMessages.WrongMobile);
            }
            var model = await _authenticationRepository.LoginByAuthCode(request.LoginByAuthCode,_webTools.GetBrowser(),_webTools.GetRealIp());
            if (model == null)
            {
                return ResponseManager.DataError(IdentityMessages.WrongActiveCode);
            }
            return ResponseManager.FillObject(model);
        }
    }
}
