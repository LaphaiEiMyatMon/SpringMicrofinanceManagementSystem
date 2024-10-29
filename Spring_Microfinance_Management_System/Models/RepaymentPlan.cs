using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spring_Microfinance_Management_System.Models.Base;

namespace Spring_Microfinance_Management_System.Models
{
    public class RepaymentPlan
    {
        public RepaymentPlan()
        {
            this.PlanList = new List<BaseTB_RepaymentPlanEntity>();
            this.PlanEntity = new BaseTB_RepaymentPlanEntity();
        }

        public List<BaseTB_RepaymentPlanEntity> PlanList { get; set; }

        public int TotalCount { get; set; }

        public BaseTB_RepaymentPlanEntity PlanEntity { get; set; }

        public DateTime StartDate { get; set; }

        public ResultStatus CalculateAndInsertRepaymentPlan(Loan loan)
        {
            this.StartDate = System.DateTime.Today;
            ResultStatus result = new ResultStatus();

            decimal loanAmount = loan.LoanEntity.LoanAmount;
            decimal interestRate = loan.LoanEntity.InterestRate;           
            int monthsToPay = loan.LoanEntity.MonthsToPay;

            decimal totalInterestAmount = loanAmount * interestRate;
            decimal totalAmount = loanAmount + totalInterestAmount;
            decimal monthlyRepayment = totalAmount / monthsToPay;
            decimal monthlyInterestAmount = (loanAmount * interestRate) / monthsToPay;
            decimal monthlyPrincipalAmount = monthlyRepayment - monthlyInterestAmount;


            List<TestPlan> repaymentSchedule = new List<TestPlan>();

            var list = new List<BaseTB_RepaymentPlanEntity>();
            BaseTB_RepaymentPlan plan = new BaseTB_RepaymentPlan();

            //Insert into TB_Repayment Plan
            for (int i = 1; i <= monthsToPay; i++)
            {
                BaseTB_RepaymentPlanEntity planEntity = new BaseTB_RepaymentPlanEntity();

                planEntity.LoanApplicationID = loan.LoanEntity.LoanApplicationID;
                planEntity.CustomerID = loan.LoanEntity.CustomerID;
                planEntity.OriginalLoanAmount = loan.LoanEntity.LoanAmount;
                planEntity.InterestRate = loan.LoanEntity.InterestRate;
                planEntity.MonthlyRepaymentDate = this.StartDate.AddMonths(i);
                planEntity.Count = i;
                planEntity.MonthlyTotalAmount = monthlyRepayment;
                planEntity.MonthlyInterestAmount = monthlyInterestAmount;
                planEntity.MonthlyPrincipalAmount = monthlyPrincipalAmount;
                
                this.AddData(planEntity);

            }

            //Insert into TB_Repayment
            Repayment repayment = new Repayment();
            BaseTB_RepaymentEntity entityInfo = new BaseTB_RepaymentEntity();
            entityInfo.LoanApplicationID = loan.LoanEntity.LoanApplicationID;
            entityInfo.CustomerID = loan.LoanEntity.CustomerID;
            entityInfo.DeadLine = this.StartDate.AddMonths(1);
            entityInfo.OriginalLoanAmount = loan.LoanEntity.LoanAmount;
            entityInfo.InterestRate = loan.LoanEntity.InterestRate;
            entityInfo.RepaymentTime = loan.LoanEntity.MonthsToPay;
            entityInfo.MonthlyTotalAmount = monthlyRepayment;
            entityInfo.MonthlyInterestAmount = monthlyInterestAmount;
            entityInfo.MonthlyPrincipalAmount = monthlyPrincipalAmount;
            entityInfo.GrandTotalRepaymentAmount = totalAmount;
            entityInfo.RemainingDebt = totalAmount;
            entityInfo.BorrowFlag = true;
            repayment.AddData(entityInfo);

            return result;

        }


        #region "Add Data"
        public ResultStatus AddData(BaseTB_RepaymentPlanEntity entityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_RepaymentPlan plan = new BaseTB_RepaymentPlan();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {

                    plan.DataInsert(con, tran, entityInfo);
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

        #region "Update Data"
        public ResultStatus UpdateData(BaseTB_RepaymentPlanEntity entityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_RepaymentPlan repayment = new BaseTB_RepaymentPlan();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {

                    repayment.DataUpdate(con, tran, entityInfo);

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

        #region Get Repayment Plan List
        public void GetRepaymentPlanList(int customerID)
        {
            BaseTB_RepaymentPlan plan = new BaseTB_RepaymentPlan();
            this.PlanList = plan.GetDataList(customerID);
            this.TotalCount = this.PlanList.Count();
        }
        #endregion










    }
}