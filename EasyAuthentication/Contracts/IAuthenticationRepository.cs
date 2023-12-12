using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Response;

namespace EasyAuthentication.Contracts
{
    public interface IAuthenticationRepository
    {
        Task<SendAuthCodeResponse> SendAuthCode(SendAuthCode login);
        Task<LoggedInUser> LoginByAuthCode(LoginByAuthCode loginByAuthCode, string browser, string ip);
        Task<LoggedInUser> LoginByPass(LoginByPass loginByAuthCode, string browser, string ip);
        Task<bool> SetPass(SetPass setPass);
        Task<bool> ChangePass(ChangePass changePass);
    }
}
