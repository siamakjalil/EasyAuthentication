namespace EasyAuthentication.Models.Request
{
    public class SendAuthCode
    {
        public string? MobileNumber { get; set; }
        public string? Email { get; set; }
        public bool? ForceSend { get; set; }
    }
}
