using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spring_Microfinance_Management_System.Common;

namespace Spring_Microfinance_Management_System.Models
{
    public class LoginInfo
    {

        public static string UserID
        {
            get
            {
                return (string)HttpContext.Current.Session[KeyName.UserID];
            }

            set
            {
                HttpContext.Current.Session[LoginInfo.KeyName.UserID] = value;
            }
        }

        public static string UserName
        {
            get
            {
                return (string)HttpContext.Current.Session[KeyName.UserName];
            }

            set
            {
                HttpContext.Current.Session[LoginInfo.KeyName.UserName] = value;
            }
        }

        public static string RoleID
        {
            get
            {
                return (string)HttpContext.Current.Session[KeyName.RoleID];
            }

            set
            {
                HttpContext.Current.Session[LoginInfo.KeyName.RoleID] = value;
            }
        }
        

      
        public class KeyName
        {
            
            public const string LoginInfo = "LoginInfo";

            public const string UserID = "UserId";

            public const string UserName = "UserName";

            public const string RoleID = "RoleID";
        
        }

    }
}