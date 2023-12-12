using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAuthentication.Models.Response
{
    public class SendAuthCodeResponse
    {
        public Guid UserUniqueId { get; set; }
        public Guid UserId { get; set; }
        public bool HasPass { get; set; }
        public string ActivationCode { get; set; }
    }
}
