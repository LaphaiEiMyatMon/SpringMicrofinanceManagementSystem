using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spring_Microfinance_Management_System.Models
{
    public class ResultStatus
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public int totalCount { get; set; }
        public dynamic Data { get; set; }

        public ResultStatus()
        {
            Status = true;
            Message = String.Empty;
            Data = null;
        }
    }
}