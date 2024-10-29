using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spring_Microfinance_Management_System.Common;
using Spring_Microfinance_Management_System.Models.Base;

namespace Spring_Microfinance_Management_System.Models
{
    public class Repayment:BaseDA
    {
        public Repayment()
        {
            this.RepaymentEntity = new BaseTB_RepaymentEntity();
            this.RepaymentList = new List<BaseTB_RepaymentEntity>();
            this.RepaymentPlanEntity = new BaseTB_RepaymentPlanEntity();
            this.PaymentMethodList = GetPaymentMethodList();
        }

        public BaseTB_RepaymentEntity RepaymentEntity { get; set; }

        public List<BaseTB_RepaymentEntity> RepaymentList { get; set; }

        public Dictionary<string, string> PaymentMethodList { get; set; }

        public BaseTB_RepaymentPlanEntity RepaymentPlanEntity { get; set; }

        #region "Get PaymentMethod List"
        public Dictionary<string, string> GetPaymentMethodList()
        {
            BaseTB_PaymentMethod paymentMethod = new BaseTB_PaymentMethod();
            Dictionary<string, string> result = new Dictionary<string, string>();

            List<BaseTB_PaymentMethodEntity> list = paymentMethod.GetDataList();

            foreach (var row in list)
            {
                result[row.PaymentMethod.ToString()] = row.PaymentMethod;
            }

            return result;
        }
        #endregion
        #region "Get Data"
        public void GetData(int customerNo)
        {
            BaseTB_Repayment repayment = new BaseTB_Repayment();
            this.RepaymentEntity = repayment.GetData(customerNo);

        }
        #endregion

        #region "Get Data List"
        public void GetDataList(int customerNo)
        {
            BaseTB_Repayment repayment = new BaseTB_Repayment();
            this.RepaymentList = repayment.GetDataList(customerNo);

        }
        #endregion

        #region Register Repayment By Admin
        public ResultStatus RegisterRepayment(Repayment repayment)
        {
            var paymentMethod = repayment.RepaymentEntity.PaymentMethod;
            var repaymentAmount = repayment.RepaymentEntity.RepaymentAmount;

            ResultStatus result = new ResultStatus();
            BaseTB_Repayment baseModel = new BaseTB_Repayment();
            int customerID = repayment.RepaymentEntity.CustomerID;
            repayment.RepaymentEntity = baseModel.GetData(customerID);

            repayment.RepaymentEntity.PaymentMethod = paymentMethod;
            repayment.RepaymentEntity.RepaymentAmount = repaymentAmount;
            this.CalculationProcess(repayment);
            return result;
        }
        #endregion

        #region "Calculation And Updating some field"
        public ResultStatus CalculationProcess(Repayment repayment)
        {
            decimal repaymentAmount = 0;
            DateTime deadLine = repayment.RepaymentEntity.DeadLine.AddMonths(1);
            ResultStatus result = new ResultStatus();
            repayment.RepaymentEntity.RepaymentDate = System.DateTime.Today;
            repayment.RepaymentEntity.DeadLine = deadLine;

            if (repayment.RepaymentEntity.RepaymentAmount == 0)
            {
                 repaymentAmount = repayment.RepaymentEntity.MonthlyTotalAmount;
                 repayment.RepaymentEntity.RepaymentAmount = repaymentAmount;
            }
            else
            {
                repaymentAmount = repayment.RepaymentEntity.RepaymentAmount;
            }
            
            decimal debt = repayment.RepaymentEntity.RemainingDebt - repaymentAmount;
            repayment.RepaymentEntity.RemainingDebt = debt;
            if (debt == 0)
            {
                //Add Repayment
                repayment.RepaymentEntity.FullRepaymentFlag = true;
                this.RepaymentEntity = repayment.RepaymentEntity;               
                this.AddData(this.RepaymentEntity);

                //Update Repayment Plan
                BaseTB_RepaymentPlanEntity entity = new BaseTB_RepaymentPlanEntity();
                entity.Status = false;
                RepaymentPlan plan = new RepaymentPlan();
                plan.UpdateData(entity);

                this.RepaymentEntity.DeadLine = SystemDate.DefaultDate;               
                this.Transaction(this.RepaymentEntity);

            }
            else
            {
                this.RepaymentEntity = repayment.RepaymentEntity;
                this.AddData(this.RepaymentEntity);
                this.Transaction(this.RepaymentEntity);
            }
            
            return result;
        }
        #endregion

        #region "Add Data"
        public ResultStatus AddData(BaseTB_RepaymentEntity entityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Repayment repayment = new BaseTB_Repayment();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampCreated(entityInfo);
                    repayment.DataInsert(con, tran, entityInfo);
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

        #region "Update Remaining Debt and DeadLine"
        public ResultStatus Transaction(BaseTB_RepaymentEntity entityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Repayment repayment = new BaseTB_Repayment();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {

                    this.StampUpdated(entityInfo);
                    repayment.Transaction(con, tran, entityInfo);

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
        public ResultStatus UpdateData(BaseTB_RepaymentEntity entityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Repayment repayment = new BaseTB_Repayment();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {

                    this.StampUpdated(entityInfo);
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

        #region "Delete Data"
        public ResultStatus DeleteData(int roleID)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Repayment repayment = new BaseTB_Repayment();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    repayment.DataDelete(con, tran, roleID);
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
}