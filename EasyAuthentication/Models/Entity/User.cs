using System.ComponentModel.DataAnnotations;
using EasyAuthentication.Models.Entity.Common;

namespace EasyAuthentication.Models.Entity
{
    /// <summary>
    /// Base of user in system
    /// userType is legal or real
    /// </summary>
    public class User :BaseIdentity
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(11)]
        public string MobileNumber { get; set; }
        [MaxLength(150)]
        public string? FirstName { get; set; }
        [MaxLength(150)]
        public string? LastName { get; set; }
        [MaxLength(150)]
        public string? Email { get; set; }
        [MaxLength(50)]
        public string ActiveCode { get; set; }
        public int UserType { get; set; }
        public int? Gender { get; set; }
        [MaxLength(150)]
        public string? Password { get; set; }
        [MaxLength(10)]
        public string? Key { get; set; }
        [MaxLength(50)]
        public string? Image { get; set; }
        public DateTime? BornDateTime { get; set; }
        public Guid UniqueId { get; set; }

    }
}
