using System.Reflection.PortableExecutable;

namespace EasyAuthentication.Models.Request
{
    public class ChangePass
    {
        public Guid UserId { get; set; }
        public string CurrentPass { get; set; }
        public string NewPass { get; set; }
        public string ReNewPass { get; set; }
    }
}
