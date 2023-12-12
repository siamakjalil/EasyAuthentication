using EasyAuthentication.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAuthentication.Tools
{

    public static class ResponseManager
    {
        public static ServiceMessage ServerError() => new ServiceMessage()
        {
            ErrorId = -1,
            ErrorTitle = "خطای سیستمی رخ داده، مجددا تلاش کنید."
        };

        public static ServiceMessage SessionExpire() => new ServiceMessage()
        {
            ErrorId = -21,
            ErrorTitle = "مدت زمان مجاز شما برای حضور در نرم افزار به پایان رسیده است لطفا مجددا وارد شوید."
        };

        public static ServiceMessage DataError(string title) => new ServiceMessage()
        {
            ErrorId = -2,
            ErrorTitle = title
        };

        public static ServiceMessage FillObject(object obj) => new ServiceMessage()
        {
            ErrorId = 0,
            Result = obj
        };

        public static ServiceMessage ActivationError() => new ServiceMessage()
        {
            ErrorId = -2,
            ErrorTitle = "کد فعالسازی اشتباه وارد شده است."
        };

        public static ServiceMessage UserNotFound() => new ServiceMessage()
        {
            ErrorId = -2,
            ErrorTitle = "کاربر یافت نشد"
        };

        public static ServiceMessage LoginWithPass() => new ServiceMessage()
        {
            ErrorId = 22,
            ErrorTitle = (string)null,
            Result = (object)null
        };

        public static ServiceMessage CustoMessage(int id, string title, string res) => new ServiceMessage()
        {
            ErrorId = id,
            ErrorTitle = title,
            Result = (object)res
        };

        public static ServiceMessage CustoMessage(int id, string title, object res) => new ServiceMessage()
        {
            ErrorId = id,
            ErrorTitle = title,
            Result = res
        };
    }
}
