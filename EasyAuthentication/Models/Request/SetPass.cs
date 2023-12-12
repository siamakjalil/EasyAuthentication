namespace EasyAuthentication.Models.Request
{
    public class SetPass 
    {
        public Guid? UserId { get; set; }
        public string Pass { get; set; }
        public string RePass { get; set; }

        //if need to set userType here
        public int? UserType { get; set; }
    }
}
