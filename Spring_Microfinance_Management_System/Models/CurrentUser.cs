using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spring_Microfinance_Management_System.Models
{
    public class CurrentUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
       
        public bool IsAuth { get; set; }
        
        public bool ForceToChangePW { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }

        public DateTime SessionEndDate { get; set; }
        public string RoleName { get; set; }

        public CurrentUser()
        {
            ID = 0;
            Name = "";
            RoleID = 9;
            ForceToChangePW = false;
            
            IsAuth = false;
            Password = "";
            SessionEndDate = DateTime.Now;
            RoleName = "";
        }
    }
}