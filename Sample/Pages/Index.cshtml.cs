using EasyAuthentication.Features.AuthenticationFeatures.Handlers.Commands;
using EasyAuthentication.Features.AuthenticationFeatures.Requests.Commands;
using EasyAuthentication.Features.RoleFeatures.Requests.Commands;
using EasyAuthentication.Features.RoleFeatures.Requests.Queries;
using EasyAuthentication.Features.User.Requests.Commands;
using EasyAuthentication.Features.User.Requests.Queries;
using EasyAuthentication.Features.UserFeatures.Requests.Commands;
using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IMediator _mediator;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            await _mediator.Send(new DeleteUserProfileRequest(){RemoveUserDto = new RemoveUserDto(){UserId = Guid.Empty}});
        }
    }
}
