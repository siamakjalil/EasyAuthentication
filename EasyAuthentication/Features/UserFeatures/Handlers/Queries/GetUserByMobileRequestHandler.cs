using AutoMapper;
using EasyAuthentication.Contracts;
using EasyAuthentication.Features.UserFeatures.Requests.Queries;
using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.UserFeatures.Handlers.Queries
{
    public class GetUserByMobileRequestHandler : IRequestHandler<GetUserByMobileRequest, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserByMobileRequestHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<UserDto> Handle(GetUserByMobileRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FirstOrDefault(u => u.MobileNumber == request.Mobile);
            return user!=null ? _mapper.Map<UserDto>(user) : null;
        }
    }
}
