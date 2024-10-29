﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Numerics;
using Spring_Microfinance_Management_System.Models;

namespace Spring_Microfinance_Management_System.Controllers
{
    public class TestPlanController : Controller
    {
        public object Financial { get; private set; }

        // GET: TestPlan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GenerateRepaymentSchedule(TestPlan loan)
        {
            loan.InterestRate = 0.300M;
            loan.LoanAmount = 1000000;
            loan.StartDate = System.DateTime.Now;
            loan.TermInMonths = 10;
            decimal monthlyInterestRate = loan.InterestRate / 12;
            decimal monthlyRepayment = (loan.LoanAmount * monthlyInterestRate) / (1 - (decimal)Math.Pow(1 + (double)monthlyInterestRate, -loan.TermInMonths));

            
            decimal remainingBalance = loan.LoanAmount;

            List<TestPlan> repaymentSchedule = new List<TestPlan>();

            for (int i = 1; i <= loan.TermInMonths; i++)
            {
                TestPlan repayment = new TestPlan();
                repayment.RepaymentAmount = monthlyRepayment;
                repayment.RepaymentDate = loan.StartDate.AddMonths(i);
                repayment.InterestPaid = remainingBalance * loan.InterestRate / 12;
                repayment.PrincipalPaid = monthlyRepayment - repayment.InterestPaid;
                remainingBalance -= repayment.PrincipalPaid;
                repayment.RemainingBalance = remainingBalance;
                repaymentSchedule.Add(repayment);
            }

            return View(repaymentSchedule);
        }
    }
}