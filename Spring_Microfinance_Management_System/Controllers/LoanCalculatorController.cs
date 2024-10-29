using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spring_Microfinance_Management_System.Models;

namespace Spring_Microfinance_Management_System.Controllers
{
    public class LoanCalculatorController : Controller
    {
        // GET: LoanCalculator
        public ActionResult LoanCalculator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoanCalculator(LoanCalculator loan)
        {
            decimal loanAmount = loan.LoanAmount;
            decimal interestRate = loan.InterestRate;
            int monthsToPay = loan.TermInMonths;

            decimal totalInterestAmount = loanAmount * interestRate;
            decimal totalAmount = loanAmount + totalInterestAmount;
            decimal monthlyRepayment = totalAmount / monthsToPay;
            decimal monthlyInterestAmount = (loanAmount * interestRate) / monthsToPay;
            decimal monthlyPrincipalAmount = monthlyRepayment - monthlyInterestAmount;
            ViewBag.MonthlyPayment = monthlyRepayment;
            ViewBag.TotalPayment = totalAmount;

            return View();
        }

        public ActionResult Calculator()
        {
            ViewBag.Message = "Loan Calculator Page";
            return View();
        }

        [HttpPost]
        public ActionResult Calculator(LoanCalculator loan)
        {
            decimal loanAmount = loan.LoanAmount;
            decimal interestRate = loan.InterestRate;
            int monthsToPay = loan.TermInMonths;

            decimal totalInterestAmount = loanAmount * interestRate;
            decimal totalAmount = loanAmount + totalInterestAmount;
            decimal monthlyRepayment = totalAmount / monthsToPay;
            decimal monthlyInterestAmount = (loanAmount * interestRate) / monthsToPay;
            decimal monthlyPrincipalAmount = monthlyRepayment - monthlyInterestAmount;
            ViewBag.MonthlyPayment = monthlyRepayment;
            ViewBag.TotalPayment = totalAmount;
            ViewBag.Message = "Loan Calculator Page";
            return View();
        }

    }
}