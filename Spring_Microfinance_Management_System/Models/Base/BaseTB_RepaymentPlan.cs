using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Web;
using Spring_Microfinance_Management_System.Common;
using Spring_Microfinance_Management_System.Extension;

namespace Spring_Microfinance_Management_System.Models.Base
{
    public class BaseTB_RepaymentPlan: BaseTB_RepaymentPlanEntity
    {
        #region Get Data List
        public virtual List<BaseTB_RepaymentPlanEntity> GetDataList(int customerID)
        {
            var list = new List<BaseTB_RepaymentPlanEntity>();
            var dt = this.GetDataTable(customerID);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_RepaymentPlanEntity();

                this.SetData(entity, row);
                list.Add(entity);
            }
            return list;
        }
        #endregion

        #region Get Data 
        public virtual BaseTB_RepaymentPlanEntity GetData(int customerID)
        {
           
            var dt = this.GetDataTable(customerID);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                this.SetData(this, row);
            }
            return this;
        }
        #endregion

        #region "Get Data Table"
        public virtual DataTable GetDataTable(int customerID)
        {

            var sql = new StringBuilder();
            sql.AppendLine(" Select * FROM [TB_RepaymentPlan]");
            sql.AppendLine($" WHERE CustomerID={customerID}");
            sql.AppendLine(" AND Status=1");

            return DataBase.ExecuteAdapter(sql.ToString());
        }
        #endregion

        #region "SetData"
        public virtual void SetData(
          BaseTB_RepaymentPlanEntity targetClass,
          DataRow row)
        {
            targetClass.LoanApplicationID = NullableValueExtension.DBNullToIntegerZero(row["LoanApplicationID"]);
            targetClass.RepaymentPlanSeq = NullableValueExtension.DBNullToIntegerZero(row["RepaymentPlanSeq"]);
            if (!DBNull.Value.Equals(row["MonthlyRepaymentDate"]))
                targetClass.MonthlyRepaymentDate = (DateTime)row["MonthlyRepaymentDate"];
            targetClass.Count = NullableValueExtension.DBNullToIntegerZero(row["Count"]);
            targetClass.OriginalLoanAmount = NullableValueExtension.DBNullToDecimalZero(row["OriginalLoanAmount"]);
            targetClass.InterestRate = NullableValueExtension.DBNullToDecimalZero(row["InterestRate"]);
            targetClass.MonthlyInterestAmount = NullableValueExtension.DBNullToDecimalZero(row["MonthlyInterestAmount"]);
            targetClass.MonthlyPrincipalAmount = NullableValueExtension.DBNullToDecimalZero(row["MonthlyPrincipalAmount"]);
            targetClass.MonthlyTotalAmount = NullableValueExtension.DBNullToDecimalZero(row["MonthlyTotalAmount"]);
            targetClass.Status = row["Status"] != DBNull.Value ? (bool)row["Status"] : false;


        }
        #endregion


        #region "Insert Data"
        public virtual int DataInsert(
           DbConnection con,
           DbTransaction tran,
           BaseTB_RepaymentPlanEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var columnList = new List<string>();
            var paramList = new List<string>();

         

            if (!srcClass.IsMonthlyRepaymentDateNull())
            {
                columnList.Add("MonthlyRepaymentDate");
                paramList.Add("@MonthlyRepaymentDate");
            }

            if (!srcClass.IsLoanApplicationIDNull())
            {
                columnList.Add("LoanApplicationID");
                paramList.Add("@LoanApplicationID");
            }

            if (!srcClass.IsCustomerIDNull())
            {
                columnList.Add("CustomerID");
                paramList.Add("@CustomerID");
            }

            if (!srcClass.IsCountNull())
            {
                columnList.Add("Count");
                paramList.Add("@Count");
            }

            if (!srcClass.IsOriginalLoanAmountNull())
            {
                columnList.Add("OriginalLoanAmount");
                paramList.Add("@OriginalLoanAmount");
            }

            if (!srcClass.IsInterestRateNull())
            {
                columnList.Add("InterestRate");
                paramList.Add("@InterestRate");
            } 

            if (!srcClass.IsMonthlyInterestAmountNull())
            {
                columnList.Add("MonthlyInterestAmount");
                paramList.Add("@MonthlyInterestAmount");
            }

            if (!srcClass.IsMonthlyPrincipalAmountNull())
            {
                columnList.Add("MonthlyPrincipalAmount");
                paramList.Add("@MonthlyPrincipalAmount");
            }

            if (!srcClass.IsMonthlyTotalAmountNull())
            {
                columnList.Add("MonthlyTotalAmount");
                paramList.Add("@MonthlyTotalAmount");
            }

            var sql = new StringBuilder();
            sql.AppendLine(" INSERT INTO [TB_RepaymentPlan] ");
            sql.AppendLine(" ( ");
            sql.AppendLine(string.Join("," + Environment.NewLine, columnList));
            sql.AppendLine(" ) ");
            sql.AppendLine(" VALUES ");
            sql.AppendLine(" ( ");
            sql.AppendLine(string.Join("," + Environment.NewLine, paramList));
            sql.AppendLine(" ); ");

            var param = this.GetParameter(srcClass);

            return (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
        }
        #endregion

        #region "Get Parameter"
        private QueryParamList GetParameter(
           BaseTB_RepaymentPlanEntity srcClass,
           bool createMode = true)
        {
            var param = new QueryParamList();

            param.Add("@RepaymentPlanSeq", srcClass.RepaymentPlanSeq);
            param.Add("@MonthlyRepaymentDate", srcClass.MonthlyRepaymentDate);
            param.Add("@LoanApplicationID", srcClass.LoanApplicationID);
            param.Add("@CustomerID", srcClass.CustomerID);
            param.Add("@Count", srcClass.Count);
            param.Add("@OriginalLoanAmount", srcClass.OriginalLoanAmount);
            param.Add("@InterestRate", srcClass.InterestRate);
            param.Add("@MonthlyInterestAmount", srcClass.MonthlyInterestAmount);
            param.Add("@MonthlyPrincipalAmount", srcClass.MonthlyPrincipalAmount);
            param.Add("@MonthlyTotalAmount", srcClass.MonthlyTotalAmount);

            return param;
        }
        #endregion

        #region "Update Data"
        public virtual int DataUpdate(
           DbConnection con,
           DbTransaction tran,
           BaseTB_RepaymentPlanEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var setList = new List<string>();

            if (!srcClass.IsLoanApplicationIDNull())
            {
                setList.Add("LoanApplicationID = @LoanApplicationID");
            }

            if (!srcClass.IsMonthlyRepaymentDateNull())
            {
                setList.Add("MonthlyRepaymentDate = @MonthlyRepaymentDate");
            }

            if (!srcClass.IsCustomerIDNull())
            {
                setList.Add("CustomerID = @CustomerID");
            }

            if (!srcClass.IsCountNull())
            {
                setList.Add("Count = @Count");
            }

            if (!srcClass.IsOriginalLoanAmountNull())
            {
                setList.Add("OriginalLoanAmount = @OriginalLoanAmount");
            }

            if (!srcClass.IsInterestRateNull())
            {
                setList.Add("InterestRate = @InterestRate");
            }

            if (!srcClass.IsMonthlyInterestAmountNull())
            {
                setList.Add("MonthlyInterestAmount = @MonthlyInterestAmount");
            }

            if (!srcClass.IsMonthlyPrincipalAmountNull())
            {
                setList.Add("MonthlyPrincipalAmount = @MonthlyPrincipalAmount");
            }

            if (!srcClass.IsMonthlyTotalAmountNull())
            {
                setList.Add("MonthlyTotalAmount = @MonthlyTotalAmount");
            }

            if (!srcClass.IsStatusNull())
            {
                setList.Add("Status = @Status");
            }


            var sql = new StringBuilder();
            sql.AppendLine(" UPDATE ");
            sql.AppendLine("     [TB_RepaymentPlan] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(string.Join("," + Environment.NewLine, setList));
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     LoanApplicationID = @LoanApplicationID");

            var param = this.GetParameter(srcClass, false);

            int resultCount = (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
            if (resultCount != 1)
            {
                throw new Exception();
            }

            return resultCount;
        }
        #endregion

    }
}