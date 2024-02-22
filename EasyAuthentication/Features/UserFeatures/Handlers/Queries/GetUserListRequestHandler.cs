using System.Linq.Expressions;
using AutoMapper;
using EasyAuthentication.Contracts;
using EasyAuthentication.Features.UserFeatures.Requests.Queries;
using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.UserFeatures.Handlers.Queries
{
    public class GetUserListRequestHandler : IRequestHandler<GetUserListRequest, UserListDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserListRequestHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<UserListDto> Handle(GetUserListRequest request, CancellationToken cancellationToken)
        {
            var filter = request.Filter;
            Expression<Func<Models.Entity.User, bool>>? where = u => u.IsActive &&
                                                                       (string.IsNullOrEmpty(filter.SearchText) || u.FirstName.Contains(filter.SearchText) ||
                                                                        u.LastName.Contains(filter.SearchText) ||
                                                                        u.MobileNumber.Contains(filter.SearchText) || u.Email.Contains(filter.SearchText)) &&
                                                                       (filter.UserIds == null || !filter.UserIds.Any() || filter.UserIds.Contains(u.Id)) &&
                                                                       (filter.UserType == 0 || u.UserType == filter.UserType);
            var skip = (filter.Take * (filter.PageId - 1));
            var res = await _userRepository.GetAll(where, skip, filter.Take);
            var count = await _userRepository.GetCount(where);

            return new UserListDto()
            {
                PageId = filter.PageId,
                Count = count,
                Users = _mapper.Map<List<UserDto>>(res)
            };
        }
    }
}
