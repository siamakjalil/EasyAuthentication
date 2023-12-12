using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace EasyAuthentication.Models.Response
{
    public class UserListDto
    {
        public List<UserDto> Users { get; set; }
        public int Count { get; set; }
        public int PageId { get; set; }
    }
}
