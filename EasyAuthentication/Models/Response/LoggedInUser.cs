namespace EasyAuthentication.Models.Response
{
    public class LoggedInUser
    {
        public Guid Id { get; set; }
        public Guid UserUniqueId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string MobileNumber { get; set; } 
        public int Type { get; set; }
        public string Token { get; set; }
        public bool NewUser { get; set; }
        public string Rols { get; set; }

    }
}
