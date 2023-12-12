using AutoMapper;
using EasyAuthentication.Models.Response;
using EasyAuthentication.Tools;
using MediatR;
using EasyAuthentication.Constants;
using EasyAuthentication.Contracts;
using EasyAuthentication.Features.User.Requests.Commands;
using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Request.Validators;
using EasyAuthentication.Repositories;

namespace EasyAuthentication.Features.User.Handlers.Commands
{
    public class DeleteUserProfileRequestHandler : IRequestHandler<DeleteUserProfileRequest, ServiceMessage>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public DeleteUserProfileRequestHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ServiceMessage> Handle(DeleteUserProfileRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetProfile(request.RemoveUserDto.UserId); 
            if (user == null)
            {
                return ResponseManager.DataError(IdentityMessages.DataNotFound);
            }
            user.IsActive = false;
            await _userRepository.UpdateUser(user);
            return ResponseManager.FillObject(IdentityMessages.SuccessMessage);
        }
    }
}
