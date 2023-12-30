using EasyAuthentication.Constants;
using EasyAuthentication.Contracts;
using EasyAuthentication.Features.AuthenticationFeatures.Requests.Commands;
using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Request.Validators;
using EasyAuthentication.Models.Response;
using EasyAuthentication.Tools;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace EasyAuthentication.Features.AuthenticationFeatures.Handlers.Commands
{
    public class RegisterRequestHandler : IRequestHandler<RegisterRequest, ServiceMessage>
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public RegisterRequestHandler(IAuthenticationRepository authenticationRepository, IUserRepository userRepository, IConfiguration configuration)
        {
            _authenticationRepository = authenticationRepository;
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<ServiceMessage> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var validator = new RegisterDtoValidators();
            var validationResult = await validator.ValidateAsync(request.RegisterDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseManager.DataError(string.Join(",", validationResult.Errors.ToList()));
            } 
            if (string.IsNullOrEmpty(request.RegisterDto.MobileNumber))
            {
                return ResponseManager.DataError(IdentityMessages.WrongMobile);
            }
            var response = await _authenticationRepository.Register(request.RegisterDto); 
            return ResponseManager.FillObject(response);
        }
    }
}
