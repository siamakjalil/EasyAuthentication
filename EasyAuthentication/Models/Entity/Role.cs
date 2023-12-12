using System.ComponentModel.DataAnnotations;
using EasyAuthentication.Models.Entity.Common;

namespace EasyAuthentication.Models.Entity
{
    public class Role:BaseIdentity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Title { get; set; } 
    }
}
