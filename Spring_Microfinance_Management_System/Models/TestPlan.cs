using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spring_Microfinance_Management_System.Models
{
    public class TestPlan
    {
        public decimal LoanAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int TermInMonths { get; set; }
        public DateTime StartDate { get; set; }
        public decimal RepaymentAmount { get; set; }
        public DateTime RepaymentDate { get; set; }
        public decimal PrincipalPaid { get; set; }
        public decimal InterestPaid { get; set; }
        public decimal RemainingBalance { get; set; }
    }


}