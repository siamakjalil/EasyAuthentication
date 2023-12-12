namespace EasyAuthentication.Models.Request
{
    public class LoginByAuthCode : SendAuthCode
    {
        public string ActivationCode { get; set; }
    }
}
