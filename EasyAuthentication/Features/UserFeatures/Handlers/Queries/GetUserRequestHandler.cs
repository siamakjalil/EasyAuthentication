using AutoMapper;

using MediatR;
using EasyAuthentication.Constants;
using EasyAuthentication.Contracts;
using EasyAuthentication.Features.User.Requests.Queries;
using EasyAuthentication.Migrations;
using EasyAuthentication.Models.Response;

namespace EasyAuthentication.Features.User.Handlers.Queries
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserRequestHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<UserDto> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetProfile(request.Id);
            if (user!=null)
            {
                return _mapper.Map<UserDto>(user);
            }

            return null;
        }
    }
}
