using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spring_Microfinance_Management_System.Common
{
    public class SearchResultObject
    {
        public int totalCount { get; set; }
        
        public List<SearchResultRecordBase> records { get; set; }

        public string sortTypeFlg { get; set; }
    }
}