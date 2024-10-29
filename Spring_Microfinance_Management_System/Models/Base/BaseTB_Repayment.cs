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
    public class BaseTB_Repayment:BaseTB_RepaymentEntity
    {

        #region Get Data
        public virtual BaseTB_RepaymentEntity GetData(int customerID)
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

        #region Get Data table
        public virtual DataTable GetDataTable(int customerID)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT * ");
            sql.AppendLine(" FROM  ");
            sql.AppendLine(" [TB_Repayment] ");
            sql.AppendLine($" WHERE CustomerID ={customerID}");
            sql.AppendLine(" AND  BorrowFlag=1");
            sql.AppendLine(" AND  FullRepaymentFlag=0");

            return DataBase.ExecuteAdapter(sql.ToString());

        }
        #endregion

        #region Get Data List
        public virtual List<BaseTB_RepaymentEntity> GetDataList(int customerID)
        {
            var list = new List<BaseTB_RepaymentEntity>();
            var dt = this.GetDataTableForList(customerID);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_RepaymentEntity();

                this.SetData(entity, row);
                list.Add(entity);
            }
            return list;
        }
        #endregion

        #region Get Data table
        public virtual DataTable GetDataTableForList(int customerID)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT * ");
            sql.AppendLine(" FROM  ");
            sql.AppendLine(" [TB_Repayment] ");

            if (customerID == 0)
            {
                sql.AppendLine(" WHERE BorrowFlag <> 1 ");
            }
            else if (customerID != 0)
            {
                sql.AppendLine($" WHERE CustomerID ={customerID}");               
            }
            
            
            return DataBase.ExecuteAdapter(sql.ToString());

        }
        #endregion

        #region "SetData"
        public virtual void SetData(
          BaseTB_RepaymentEntity targetClass,
          DataRow row)
        {
            targetClass.RepaymentID = NullableValueExtension.DBNullToIntegerZero(row["RepaymentID"]);
            targetClass.LoanApplicationID = NullableValueExtension.DBNullToIntegerZero(row["LoanApplicationID"]);
            if (!DBNull.Value.Equals(row["DeadLine"]))
                targetClass.DeadLine = (DateTime)row["DeadLine"];
            if (!DBNull.Value.Equals(row["RepaymentDate"]))
                targetClass.RepaymentDate = (DateTime)row["RepaymentDate"];
            targetClass.RepaymentAmount = NullableValueExtension.DBNullToDecimalZero(row["RepaymentAmount"]);
            targetClass.CustomerID = NullableValueExtension.DBNullToIntegerZero(row["CustomerID"]);
            targetClass.PaymentMethod = row["PaymentMethod"].ToString();
            targetClass.OriginalLoanAmount = NullableValueExtension.DBNullToDecimalZero(row["OriginalLoanAmount"]);
            targetClass.InterestRate = NullableValueExtension.DBNullToDecimalZero(row["InterestRate"]);
            targetClass.RepaymentTime = NullableValueExtension.DBNullToIntegerZero(row["RepaymentTime"]);
            targetClass.MonthlyInterestAmount = NullableValueExtension.DBNullToDecimalZero(row["MonthlyInterestAmount"]);
            targetClass.MonthlyPrincipalAmount = NullableValueExtension.DBNullToDecimalZero(row["MonthlyPrincipalAmount"]);
            targetClass.MonthlyTotalAmount = NullableValueExtension.DBNullToDecimalZero(row["MonthlyTotalAmount"]);
            targetClass.GrandTotalRepaymentAmount = NullableValueExtension.DBNullToDecimalZero(row["GrandTotalRepaymentAmount"]);
            targetClass.RemainingDebt = NullableValueExtension.DBNullToDecimalZero(row["RemainingDebt"]);
            targetClass.BankAccNo = NullableValueExtension.DBNullToIntegerZero(row["BankAccNo"]);
            targetClass.CardNumber = row["CardNumber"].ToString();
            targetClass.CardHolderName = row["CardHolderName"].ToString();
            targetClass.ExpirationDate = row["ExpirationDate"].ToString();
            targetClass.CVV = NullableValueExtension.DBNullToIntegerZero(row["CVV"]);
            targetClass.FullRepaymentFlag = row["FullRepaymentFlag"] != DBNull.Value ? (bool)row["FullRepaymentFlag"] : false;
            targetClass.BorrowFlag = row["BorrowFlag"] != DBNull.Value ? (bool)row["BorrowFlag"] : false;
            if (!DBNull.Value.Equals(row["CreatedAt"]))
                targetClass.CreatedAt = (DateTime)row["CreatedAt"];
            targetClass.CreatedBy = row["CreatedBy"].ToString();
            if (!DBNull.Value.Equals(row["UpdatedAt"]))
                targetClass.UpdatedAt = (DateTime)row["UpdatedAt"];
            targetClass.UpdatedBy = row["UpdatedBy"].ToString();
        }
        #endregion



        #region "Insert Data"
        public virtual int DataInsert(
           DbConnection con,
           DbTransaction tran,
           BaseTB_RepaymentEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var columnList = new List<string>();
            var paramList = new List<string>();


            if (!srcClass.IsLoanApplicationIDNull())
            {
                columnList.Add("LoanApplicationID");
                paramList.Add("@LoanApplicationID");
            }

            if (!srcClass.IsDeadLineNull())
            {
                columnList.Add("DeadLine");
                paramList.Add("@DeadLine");
            }

            if (!srcClass.IsRepaymentDateNull())
            {
                columnList.Add("RepaymentDate");
                paramList.Add("@RepaymentDate");
            }

            if (!srcClass.IsRepaymentAmountNull())
            {
                columnList.Add("RepaymentAmount");
                paramList.Add("@RepaymentAmount");
            }

            if (!srcClass.IsCustomerIDNull())
            {
                columnList.Add("CustomerID");
                paramList.Add("@CustomerID");
            }

            if (!srcClass.IsPaymentMethodNull())
            {
                columnList.Add("PaymentMethod");
                paramList.Add("@PaymentMethod");
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

            if (!srcClass.IsRepaymentTimeNull())
            {
                columnList.Add("RepaymentTime");
                paramList.Add("@RepaymentTime");
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

            if (!srcClass.IsGrandTotalRepaymentAmountNull())
            {
                columnList.Add("GrandTotalRepaymentAmount");
                paramList.Add("@GrandTotalRepaymentAmount");
            }

            if (!srcClass.IsRemainingDebtNull())
            {
                columnList.Add("RemainingDebt");
                paramList.Add("@RemainingDebt");
            }
            if (!srcClass.IsMobileWalletAccountNull())
            {
                columnList.Add("MobileWalletAccount");
                paramList.Add("@MobileWalletAccount");
            }

            if (!srcClass.IsBankAccNoNull())
            {
                columnList.Add("BankAccNo");
                paramList.Add("@BankAccNo");
            }

            if (!srcClass.IsCardNumberNull())
            {
                columnList.Add("CardNumber");
                paramList.Add("@CardNumber");
            }

            if (!srcClass.IsCardHolderNameNull())
            {
                columnList.Add("CardHolderName");
                paramList.Add("@CardHolderName");
            }

            if (!srcClass.IsExpirationDateNull())
            {
                columnList.Add("ExpirationDate");
                paramList.Add("@ExpirationDate");
            }

            if (!srcClass.IsCVVNull())
            {
                columnList.Add("CVV");
                paramList.Add("@CVV");
            }

            if (!srcClass.IsBorrowFlagNull())
            {
                columnList.Add("BorrowFlag");
                paramList.Add("@BorrowFlag");
            }

            if (!srcClass.IsFullRepaymentFlagNull())
            {
                columnList.Add("FullRepaymentFlag");
                paramList.Add("@FullRepaymentFlag");
            }

            if (!srcClass.IsCreatedAtNull())
            {
                columnList.Add("CreatedAt");
                paramList.Add("@CreatedAt");
            }

            if (!srcClass.IsCreatedByNull())
            {
                columnList.Add("CreatedBy");
                paramList.Add("@CreatedBy");
            }

            if (!srcClass.IsUpdatedAtNull())
            {
                columnList.Add("UpdatedAt");
                paramList.Add("@UpdatedAt");
            }

            if (!srcClass.IsUpdatedByNull())
            {
                columnList.Add("UpdatedBy");
                paramList.Add("@UpdatedBy");
            }

            var sql = new StringBuilder();
            sql.AppendLine(" INSERT INTO [TB_Repayment] ");
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

        #region "Update Data"
        public virtual int DataUpdate(
           DbConnection con,
           DbTransaction tran,
           BaseTB_RepaymentEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var setList = new List<string>();

            if (!srcClass.IsRepaymentIDNull())
            {
                setList.Add("RepaymentID = @RepaymentID");
            }

            if (!srcClass.IsLoanApplicationIDNull())
            {
                setList.Add("LoanApplicationID = @LoanApplicationID");
            }

            if (!srcClass.IsDeadLineNull())
            {
                setList.Add("DeadLine = @DeadLine");
            }

            if (!srcClass.IsRepaymentDateNull())
            {
                setList.Add("RepaymentDate = @RepaymentDate");
            }

            if (!srcClass.IsRepaymentAmountNull())
            {
                setList.Add("RepaymentAmount  = @RepaymentAmount ");
            }

            if (!srcClass.IsCustomerIDNull())
            {
                setList.Add("CustomerID = @CustomerID");
            }

            if (!srcClass.IsPaymentMethodNull())
            {
                setList.Add("PaymentMethod = @PaymentMethod");
            }

            if (!srcClass.IsOriginalLoanAmountNull())
            {
                setList.Add("OriginalLoanAmount = @OriginalLoanAmount");
            }

            if (!srcClass.IsInterestRateNull())
            {
                setList.Add("InterestRate = @InterestRate");
            }

            if (!srcClass.IsRepaymentTimeNull())
            {
                setList.Add("RepaymentTime = @RepaymentTime");
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

            if (!srcClass.IsGrandTotalRepaymentAmountNull())
            {
                setList.Add("GrandTotalRepaymentAmount = @GrandTotalRepaymentAmount");
            }

            if (!srcClass.IsRemainingDebtNull())
            {
                setList.Add("RemainingDebt = @RemainingDebt");
            }

            if (!srcClass.IsBankAccNoNull())
            {
                setList.Add("BankAccNo = @BankAccNo");
            }

            if (!srcClass.IsCardNumberNull())
            {
                setList.Add("CardNumber = @CardNumber");
            }

            if (!srcClass.IsCardHolderNameNull())
            {
                setList.Add("CardHolderName = @CardHolderName");
            }

            if (!srcClass.IsExpirationDateNull())
            {
                setList.Add("ExpirationDate = @ExpirationDate");
            }

            if (!srcClass.IsCVVNull())
            {
                setList.Add("CVV = @CVV");
            }

            if (!srcClass.IsMobileWalletAccountNull())
            {
                setList.Add("MobileWalletAccount = @MobileWalletAccount");
            }

            if (!srcClass.IsFullRepaymentFlagNull())
            {
                setList.Add("FullRepaymentFlag = @FullRepaymentFlag");
            }

            if (!srcClass.IsCreatedAtNull())
            {
                setList.Add("CreatedAt = @CreatedAt");
            }

            if (!srcClass.IsCreatedByNull())
            {
                setList.Add("CreatedBy = @CreatedBy");
            }

            if (!srcClass.IsUpdatedAtNull())
            {
                setList.Add("UpdatedAt = @UpdatedAt");
            }

            if (!srcClass.IsUpdatedByNull())
            {
                setList.Add("UpdatedBy = @UpdatedBy");
            }

            var sql = new StringBuilder();
            sql.AppendLine(" UPDATE ");
            sql.AppendLine("     [TB_Repayment] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(string.Join("," + Environment.NewLine, setList));
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     RepaymentID = @RepaymentID");

            var param = this.GetParameter(srcClass, false);

            int resultCount = (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
            if (resultCount != 1)
            {
                throw new Exception();
            }

            return resultCount;
        }
        #endregion

        #region "Update Data"
        public virtual int Transaction(
           DbConnection con,
           DbTransaction tran,
           BaseTB_RepaymentEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var setList = new List<string>();

            if (!srcClass.IsDeadLineNull())
            {
                setList.Add("DeadLine = @DeadLine");
            }
  
            setList.Add("RemainingDebt = @RemainingDebt");

            if (!srcClass.IsFullRepaymentFlagNull())
            {
                setList.Add("FullRepaymentFlag = @FullRepaymentFlag");
            }

            if (!srcClass.IsCreatedAtNull())
            {
                setList.Add("CreatedAt = @CreatedAt");
            }

            if (!srcClass.IsCreatedByNull())
            {
                setList.Add("CreatedBy = @CreatedBy");
            }

            if (!srcClass.IsUpdatedAtNull())
            {
                setList.Add("UpdatedAt = @UpdatedAt");
            }

            if (!srcClass.IsUpdatedByNull())
            {
                setList.Add("UpdatedBy = @UpdatedBy");
            }

            var sql = new StringBuilder();
            sql.AppendLine(" UPDATE ");
            sql.AppendLine("     [TB_Repayment] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(string.Join("," + Environment.NewLine, setList));
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     LoanApplicationID = @LoanApplicationID");
            sql.AppendLine("AND BorrowFlag=1    ");

            var param = this.GetParameter(srcClass, false);

            int resultCount = (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
            if (resultCount != 1)
            {
                throw new Exception();
            }

            return resultCount;
        }
        #endregion

        #region "Delete Data"
        public virtual int DataDelete(
            DbConnection con,
            DbTransaction tran,
            int repaymentID
           )
        {
            var sql = new StringBuilder();
            sql.AppendLine(" DELETE [TB_Role] ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     RepaymentID = @RepaymentID");


            var param = new QueryParamList();
            param.Add("@RepaymentID", repaymentID);


            int resultCount = (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
            if (resultCount != 1)
            {
                throw new Exception();
            }

            return resultCount;
        }
        #endregion

        #region "Get Parameter"
        private QueryParamList GetParameter(
           BaseTB_RepaymentEntity srcClass,
           bool createMode = true)
        {
            var param = new QueryParamList();

            param.Add("@RepaymentID", srcClass.RepaymentID);
            param.Add("@LoanApplicationID", srcClass.LoanApplicationID);
            param.Add("@DeadLine", srcClass.DeadLine);
            param.Add("@RepaymentDate", srcClass.RepaymentDate);
            param.Add("@RepaymentAmount ", srcClass.RepaymentAmount);
            param.Add("@CustomerID", srcClass.CustomerID);
            param.Add("@PaymentMethod", srcClass.PaymentMethod);
            param.Add("@OriginalLoanAmount", srcClass.OriginalLoanAmount);
            param.Add("@InterestRate", srcClass.InterestRate);
            param.Add("@RepaymentTime", srcClass.RepaymentTime);
            param.Add("@MonthlyInterestAmount", srcClass.MonthlyInterestAmount);
            param.Add("@MonthlyPrincipalAmount", srcClass.MonthlyPrincipalAmount);
            param.Add("@MonthlyTotalAmount", srcClass.MonthlyTotalAmount);
            param.Add("@GrandTotalRepaymentAmount", srcClass.GrandTotalRepaymentAmount);
            param.Add("@RemainingDebt", srcClass.RemainingDebt);
            param.Add("@MobileWalletAccount", srcClass.MobileWalletAccount);
            param.Add("@BankAccNo", srcClass.BankAccNo);
            param.Add("@CardNumber", srcClass.CardNumber);
            param.Add("@CardHolderName", srcClass.CardHolderName);
            param.Add("@ExpirationDate", srcClass.ExpirationDate);
            param.Add("@CVV", srcClass.CVV);
            param.Add("@BorrowFlag", srcClass.BorrowFlag);
            param.Add("@FullRepaymentFlag", srcClass.FullRepaymentFlag);
            param.Add("@CreatedAt", srcClass.CreatedAt);
            param.Add("@CreatedBy", srcClass.CreatedBy.ToNonNullable());
            param.Add("@UpdatedAt", srcClass.UpdatedAt);
            param.Add("@UpdatedBy", srcClass.UpdatedBy.ToNonNullable());

            return param;
        }
        #endregion
    }
}