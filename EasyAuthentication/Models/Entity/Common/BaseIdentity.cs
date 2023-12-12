namespace EasyAuthentication.Models.Entity.Common
{
    public class BaseIdentity
    {
        public DateTime DateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public Guid? CreateBy { get; set; }
        public Guid? UpdateBy { get; set; }
        public bool IsActive { get; set; }
    }
}
