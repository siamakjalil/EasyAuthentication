using AutoMapper;
using EasyAuthentication.Constants;
using EasyAuthentication.Contracts;
using EasyAuthentication.Features.UserFeatures.Requests.Commands;
using EasyAuthentication.Models.Request.Validators;
using EasyAuthentication.Models.Response;
using EasyAuthentication.Tools;
using MediatR;

namespace EasyAuthentication.Features.UserFeatures.Handlers.Commands
{
    public class UpsertUserProfileRequestHandler : IRequestHandler<UpsertUserProfileRequest, ServiceMessage>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UpsertUserProfileRequestHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ServiceMessage> Handle(UpsertUserProfileRequest request, CancellationToken cancellationToken)
        {
            var validator = new UserDtoValidators();
            var validationResult = await validator.ValidateAsync(request.UserDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseManager.DataError(string.Join(",", validationResult.Errors.ToList()));
            }

            var upsertUser = request.UserDto;
            if (!string.IsNullOrEmpty(upsertUser.MobileNumber) && await _userRepository.Exist(upsertUser.MobileNumber, upsertUser.Id))
            {
                return ResponseManager.DataError(IdentityMessages.ExistMobile);
            }
            if (!string.IsNullOrEmpty(upsertUser.Email) && await _userRepository.ExistByEmail(upsertUser.Email, upsertUser.Id))
            {
                return ResponseManager.DataError(IdentityMessages.ExistMobile);
            }

            if (upsertUser.Id == Guid.Empty)
            {
                upsertUser.IsActive = true;
                var user = _mapper.Map<Models.Entity.User>(upsertUser);
                await _userRepository.AddUser(user);
            }
            else
            {
                var user = await _userRepository.GetProfile(upsertUser.Id);
                _mapper.Map(upsertUser, user);
                await _userRepository.UpdateUser(user);

            }
            return ResponseManager.FillObject(IdentityMessages.SuccessMessage);
        }
    }
}
