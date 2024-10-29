using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Spring_Microfinance_Management_System.Extension;
using System.Linq;
using System.Web;

namespace Spring_Microfinance_Management_System.Models.Base
{
    
    public class BaseTB_RepaymentEntity
    {

        public BaseTB_RepaymentEntity()
        {
            this.RepaymentPlanEntity = new BaseTB_RepaymentPlanEntity();
        }
        #region private
        private int _repaymentID;
        private int _loanApplicationID;
        private DateTime? _deadline;
        private DateTime? _repaymentDate;
        private decimal _repaymentAmount;
        private int _customerID;
        private string _paymentMethod;
        private decimal _originalLoanAmount;
        private decimal _interestRate;
        private int _repaymentTime;
        private decimal _monthlyInterestAmount;
        private decimal _monthlyPrincipalAmount;
        private decimal _monthlyTotalAmount;
        private decimal _grandTotalRepaymentAmount;
        private decimal _remainingDebt;
        private int _mobileWalletAccount;
        private int _bankAccNo;
        private string _cardNumber;
        private string _cardHolderName;
        private string _expirationDate;
        private int _cvv;
        private Boolean _fullRepaymentFlag;
        private Boolean _borrowFlag;
        private DateTime? _createdAt;
        private string _createdBy;
        private DateTime? _updatedAt;
        private string _updatedBy;
        #endregion

        #region public

        public int RepaymentID { get { return this._repaymentID; } set { this._repaymentID = value; } }

        public int LoanApplicationID { get { return this._loanApplicationID; } set { this._loanApplicationID = value; } }

        public DateTime DeadLine { get { return this._deadline.ToNonNullable(); } set { this._deadline = value; } }

        public DateTime RepaymentDate { get { return this._repaymentDate.ToNonNullable(); } set { this._repaymentDate = value; } }

        [Required]
        public decimal RepaymentAmount { get { return this._repaymentAmount; } set { this._repaymentAmount = value; } }

        public int CustomerID { get { return this._customerID; } set { this._customerID = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PaymentMethod { get { return this._paymentMethod; } set { this._paymentMethod = value; } }

        public decimal OriginalLoanAmount { get { return this._originalLoanAmount; } set { this._originalLoanAmount = value; } }

        public decimal InterestRate { get { return this._interestRate; } set { this._interestRate = value; } }

        public int RepaymentTime { get { return this._repaymentTime; } set { this._repaymentTime = value; } }

        public decimal MonthlyInterestAmount { get { return this._monthlyInterestAmount; } set { this._monthlyInterestAmount = value; } }

        public decimal MonthlyPrincipalAmount { get { return this._monthlyPrincipalAmount; } set { this._monthlyPrincipalAmount = value; } }

        public decimal MonthlyTotalAmount { get { return this._monthlyTotalAmount; } set { this._monthlyTotalAmount = value; } }

        public decimal GrandTotalRepaymentAmount { get { return this._grandTotalRepaymentAmount; } set { this._grandTotalRepaymentAmount = value; } }

        public decimal RemainingDebt { get { return this._remainingDebt; } set { this._remainingDebt = value; } }

        [Required]
        public int MobileWalletAccount { get { return this._mobileWalletAccount; } set { this._mobileWalletAccount = value; } }

        [Required]
        public int BankAccNo { get { return this._bankAccNo; } set { this._bankAccNo = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CardNumber { get { return this._cardNumber; } set { this._cardNumber = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CardHolderName { get { return this._cardHolderName; } set { this._cardHolderName = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ExpirationDate { get { return this._expirationDate; } set { this._expirationDate = value; } }

        [Required]
        public int CVV { get { return this._cvv; } set { this._cvv = value; } }

        public Boolean FullRepaymentFlag { get { return this._fullRepaymentFlag; } set { this._fullRepaymentFlag = value; } }

        public Boolean BorrowFlag { get { return this._borrowFlag; } set { this._borrowFlag = value; } }

        public DateTime CreatedAt { get { return this._createdAt.ToNonNullable(); } set { this._createdAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CreatedBy { get { return this._createdBy; } set { this._createdBy = value; } }

        public DateTime UpdatedAt { get { return this._updatedAt.ToNonNullable(); } set { this._updatedAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }

        

        public BaseTB_RepaymentPlanEntity RepaymentPlanEntity { get; set; }
        #endregion

        #region Is Null

        public bool IsRepaymentIDNull() { return this._repaymentID == 0; }

        public bool IsLoanApplicationIDNull() { return this._loanApplicationID == 0 ; }

        public bool IsDeadLineNull() { return this._deadline == null; }

        public bool IsRepaymentDateNull() { return this._repaymentDate == null; }

        public bool IsRepaymentAmountNull() { return this._repaymentAmount == 0; }

        public bool IsCustomerIDNull() { return this._customerID == 0; }

        public bool IsPaymentMethodNull() { return this._paymentMethod == null; }

        public bool IsOriginalLoanAmountNull() { return this._originalLoanAmount == 0; }

        public bool IsInterestRateNull() { return this._interestRate == 0; }

        public bool IsRepaymentTimeNull() { return this._repaymentTime == 0; }

        public bool IsMonthlyInterestAmountNull() { return this._monthlyInterestAmount == 0; }

        public bool IsMonthlyPrincipalAmountNull() { return this._monthlyPrincipalAmount == 0; }

        public bool IsMonthlyTotalAmountNull() { return this._monthlyTotalAmount == 0; }

        public bool IsGrandTotalRepaymentAmountNull() { return this._grandTotalRepaymentAmount == 0; }

        public bool IsRemainingDebtNull() { return this._remainingDebt == 0; }

        public bool IsMobileWalletAccountNull() { return this._mobileWalletAccount == 0; }

        public bool IsBankAccNoNull() { return this._bankAccNo == 0; }

        public bool IsCardNumberNull() { return this._cardNumber == null; }

        public bool IsCardHolderNameNull() { return this._cardHolderName == null; }

        public bool IsExpirationDateNull() { return this._expirationDate == null; }

        public bool IsCVVNull() { return this._cvv == 0; }

        public bool IsFullRepaymentFlagNull() { return this._fullRepaymentFlag == false; }

        public bool IsBorrowFlagNull() { return this._borrowFlag == false; }

        public bool IsCreatedAtNull() { return this._createdAt == null; }

        public bool IsCreatedByNull() { return this._createdBy == null; }

        public bool IsUpdatedAtNull() { return this._updatedAt == null; }

        public bool IsUpdatedByNull() { return this._updatedBy == null; }

        #endregion

    }
}