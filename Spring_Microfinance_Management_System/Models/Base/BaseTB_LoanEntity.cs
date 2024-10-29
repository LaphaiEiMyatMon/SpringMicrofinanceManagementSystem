using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Spring_Microfinance_Management_System.Extension;

namespace Spring_Microfinance_Management_System.Models.Base
{
    public class BaseTB_LoanEntity
    {
        public BaseTB_LoanEntity()
        {
            this.CustomerEntity = new BaseTB_CustomerEntity();
            this.ProductTypeEntity = new BaseTB_ProductTypeEntity();
            this.GuarantorEntity = new BaseTB_GuarantorEntity();
        }


        #region "private"
        private int _loanApplicationID;
        private int _customerID;
        private DateTime? _loanRegistrationDate;
        private DateTime? _loanApprovalDate;
        private DateTime? _loanRejectDate;
        private int _productTypeID;
        private decimal? _interestRate;
        private decimal? _loanAmount;
        private decimal? _interestAmount;
        private decimal? _totalAmount;
        private int _monthsToPay;
        private decimal? _administrationfee;
        private JudgementStatus _status;
        private string _rejectReason;
        private DateTime? _createdAt;
        private string _createdBy;
        private DateTime? _updatedAt;
        private string _updatedBy;
        #endregion

        #region "public"
        public int LoanApplicationID { get { return this._loanApplicationID; } set { this._loanApplicationID = value; } }

        public int CustomerID { get { return this._customerID; } set { this._customerID = value; } }

       
        public DateTime LoanRegistrationDate { get { return this._loanRegistrationDate.ToNonNullable(); } set { this._loanRegistrationDate = value; } }

        public DateTime LoanApprovalDate { get { return this._loanApprovalDate.ToNonNullable(); } set { this._loanApprovalDate = value; } }

        public DateTime LoanRejectDate { get { return this._loanRejectDate.ToNonNullable(); } set { this._loanRejectDate = value; } }

        public int ProductTypeID { get { return this._productTypeID; } set { this._productTypeID = value; } }

        public decimal InterestRate { get { return this._interestRate.ToNonNullable(); } set { this._interestRate = value; } }

        [Required]
        public decimal LoanAmount { get { return this._loanAmount.ToNonNullable(); } set { this._loanAmount = value; } }

        [Required]
        public decimal InterestAmount { get { return this._interestAmount.ToNonNullable(); } set { this._interestAmount = value; } }

        public decimal TotalAmount { get { return this._totalAmount.ToNonNullable(); } set { this._totalAmount = value; } }

        public int MonthsToPay { get { return this._monthsToPay; } set { this._monthsToPay = value; } }

        public decimal Administrationfee { get { return this._administrationfee.ToNonNullable(); } set { this._administrationfee = value; } }

        [Required]      
        public JudgementStatus JudgementStatus { get { return this._status; } set { this._status = value; } }

        [Required]
        public string RejectReason { get { return this._rejectReason; } set { this._rejectReason = value; } }

        public DateTime CreatedAt { get { return this._createdAt.ToNonNullable(); } set { this._createdAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CreatedBy { get { return this._createdBy; } set { this._createdBy = value; } }

        public DateTime UpdatedAt { get { return this._updatedAt.ToNonNullable(); } set { this._updatedAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }    

        public BaseTB_CustomerEntity CustomerEntity { get; set; }

        public BaseTB_ProductTypeEntity ProductTypeEntity { get; set; }

        public BaseTB_GuarantorEntity GuarantorEntity { get; set; }

        public string status { get; set; }


        #endregion

        #region "Is Null"
        public bool IsLoanApplicationIDNull() { return this._loanApplicationID == 0; }

        public bool IsCustomerIDNull() { return this._customerID == 0; }

        public bool IsLoanRegistrationDateNull() { return this._loanRegistrationDate == null; }

        public bool IsLoanApprovalDateNull() { return this._loanApprovalDate == null; }

        public bool IsLoanRejectDateNull() { return this._loanRejectDate == null; }

        public bool IsProductTypeIDNull() { return this._productTypeID == 0; }

        public bool IsInterestRateNull() { return this._interestRate == null; }

        public bool IsLoanAmountNull() { return this._loanAmount == null; }

        public bool IsInterestAmountNull() { return this._interestAmount == null; }

        public bool IsTotalAmountNull() { return this._totalAmount == null; }

        public bool IsMonthsToPayNull() { return this._monthsToPay == 0; }

        public bool IsStatusNull() { return this._status == 0; }

        public bool IsAdministrationfeeNull() { return this._administrationfee == null; }

        public bool IsJudgementStatusNull() { return this._status == 0; }

        public bool IsRejectReasonNull() { return this._rejectReason == null; }

        public bool IsCreatedAtNull() { return this._createdAt == null; }

        public bool IsCreatedByNull() { return this._createdBy == null; }

        public bool IsUpdatedAtNull() { return this._updatedAt == null; }

        public bool IsUpdatedByNull() { return this._updatedBy == null; }

        #endregion

        #region "Set Null"

        public void SetLoanApplicationIDNull() { this._loanApplicationID = 0; }

        public void SetLoanRegistrationDateNull() { this._loanRegistrationDate = null; }

        public void SetLoanApprovalDateNull() { this._loanApprovalDate = null; }

        public void SetLoanRejectDateNull() { this._loanRejectDate = null; }

        public void SetProductTypeIDNull() { this._productTypeID = 0; }

        public void SetInterestRateNull() { this._interestRate = null; }

        public void SetLoanAmountNull() { this._loanAmount = null; }

        public void SetInterestAmountNull() { this._interestAmount = null; }

        public void SetTotalAmountNull() { this._totalAmount = null; }

        public void SetAdministrationfeeNull() { this._administrationfee = null; }

        public void SetCreatedAtNull() { this._createdAt = null; }

        public void SetCreatedByNull() { this._createdBy = null; }

        public void SetUpdatedAtNull() { this._updatedAt = null; }

        public void SetUpdatedByNull() { this._updatedBy = null; }

        #endregion


    }

   



}