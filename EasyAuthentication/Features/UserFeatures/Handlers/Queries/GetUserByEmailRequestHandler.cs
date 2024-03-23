using AutoMapper;
using EasyAuthentication.Contracts;
using EasyAuthentication.Features.UserFeatures.Requests.Queries;
using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.UserFeatures.Handlers.Queries
{
    public class GetUserByEmailRequestHandler : IRequestHandler<GetUserByEmailRequest, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserByEmailRequestHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<UserDto> Handle(GetUserByEmailRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FirstOrDefault(u => u.Email == request.Email);
            return user!=null ? _mapper.Map<UserDto>(user) : null;
        }
    }
}
