using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace EasyAuthentication.Models.Response
{
    public class UserRoleDto
    {
        public int UserRoleId { get; set; }
        public int RoleId { get; set; }
        public string RoleTitle { get; set; }
    }
}
