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
    public class UpdateUserProfileRequestHandler : IRequestHandler<UpdateUserProfileRequest, ServiceMessage>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UpdateUserProfileRequestHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ServiceMessage> Handle(UpdateUserProfileRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserProfileDtoValidators();
            var validationResult = await validator.ValidateAsync(request.UserProfileDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseManager.DataError(string.Join(",", validationResult.Errors.ToList()));
            }

            var userProfile = await _userRepository.GetProfile(request.UserProfileDto.UserId.Value);
            if (userProfile == null)
            {
                return ResponseManager.DataError(IdentityMessages.WrongData);
            } 

            _mapper.Map(request.UserProfileDto, userProfile);
            await _userRepository.UpdateProfile(userProfile);

            return ResponseManager.FillObject(IdentityMessages.SuccessMessage);
        }
    }
}
