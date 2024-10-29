using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spring_Microfinance_Management_System.Common
{
    public class W2uiSearchCondition
    {
      
        public string Field { get; set; }
        
        public string Type { get; set; }
       
        public string Operator { get; set; }
        
        public string Value { get; set; }
      
        public string[] Values { get; set; }
    }
}