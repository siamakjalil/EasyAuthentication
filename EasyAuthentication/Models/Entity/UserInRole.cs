
using System.ComponentModel.DataAnnotations;
using EasyAuthentication.Models.Entity.Common;

namespace EasyAuthentication.Models.Entity
{
    public class UserInRole : BaseIdentity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        [Key]
        public int Id { get; set; }
    }
}
