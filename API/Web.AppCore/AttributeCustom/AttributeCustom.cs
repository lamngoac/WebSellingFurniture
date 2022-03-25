//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;


//namespace Web.AppCore.AttributeCustom
//{
//    /// <summary>
//    /// Attribute để kiểm tra dữ liệu chống của property
//    /// </summary>
//    [AttributeUsage(AttributeTargets.Property)]
//    public class TRequired : Attribute
//    {
//        /// <summary>
//        /// Loại Resource
//        /// </summary>
//        public Type? ErrorResourceType { get; set; }
//    }

//    /// <summary>
//    /// Attribute để kiểm tra validate format của property email
//    /// </summary>
//    [AttributeUsage(AttributeTargets.Property)]
//    public class TEmailValidate : Attribute
//    {
//        public static bool ValidateEmail(string email)
//        {
//            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
//            Match match = regex.Match(email);
//            if (match.Success)
//                return true;
//            return false;
//        }

//    }

//}
