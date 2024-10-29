using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spring_Microfinance_Management_System.Models
{
    public class LoanCalculator
    {
        public decimal LoanAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int TermInMonths { get; set; }
    }
}