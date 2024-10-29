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
    public class BaseTB_Loan : BaseTB_LoanEntity
    {

        #region Get Data List
        public virtual List<BaseTB_LoanEntity> GetDataList(Loan loan)
        {
            var list = new List<BaseTB_LoanEntity>();
            var dt = this.GetDataTable(loan);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_LoanEntity();

                this.SetData(entity, row);
                list.Add(entity);
            }
            return list;
        }
        #endregion

        #region Get Data 
        public virtual BaseTB_LoanEntity GetData(Loan loan)
        {
            BaseTB_LoanEntity entity = new BaseTB_LoanEntity();
            var dt = this.GetDataTable(loan);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                this.SetData(this, row);
            }

            return this;
        }
        #endregion

        #region Search By Status
        public virtual List<BaseTB_LoanEntity> SearchByStatus(string status)
        {
            int judgementStatus = 0;
            Loan loan = new Loan();
            switch (status.ToLower())
            {
                case "underjudgement":
                    judgementStatus = 0;
                    break;
                case "approve":
                    judgementStatus = 1;
                    break;
                case "reject":
                    judgementStatus = 2;
                    break;
                default:
                    judgementStatus = 3;
                    break;
            }
            loan.Status = judgementStatus;
            var list = new List<BaseTB_LoanEntity>();
            var dt = this.GetDataTable(loan);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_LoanEntity();

                this.SetData(entity, row);
                list.Add(entity);
            }
            return list;
        }
        #endregion

     



        #region "Get Data Table"
        public virtual DataTable GetDataTable(Loan loan)
        {

            var sql = new StringBuilder();
            sql.AppendLine(" Select");
            sql.AppendLine(" l.*");
            sql.AppendLine(" , c.FirstName");            
            sql.AppendLine(" , c.LastName");
            sql.AppendLine(" , c.Email");
            sql.AppendLine(" , c.FatherName");
            sql.AppendLine(" , c.NRCNo");
            sql.AppendLine(" , c.DateOfBirth");
            sql.AppendLine(" , c.Address");
            sql.AppendLine(" , c.PhoneNumber1");
            sql.AppendLine(" , c.PhoneNumber2");
            sql.AppendLine(" , c.ProfilePicture");
            sql.AppendLine(" , c.Gender");
            sql.AppendLine(" , c.BusinessType");
            sql.AppendLine(" , c.MonthlyIncome");
            sql.AppendLine(" , c.CompanyName");
            sql.AppendLine(" , c.CompanyAddress");
            sql.AppendLine(" , c.CompanyPhoneNumber");
            sql.AppendLine(" , c.BankAccNo");
            sql.AppendLine(" , c.CardNumber");
            sql.AppendLine(" , c.CardHolderName");
            sql.AppendLine(" , c.ExpirationDate");
            sql.AppendLine(" , c.CVV");
            sql.AppendLine(" , c.MaritalStatus");
            sql.AppendLine(" , p.ProductType");
            sql.AppendLine(" , g.GuarantorID");
            sql.AppendLine(" , g.Name as GuarantorName");
            sql.AppendLine(" , g.Relation");
            sql.AppendLine(" , g.NRCNo as GuarantorNRCNo");
            sql.AppendLine(" , g.Email as GuarantorEmail");
            sql.AppendLine(" , g.Address as GuarantorAddress");
            sql.AppendLine(" , g.PhNo as GuarantorPhNo");
            sql.AppendLine(" , g.Gender as GuarantorGender");
            sql.AppendLine(" , g.DateOfBirth as GuarantorDateOfBirth");
            sql.AppendLine(" , g.ProfilePicture as GuarantorProfilePicture");
            sql.AppendLine(" , g.CardNumber as GuarantorCardNumber");
            sql.AppendLine(" , g.CardHolderName as GuarantorCardHolderName");
            sql.AppendLine(" , g.ExpirationDate as GuarantorExpirationDate");
            sql.AppendLine(" , g.CVV as GuarantorCVV");
            sql.AppendLine(" From TB_LoanApplication l inner join TB_Customer c On l.CustomerID=c.CustomerID");
            sql.AppendLine(" inner join TB_Guarantor g on g.CustomerID = l.CustomerID");
            sql.AppendLine(" inner join TB_ProductType p on p.ProductTypeID=l.ProductTypeID");
            sql.AppendLine(" Where c.Status = 0");

            if (loan.Status == 0)
            {
                sql.AppendLine(" AND l.JudgementStatus=0");
            }
            

            if (loan.LoanEntity.LoanApplicationID != 0)
            {
                sql.AppendLine($"AND l.LoanApplicationID ={loan.LoanEntity.LoanApplicationID}");
            }

            if (loan.CustomerEntity.CustomerID != 0)
            {
                sql.AppendLine($"AND c.CustomerID ={loan.CustomerEntity.CustomerID}");
            }

            if (loan.Status != 0)
            {
                sql.AppendLine($"AND l.JudgementStatus={loan.Status}");
            }

            return DataBase.ExecuteAdapter(sql.ToString());
        }
        #endregion

        #region "SetData"
        public virtual void SetData(
          BaseTB_LoanEntity targetClass,
          DataRow row)
        {
            //From TB_LoanApplication
            targetClass.LoanApplicationID = NullableValueExtension.DBNullToIntegerZero(row["LoanApplicationID"]);
            targetClass.CustomerID = NullableValueExtension.DBNullToIntegerZero(row["CustomerID"]);
            if (!DBNull.Value.Equals(row["LoanRegistrationDate"]))
                targetClass.LoanRegistrationDate = (DateTime)row["LoanRegistrationDate"];
            if (!DBNull.Value.Equals(row["LoanApprovalDate"]))
                targetClass.LoanApprovalDate = (DateTime)row["LoanApprovalDate"];
            if (!DBNull.Value.Equals(row["LoanRejectDate"]))
                targetClass.LoanRejectDate = (DateTime)row["LoanRejectDate"];
            targetClass.ProductTypeID = NullableValueExtension.DBNullToIntegerZero(row["ProductTypeID"]);
            targetClass.InterestRate = NullableValueExtension.DBNullToDecimalZero(row["InterestRate"]);
            targetClass.LoanAmount = NullableValueExtension.DBNullToDecimalZero(row["LoanAmount"]);
            targetClass.InterestAmount = NullableValueExtension.DBNullToDecimalZero(row["InterestAmount"]);           
            targetClass.MonthsToPay = NullableValueExtension.DBNullToIntegerZero(row["MonthsToPay"]);
            targetClass.Administrationfee = NullableValueExtension.DBNullToDecimalZero(row["Administrationfee"]);
            targetClass.RejectReason = row["RejectReason"].ToString();
            if (!DBNull.Value.Equals(row["CreatedAt"]))
                targetClass.CreatedAt = (DateTime)row["CreatedAt"];
            targetClass.CreatedBy = row["CreatedBy"].ToString();
            if (!DBNull.Value.Equals(row["UpdatedAt"]))
                targetClass.UpdatedAt = (DateTime)row["UpdatedAt"];
            targetClass.UpdatedBy = row["UpdatedBy"].ToString();

            //From TB_Customer                
            targetClass.CustomerEntity.FirstName = row["FirstName"].ToString();
            targetClass.CustomerEntity.LastName = row["LastName"].ToString();
            targetClass.CustomerEntity.Email = row["Email"].ToString();           
            targetClass.CustomerEntity.FatherName = row["FatherName"].ToString();
            targetClass.CustomerEntity.NRCNo = row["NRCNo"].ToString();
            targetClass.CustomerEntity.DateOfBirth = row["DateOfBirth"].ToString();
            targetClass.CustomerEntity.Address = row["Address"].ToString();
            targetClass.CustomerEntity.PhoneNumber1 = row["PhoneNumber1"].ToString();
            targetClass.CustomerEntity.PhoneNumber2 = row["PhoneNumber2"].ToString();
            targetClass.CustomerEntity.ProfilePicture = row["ProfilePicture"].ToString();
            targetClass.CustomerEntity.MonthlyIncome = row["MonthlyIncome"].ToString();
            targetClass.CustomerEntity.CompanyAddress = row["CompanyAddress"].ToString();
            targetClass.CustomerEntity.CompanyPhoneNumber = row["CompanyPhoneNumber"].ToString();
            targetClass.CustomerEntity.BankAccNo = NullableValueExtension.DBNullToIntegerZero(row["BankAccNo"]);
            targetClass.CustomerEntity.CardNumber = row["CardNumber"].ToString();
            targetClass.CustomerEntity.CardHolderName = row["CardHolderName"].ToString();
            targetClass.CustomerEntity.CVV = NullableValueExtension.DBNullToIntegerZero(row["CVV"]);

            //From TB_ProductType
            targetClass.ProductTypeEntity.ProductType = row["ProductType"].ToString();

            //From TB_Guarantor
            targetClass.GuarantorEntity.GuarantorID = NullableValueExtension.DBNullToIntegerZero(row["GuarantorID"]);
            targetClass.GuarantorEntity.Name = row["GuarantorName"].ToString();
            targetClass.GuarantorEntity.Relation = row["Relation"].ToString();
            targetClass.GuarantorEntity.NRCNo = row["GuarantorNRCNo"].ToString();
            targetClass.GuarantorEntity.Email = row["GuarantorEmail"].ToString();
            targetClass.GuarantorEntity.Address = row["GuarantorAddress"].ToString();
            targetClass.GuarantorEntity.PhNo = row["GuarantorPhNo"].ToString();
            targetClass.GuarantorEntity.DateOfBirth = row["GuarantorDateOfBirth"].ToString();
            targetClass.GuarantorEntity.ProfilePicture = row["GuarantorProfilePicture"].ToString();
            targetClass.GuarantorEntity.CardNumber = row["GuarantorCardNumber"].ToString();
            targetClass.GuarantorEntity.CardHolderName = row["GuarantorCardHolderName"].ToString();
            targetClass.GuarantorEntity.ExpirationDate = row["GuarantorExpirationDate"].ToString();
            targetClass.GuarantorEntity.CVV = NullableValueExtension.DBNullToIntegerZero(row["GuarantorCVV"]);

        }
        #endregion

        #region "Insert Data"
        public virtual int DataInsert(
           DbConnection con,
           DbTransaction tran,
           BaseTB_LoanEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var columnList = new List<string>();
            var paramList = new List<string>();


            if (!srcClass.IsCustomerIDNull())
            {
                columnList.Add("CustomerID");
                paramList.Add("@CustomerID");
            }

            if (!srcClass.IsLoanRegistrationDateNull())
            {
                columnList.Add("LoanRegistrationDate");
                paramList.Add("@LoanRegistrationDate");
            }

            if (!srcClass.IsLoanApprovalDateNull())
            {
                columnList.Add("LoanApprovalDate");
                paramList.Add("@LoanApprovalDate");
            }

            if (!srcClass.IsLoanRejectDateNull())
            {
                columnList.Add("LoanRejectDate");
                paramList.Add("@LoanRejectDate");
            }

            if (!srcClass.IsProductTypeIDNull())
            {
                columnList.Add("ProductTypeID");
                paramList.Add("@ProductTypeID");
            }

            if (!srcClass.IsInterestRateNull())
            {
                columnList.Add("InterestRate");
                paramList.Add("@InterestRate");
            }

            if (!srcClass.IsLoanAmountNull())
            {
                columnList.Add("LoanAmount");
                paramList.Add("@LoanAmount");
            }

            if (!srcClass.IsInterestAmountNull())
            {
                columnList.Add("InterestAmount");
                paramList.Add("@InterestAmount");
            }

            if (!srcClass.IsTotalAmountNull())
            {
                columnList.Add("TotalAmount");
                paramList.Add("@TotalAmount");
            }

            if (!srcClass.IsMonthsToPayNull())
            {
                columnList.Add("MonthsToPay");
                paramList.Add("@MonthsToPay");
            }

            if (!srcClass.IsAdministrationfeeNull())
            {
                columnList.Add("Administrationfee");
                paramList.Add("@Administrationfee");
            }

            if (!srcClass.IsStatusNull())
            {
                columnList.Add("JudgementStatus");
                paramList.Add("@JudgementStatus");
            }

            if (!srcClass.IsRejectReasonNull())
            {
                columnList.Add("RejectReason");
                paramList.Add("@RejectReason");
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
            sql.AppendLine(" INSERT INTO [TB_LoanApplication] ");
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
           BaseTB_LoanEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var setList = new List<string>();
            

            if (!srcClass.IsCustomerIDNull())
            {
                setList.Add("CustomerID = @CustomerID");
            }

            if (!srcClass.IsLoanRegistrationDateNull())
            {
                setList.Add("LoanRegistrationDate = @LoanRegistrationDate");
            }

            if (!srcClass.IsLoanApprovalDateNull())
            {
                setList.Add("LoanApprovalDate = @LoanApprovalDate");
            }

            if (!srcClass.IsLoanRejectDateNull())
            {
                setList.Add("LoanRejectDate = @LoanRejectDate");
            }

            if (!srcClass.IsProductTypeIDNull())
            {
                setList.Add("ProductTypeID = @ProductTypeID");
            }

            if (!srcClass.IsInterestRateNull())
            {
                setList.Add("InterestRate = @InterestRate");
            }

            if (!srcClass.IsLoanAmountNull())
            {
                setList.Add("LoanAmount = @LoanAmount");
            }


            if (!srcClass.IsInterestAmountNull())
            {
                setList.Add("InterestAmount = @InterestAmount");
            }

            if (!srcClass.IsTotalAmountNull())
            {
                setList.Add("TotalAmount = @TotalAmount");
            }

            if (!srcClass.IsMonthsToPayNull())
            {
                setList.Add("MonthsToPay = @MonthsToPay");
            }

            if (!srcClass.IsAdministrationfeeNull())
            {
                setList.Add("Administrationfee = @Administrationfee");
            }

            if (!srcClass.IsJudgementStatusNull())
            {
                setList.Add("JudgementStatus = @JudgementStatus");
            }

            if (!srcClass.IsRejectReasonNull())
            {
                setList.Add("RejectReason = @RejectReason");
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
            sql.AppendLine("     [TB_LoanApplication] ");
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

        #region "Delete Data"
        public virtual int DataDelete(
            DbConnection con,
            DbTransaction tran,
            int loanApplicationID
           )
        {
            var sql = new StringBuilder();
            sql.AppendLine(" DELETE [TB_LoanApplication] ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     LoanApplicationID = @LoanApplicationID");


            var param = new QueryParamList();
            param.Add("@LoanApplicationID", loanApplicationID);


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
           BaseTB_LoanEntity srcClass,
           bool createMode = true)
        {
            var param = new QueryParamList();

            param.Add("@LoanApplicationID", srcClass.LoanApplicationID);
            param.Add("@CustomerID", srcClass.CustomerID);
            param.Add("@LoanRegistrationDate", srcClass.LoanRegistrationDate);
            param.Add("@LoanApprovalDate", srcClass.LoanApprovalDate);
            param.Add("@LoanRejectDate", srcClass.LoanRejectDate);
            param.Add("@ProductTypeID", srcClass.ProductTypeID);
            param.Add("@InterestRate", srcClass.InterestRate);
            param.Add("@LoanAmount", srcClass.LoanAmount);
            param.Add("@InterestAmount", srcClass.InterestAmount);
            param.Add("@TotalAmount", srcClass.TotalAmount);
            param.Add("@MonthsToPay", srcClass.MonthsToPay);
            param.Add("@Administrationfee", srcClass.Administrationfee);
            param.Add("@JudgementStatus", srcClass.JudgementStatus);
            param.Add("@RejectReason", srcClass.RejectReason);
            param.Add("@CreatedAt", srcClass.CreatedAt);
            param.Add("@CreatedBy", srcClass.CreatedBy.ToNonNullable());
            param.Add("@UpdatedAt", srcClass.UpdatedAt);
            param.Add("@UpdatedBy", srcClass.UpdatedBy.ToNonNullable());

            return param;
        }
        #endregion

    }

}