using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAuthentication.Models.Response
{
    public class RoleDto
    { 
        public int Id { get; set; } 
        public string Title { get; set; }
    }
}
