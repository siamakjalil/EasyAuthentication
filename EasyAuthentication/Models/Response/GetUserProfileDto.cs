using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAuthentication.Models.Response
{
    public class GetUserProfileDto
    {  
        public string MobileNumber { get; set; } 
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public string? Email { get; set; }  
        public int UserType { get; set; }   
        public string? Image { get; set; }
        public DateTime? BornDateTime { get; set; }
        public string? PersianDateTime { get; set; }
        public int? Gender { get; set; }
    }
}
