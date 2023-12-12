namespace EasyAuthentication.Models.Entity
{
    public class UserSession
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid Id { get; set; }
        public string Token { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime ExpireDateTime { get; set; }
        public bool IsActive { get; set; }
        public string Ip { get; set; }
        public string Browser { get; set; }

    }
}
