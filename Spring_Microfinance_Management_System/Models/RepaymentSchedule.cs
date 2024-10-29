using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spring_Microfinance_Management_System.Models
{
    public class RepaymentSchedule
    {
        public decimal RepaymentAmount { get; set; }
        public DateTime RepaymentDate { get; set; }
        public decimal PrincipalPaid { get; set; }
        public decimal InterestPaid { get; set; }
        public decimal RemainingBalance { get; set; }
    }
}