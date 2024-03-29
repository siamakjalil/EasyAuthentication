﻿using AutoMapper;
using EasyAuthentication.Contracts;
using EasyAuthentication.Features.UserFeatures.Requests.Queries;
using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.UserFeatures.Handlers.Queries
{
    public class GetUserProfileRequestHandler : IRequestHandler<GetUserProfileRequest, GetUserProfileDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserProfileRequestHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<GetUserProfileDto> Handle(GetUserProfileRequest request, CancellationToken cancellationToken)
        {
            if (request.UserId == Guid.Empty || request.UserId == null)
            {
                return null;
            }

            var model = await _userRepository.GetProfile(request.UserId);
            if (model == null)
            {
                return null;
            }

            var res = _mapper.Map<GetUserProfileDto>(model);
            return res;
        }
    }
}
