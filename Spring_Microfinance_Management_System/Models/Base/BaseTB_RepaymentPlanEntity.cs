using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spring_Microfinance_Management_System.Extension;

namespace Spring_Microfinance_Management_System.Models.Base
{
    public class BaseTB_RepaymentPlanEntity
    {
        

        #region private

        private int _repaymentPlanSeq;
        private DateTime? _monthlyRepaymentDate;
        private int _loanApplicationID;
        private int _customerID;
        private int _count;
        private decimal _originalLoanAmount;
        private decimal _interestRate;
        private decimal _monthlyInterestAmount;
        private decimal _monthlyPrincipalAmount;
        private decimal _monthlyTotalAmount;
        private bool _status;


        #endregion

        #region Public
        public int RepaymentPlanSeq { get { return this._repaymentPlanSeq; } set { this._repaymentPlanSeq = value; } }
        public DateTime MonthlyRepaymentDate { get { return this._monthlyRepaymentDate.ToNonNullable(); } set { this._monthlyRepaymentDate = value; } }
        public int LoanApplicationID { get { return this._loanApplicationID; } set { this._loanApplicationID = value; } }
        public int CustomerID { get { return this._customerID; } set { this._customerID = value; } }
        public int Count { get { return this._count; } set { this._count = value; } }
        public decimal OriginalLoanAmount { get { return this._originalLoanAmount; } set { this._originalLoanAmount = value; } }
        public decimal InterestRate { get { return this._interestRate; } set { this._interestRate = value; } }
        public decimal MonthlyInterestAmount { get { return this._monthlyInterestAmount; } set { this._monthlyInterestAmount = value; } }
        public decimal MonthlyPrincipalAmount { get { return this._monthlyPrincipalAmount; } set { this._monthlyPrincipalAmount = value; } }
        public decimal MonthlyTotalAmount { get { return this._monthlyTotalAmount; } set { this._monthlyTotalAmount = value; } }
        public bool Status { get { return this._status; } set { this._status = value; } }
        #endregion

        #region "IsNull"

        public bool IsRepaymentPlanSeqNull() { return this._repaymentPlanSeq == 0; }

        public bool IsMonthlyRepaymentDateNull() { return this._monthlyRepaymentDate == null; }

        public bool IsLoanApplicationIDNull() { return this._loanApplicationID == 0; }

        public bool IsCustomerIDNull() { return this._customerID == 0; }

        public bool IsCountNull() { return this._count == 0; }

        public bool IsOriginalLoanAmountNull() { return this._originalLoanAmount == 0; }

        public bool IsInterestRateNull() { return this._interestRate == 0; }

        public bool IsMonthlyInterestAmountNull() { return this._monthlyInterestAmount == 0; }

        public bool IsMonthlyPrincipalAmountNull() { return this._monthlyPrincipalAmount == 0; }

        public bool IsMonthlyTotalAmountNull() { return this._monthlyTotalAmount == 0; }

        public bool IsStatusNull() { return this._status == false; }


        #endregion

        #region "SetNull"

        public void SetRepaymentPlanSeqNull() {  this._repaymentPlanSeq = 0; }

        public void SetMonthlyRepaymentDateNull() {  this._monthlyRepaymentDate = null; }

        public void SetLoanApplicationIDNull() {  this._loanApplicationID = 0; }

        public void SetCustomerIDNull() {  this._customerID = 0; }

        public void SetCountNull() {  this._count = 0; }

        public void SetOriginalLoanAmountNull() {  this._originalLoanAmount = 0; }

        public void SetInterestRateNull() {  this._interestRate = 0; }

        public void SetMonthlyInterestAmountNull() {  this._monthlyInterestAmount = 0; }

        public void SetMonthlyLoanAmountNull() {  this._monthlyPrincipalAmount = 0; }

        public void SetMonthlyTotalAmountNull() {  this._monthlyTotalAmount = 0; }

        public void SetStatusNull() { this._status = false; }
        #endregion

    }
}