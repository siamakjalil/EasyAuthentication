

using EasyAuthentication.Models.Response;

namespace EasyAuthentication.Enums
{
    public enum UserType
    {
        Real = 1,
        Legal=2
    }

    public static class UserTypeHelper
    {
        public static string GetUserTypeVal(this int type)
        {
            return type switch
            {
                (int)UserType.Legal => UserType.Legal.ToString(),
                (int)UserType.Real => UserType.Real.ToString(),
                _ => ""
            };
        }
        public static List<DropDownModel> GetUserTypeList()
        {
            return new List<DropDownModel>()
            {
                new DropDownModel()
                {
                    Id = (int)UserType.Real,
                    Title = ((int)UserType.Real).GetUserTypeVal(),
                },
                new DropDownModel()
                {
                    Id = (int)UserType.Legal,
                    Title = ((int)UserType.Legal).GetUserTypeVal(),
                },
            };
        }
        public static string GetUserTypeBadge(this int type)
        {
            return type switch
            {
                (int)UserType.Real => "badge bg-primary",
                (int)UserType.Legal => "badge bg-warning", 
                _ => ""
            };
        }
    }
}
