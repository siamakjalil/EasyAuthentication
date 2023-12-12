using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAuthentication.Models.Request
{
    public class FilterUserDto
    {
        public string? SearchText { get; set; } = "";
        public string? PersianDate { get; set; } = "";
        public int PageId { get; set; } = 1;
        public int Take { get; set; }
        public int UserType { get; set; }
        public List<Guid> UserIds { get; set; }
        public bool CheckPendingUsers { get; set; }
    }
}
