namespace EasyAuthentication.Models.Request
{
    public class LoginByPass : SendAuthCode
    {
        public string Password { get; set; }
    }
}
