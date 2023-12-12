using AutoMapper;
using EasyAuthentication.Contracts;
using EasyAuthentication.Features.RoleFeatures.Requests.Queries;
using EasyAuthentication.Models.Response;
using MediatR;

namespace EasyAuthentication.Features.RoleFeatures.Handlers.Queries
{
    public class GetRoleRequestHandler : IRequestHandler<GetRoleRequest, RoleDto>
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;

        public GetRoleRequestHandler(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<RoleDto> Handle(GetRoleRequest request, CancellationToken cancellationToken)
        {
            var model=  await _roleRepository.Get(request.Id);
            return _mapper.Map<RoleDto>(model);
            
        }
    }
}
