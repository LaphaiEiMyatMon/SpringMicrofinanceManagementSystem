using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spring_Microfinance_Management_System.Common;
using Spring_Microfinance_Management_System.Models.Base;

namespace Spring_Microfinance_Management_System.Models
{
    public class Loan : BaseDA
    {
        public Loan()
        {
            this.CustomerEntity = new BaseTB_CustomerEntity();
            this.GuarantorEntity = new BaseTB_GuarantorEntity();
            this.LoanEntity = new BaseTB_LoanEntity();
            this.RepaymentPlanEntity = new BaseTB_RepaymentPlanEntity();
            this.ProductTypeEntity = new BaseTB_ProductTypeEntity();
            this.ProductTypeList = this.GetProductTypeList();
            this.InterestRateList = this.GetInterestRateList();
            this.LoanApplicationList = new List<BaseTB_LoanEntity>();
        }

        public BaseTB_CustomerEntity CustomerEntity { get; set; }

        public BaseTB_GuarantorEntity GuarantorEntity { get; set; }

        public BaseTB_LoanEntity LoanEntity { get; set; }

        public BaseTB_ProductTypeEntity ProductTypeEntity { get; set; }

        public BaseTB_RepaymentPlanEntity RepaymentPlanEntity { get; set; }

        public List<BaseTB_LoanEntity> LoanApplicationList { get; set; }

        public Dictionary<string, string> InterestRateList { get; set; }

        public Dictionary<string, string> ProductTypeList { get; set; }

        public int TotalCount { get; set; }

        public int Status { get; set; }

        #region "Get Product Type List"
        public Dictionary<string, string> GetProductTypeList()
        {
            BaseTB_ProductType role = new BaseTB_ProductType();
            Dictionary<string, string> result = new Dictionary<string, string>();

            List<BaseTB_ProductTypeEntity> list = role.GetDataList();

            foreach (var row in list)
            {
                result[row.ProductTypeID.ToString()] = row.ProductType;
            }

            return result;
        }
        #endregion

        #region "Get Interest Rate List"
        public Dictionary<string, string> GetInterestRateList()
        {
            BaseTB_InterestRate role = new BaseTB_InterestRate();
            Dictionary<string, string> result = new Dictionary<string, string>();

            List<BaseTB_InterestRateEntity> list = role.GetDataList();

            foreach (var row in list)
            {
                result[row.InterestRate.ToString()] = string.Format("{0:0.00%}", row.InterestRate);
            }

            return result;
        }
        #endregion

        #region "Update CustomerInfo And Insert Data into LoanApplication"
        public ResultStatus UpdateCustomerInfoAndAddLoanInfo(Loan entityInfo)
        {
            decimal administrationfees = 0.05M;
            ResultStatus result = new ResultStatus();
            this.CustomerEntity = entityInfo.CustomerEntity;
            this.LoanEntity = entityInfo.LoanEntity;
            this.CustomerEntity.CustomerID = int.Parse(LoginInfo.UserID);
            this.LoanEntity.CustomerID = int.Parse(LoginInfo.UserID);
            this.LoanEntity.LoanRegistrationDate = System.DateTime.Now;
            this.LoanEntity.InterestAmount = entityInfo.LoanEntity.LoanAmount * entityInfo.LoanEntity.InterestRate;
            this.LoanEntity.Administrationfee = entityInfo.LoanEntity.LoanAmount * administrationfees;
            this.LoanEntity.TotalAmount = this.LoanEntity.LoanAmount + this.LoanEntity.InterestAmount;


            Customer customer = new Customer();
            customer.UpdateData(this.CustomerEntity);

            this.AddData(this.LoanEntity);
            return result;

        }
        #endregion

        #region Update Loan Application, Calculate and Insert Repayment Plan, Insert Repayment
         public ResultStatus ApproveLoanProcess(Loan loan)
        {
            ResultStatus result = new ResultStatus();

            if (loan.LoanEntity.JudgementStatus == JudgementStatus.UnderJudgement)
            {
                return result;
            }

            if (loan.LoanEntity.JudgementStatus == JudgementStatus.Approve)
            { loan.LoanEntity.LoanApprovalDate = System.DateTime.Today; }


            this.UpdateData(loan);

            RepaymentPlan plan = new RepaymentPlan();
            plan.CalculateAndInsertRepaymentPlan(loan);
            return result;
        }
        #endregion

        #region Get Loan Application Lists
        public void GetLoanApplicationList(Loan loan)
        {
            BaseTB_Loan loanDA = new BaseTB_Loan();
            this.LoanApplicationList = loanDA.GetDataList(loan);
            this.TotalCount = this.LoanApplicationList.Count();
        }
        #endregion

        #region Get Loan Application 
        public void GetLoanApplication(Loan loan)
        {
           
            BaseTB_Loan loanDA = new BaseTB_Loan();
            this.LoanEntity = loanDA.GetData(loan);
          
        }
        #endregion

        #region Search By Judgement Status
        public void SearchByStatus(string status)
        {
            BaseTB_Loan loanDA = new BaseTB_Loan();
            this.LoanApplicationList = loanDA.SearchByStatus(status);
        }
        #endregion

        #region "Add Data"
        public ResultStatus AddData(BaseTB_LoanEntity loanEntity)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Loan loan = new BaseTB_Loan();

            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampCreated(this.LoanEntity);
                    loan.DataInsert(con, tran, this.LoanEntity);
                    tran.Commit();
                }
                catch (Exception exp)
                {
                    tran.Rollback();
                    result.Status = false;
                    result.Message = exp.Message;

                }
                return result;

            }
        }
        #endregion

        #region "Update Data"
        public ResultStatus UpdateData(Loan loan)
        {
            ResultStatus result = new ResultStatus();

            if (loan.LoanEntity.JudgementStatus == JudgementStatus.UnderJudgement)
            {
                return result;
            }

            else if (loan.LoanEntity.JudgementStatus == JudgementStatus.Reject)
            { loan.LoanEntity.LoanRejectDate = System.DateTime.Today; }
           
            BaseTB_Loan loanBase = new BaseTB_Loan();
            this.LoanEntity = loan.LoanEntity;
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {

                    this.StampCreated(this.LoanEntity);
                    loanBase.DataUpdate(con, tran, this.LoanEntity);

                    tran.Commit();
                }
                catch (Exception exp)
                {
                    tran.Rollback();
                    result.Message = exp.Message;
                }
                return result;

            }
        }
        #endregion

        #region "Delete Data"
        public ResultStatus DeleteData(int loanApplicationID)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_InterestRate role = new BaseTB_InterestRate();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {                 
                    role.DataDelete(con, tran, loanApplicationID);
                    tran.Commit();
                }
                catch (Exception exp)
                {
                    tran.Rollback();
                    result.Message = exp.Message;
                }
                return result;

            }
        }
        #endregion

    }


    public enum JudgementStatus
    {
        UnderJudgement,
        Approve,
        Reject,
        Cancel
    }



}