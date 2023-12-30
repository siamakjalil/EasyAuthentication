using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAuthentication.Models.Request
{
    public class RegisterDto
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; }
        public int? Gender { get; set; }
        public DateTime? BornDateTime { get; set; }
        public string? Image { get; set; }
        public string? ImageUpload { get; set; }
        public int Age { get; set; }
        public string MobileNumber { get; set; }
    }
}
