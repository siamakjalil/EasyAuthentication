using AutoMapper;
using EasyAuthentication.Contracts;
using EasyAuthentication.Features.RoleFeatures.Requests.Queries;
using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.RoleFeatures.Handlers.Queries
{
    public class GetRoleListRequestHandler : IRequestHandler<GetRoleListRequest, List<RoleDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;

        public GetRoleListRequestHandler(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<List<RoleDto>> Handle(GetRoleListRequest request, CancellationToken cancellationToken)
        {
            var model = await _roleRepository.GetAll();
            return _mapper.Map<List<RoleDto>>(model);
        }
    }
}
