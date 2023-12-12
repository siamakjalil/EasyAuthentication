using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAuthentication.Models.Response
{
    public class ServiceMessage
    {
        public int ErrorId { get; set; }

        public string? ErrorTitle { get; set; }

        public object? Result { get; set; }
    }
}
