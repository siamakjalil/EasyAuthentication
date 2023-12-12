namespace EasyAuthentication.Models.Request
{
    public class RecoverPass : SetPass
    {
        public string ActivationCode { get; set; }
    }
}
