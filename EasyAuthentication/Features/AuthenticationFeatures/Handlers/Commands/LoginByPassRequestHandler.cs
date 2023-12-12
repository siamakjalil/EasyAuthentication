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
    public class LoginByPassRequestHandler : IRequestHandler<LoginByPassRequest, ServiceMessage>
    {
        private readonly IAuthenticationRepository _authenticationRepository; 
        private readonly IConfiguration _configuration;
        private readonly WebTools _webTools;

        public LoginByPassRequestHandler(IAuthenticationRepository authenticationRepository, IConfiguration configuration, WebTools webTools)
        {
            _authenticationRepository = authenticationRepository;
            _configuration = configuration;
            _webTools = webTools;
        }

        public async Task<ServiceMessage> Handle(LoginByPassRequest request, CancellationToken cancellationToken)
        {
            var validator = new LoginByPassValidators();
            var validationResult = await validator.ValidateAsync(request.LoginByPass, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseManager.DataError(string.Join(",", validationResult.Errors.ToList()));
            }
            request.LoginByPass.MobileNumber = request.LoginByPass.MobileNumber;
            if (string.IsNullOrEmpty(request.LoginByPass.MobileNumber))
            {
                return ResponseManager.DataError(IdentityMessages.WrongMobile);
            }
            var model = await _authenticationRepository.LoginByPass(request.LoginByPass, _webTools.GetBrowser(), _webTools.GetRealIp());
            if (model==null)
            {
                return ResponseManager.DataError(IdentityMessages.WrongMobile);
            }
            return ResponseManager.FillObject(model);
        }
    }
}
