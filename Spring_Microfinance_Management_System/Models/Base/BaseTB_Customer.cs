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
    public class BaseTB_Customer:BaseTB_CustomerEntity
    {
        #region "Get Data By ID"
        public virtual BaseTB_CustomerEntity GetDataByID(int customerID)          
        {
          
            var dt = this.GetDataTableByID(customerID);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                this.SetData(this, row);
            }

            return this;
        }

        public virtual DataTable GetDataTableByID(int customerID)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT *");
            sql.AppendLine(" FROM ");
            sql.AppendLine(" [TB_Customer]");
            sql.AppendLine($" WHERE CustomerID={customerID}");

            return DataBase.ExecuteAdapter(sql.ToString());
        }
        #endregion

        #region "Get Data"
        public virtual BaseTB_CustomerEntity GetData(
           string email)
        {
            var dic = new Dictionary<string, object>();
            var whereStr = new StringBuilder();

            dic["@Email"] = email;

            whereStr.AppendLine("     Email = @Email");

            var dt = this.GetDataTable(whereStr.ToString(), dic);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                this.SetData(this, row);
            }

            return this;
        }
        #endregion

        #region "Get Data Table"
        public virtual DataTable GetDataTable(
        string selectWhere,
        Dictionary<string, object> whereParam,
        string strOrderBy = null)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT *");
            sql.AppendLine(" FROM ");
            sql.AppendLine("     [TB_Customer]");

            if (!string.IsNullOrEmpty(selectWhere))
            {
                sql.AppendLine(" WHERE ");
                sql.AppendLine(selectWhere);
            }

            if (!string.IsNullOrEmpty(strOrderBy))
            {
                sql.AppendLine(" ORDER BY ");
                sql.AppendLine(strOrderBy);
            }

            var param = new QueryParamList();
            foreach (var key in whereParam.Keys)
            {
                string k = key;
                object value = whereParam[key];

                param.Add(key, value);
            }

            return DataBase.ExecuteAdapter(sql.ToString(), param);
        }
        #endregion

        #region "Get Data List"
        public virtual List<BaseTB_CustomerEntity> GetDataList(Customer customer)
        {
            var list = new List<BaseTB_CustomerEntity>();
            var dt = this.GetDataTableForList(customer);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_CustomerEntity();

                this.SetData(entity, row);
                list.Add(entity);
            }
            return list;
        }
        #endregion

        #region "Get Data Table For List"
        public virtual DataTable GetDataTableForList(Customer customer)
        {

            var sql = new StringBuilder();
            sql.AppendLine(" SELECT");
            sql.AppendLine(" * FROM [TB_Customer]");

            if (!string.IsNullOrEmpty(customer.CustomerEntity.FirstName))
            {
                sql.AppendLine($" WHERE FirstName like '%{customer.CustomerEntity.FirstName}%'");
            }
            
            return DataBase.ExecuteAdapter(sql.ToString());
        }
        #endregion

        #region "Set Data"
        public virtual void SetData(
            BaseTB_CustomerEntity targetClass,
            DataRow row)
        {
            targetClass.CustomerID = NullableValueExtension.DBNullToIntegerZero(row["CustomerID"]);
            targetClass.RoleID = NullableValueExtension.DBNullToIntegerZero(row["RoleID"]);
            targetClass.FirstName = row["FirstName"].ToString();
            targetClass.LastName = row["LastName"].ToString();
            targetClass.Email = row["Email"].ToString();
            targetClass.Password = row["Password"].ToString();
            targetClass.FatherName = row["FatherName"].ToString();
            targetClass.NRCNo = row["NRCNo"].ToString();
            targetClass.Password = row["Password"].ToString();
            targetClass.Address = row["Address"].ToString();                 
            targetClass.PhoneNumber1 = row["PhoneNumber1"].ToString();
            targetClass.PhoneNumber2 = row["PhoneNumber2"].ToString();
            targetClass.ProfilePicture = row["ProfilePicture"].ToString();
            targetClass.MonthlyIncome = row["MonthlyIncome"].ToString();
            targetClass.CompanyName = row["CompanyName"].ToString();
            targetClass.CompanyAddress = row["CompanyAddress"].ToString();
            targetClass.CompanyPhoneNumber = row["CompanyPhoneNumber"].ToString();
            targetClass.BankAccNo = NullableValueExtension.DBNullToIntegerZero(row["BankAccNo"]);
            targetClass.CardNumber = row["CardNumber"].ToString();
            targetClass.CardHolderName = row["CardHolderName"].ToString();
            targetClass.CVV = NullableValueExtension.DBNullToIntegerZero(row["CVV"]);         

            if (!DBNull.Value.Equals(row["CreatedAt"]))
                targetClass.CreatedAt = (DateTime)row["CreatedAt"];
            targetClass.CreatedBy = row["CreatedBy"].ToString();
            if (!DBNull.Value.Equals(row["UpdatedAt"]))
                targetClass.UpdatedAt = (DateTime)row["UpdatedAt"];
            targetClass.UpdatedBy = row["UpdatedBy"].ToString();
        }
        #endregion


        #region "Data Insert"
        public virtual int DataInsert(
           DbConnection con,
           DbTransaction tran,
           BaseTB_CustomerEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var columnList = new List<string>();
            var paramList = new List<string>();

            if (!srcClass.IsFirstNameNull())
            {
                columnList.Add("FirstName");
                paramList.Add("@FirstName");
            }

            if (!srcClass.IsLastNameNull())
            {
                columnList.Add("LastName");
                paramList.Add("@LastName");
            }

            if (!srcClass.IsEmailNull())
            {
                columnList.Add("Email");
                paramList.Add("@Email");
            }

            if (!srcClass.IsPasswordNull())
            {
                columnList.Add("Password");
                paramList.Add("@Password");
            }

            if (!srcClass.IsFatherNameNull())
            {
                columnList.Add("FatherName ");
                paramList.Add("@FatherName ");
            }

            if (!srcClass.IsNRCNoNull())
            {
                columnList.Add("NRCNo");
                paramList.Add("@NRCNo");
            }

            if (!srcClass.IsDateOfBirthNull())
            {
                columnList.Add("DateOfBirth");
                paramList.Add("@DateOfBirth");
            }

            if (!srcClass.IsAddressNull())
            {
                columnList.Add("Address");
                paramList.Add("@Address");
            }

            if (!srcClass.IsPhoneNumber1Null())
            {
                columnList.Add("PhoneNumber1");
                paramList.Add("@PhoneNumber1");
            }

            if (!srcClass.IsPhoneNumber2Null())
            {
                columnList.Add("PhoneNumber2");
                paramList.Add("@PhoneNumber2");
            }

            if (!srcClass.IsProfilePictureNull())
            {
                columnList.Add("ProfilePicture");
                paramList.Add("@ProfilePicture");
            }

            if (!srcClass.IsGenderNull())
            {
                columnList.Add("Gender");
                paramList.Add("@Gender");
            }

            if (!srcClass.IsBusinessTypeNull())
            {
                columnList.Add("BusinessType");
                paramList.Add("@BusinessType");
            }

            if (!srcClass.IsMonthlyIncomeNull())
            {
                columnList.Add("MonthlyIncome");
                paramList.Add("@MonthlyIncome");
            }

            if (!srcClass.IsCompanyNameNull())
            {
                columnList.Add("CompanyName");
                paramList.Add("@CompanyName");
            }

            if (!srcClass.IsCompanyAddressNull())
            {
                columnList.Add("CompanyAddress");
                paramList.Add("@CompanyAddress");
            }

            if (!srcClass.IsCompanyPhoneNumberNull())
            {
                columnList.Add("CompanyPhoneNumber");
                paramList.Add("@CompanyPhoneNumber");
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

            if (!srcClass.IsStatusNull())
            {
                columnList.Add("Status");
                paramList.Add("@Status");
            }

            if (!srcClass.IsMaritalStatusNull())
            {
                columnList.Add("MaritalStatus");
                paramList.Add("@MaritalStatus");
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
            sql.AppendLine(" INSERT INTO [TB_Customer] ");
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


        #region "Data Update"
        public virtual int DataUpdate(
           DbConnection con,
           DbTransaction tran,
           BaseTB_CustomerEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var setList = new List<string>();

           

            if (!srcClass.IsFirstNameNull())
            {
                setList.Add("FirstName = @FirstName");
              
            }

            if (!srcClass.IsLastNameNull())
            {
                setList.Add("LastName = @LastName");
               
            }

            if (!srcClass.IsEmailNull())
            {
                setList.Add("Email = @Email");
            }


            if (!srcClass.IsPasswordNull())
            {
                setList.Add("Password = @Password");

            }

            if (!srcClass.IsFatherNameNull())
            {
                setList.Add("FatherName = @FatherName ");
            }

            if (!srcClass.IsNRCNoNull())
            {
                setList.Add("NRCNo = @NRCNo");
            }

            if (!srcClass.IsDateOfBirthNull())
            {
                setList.Add("DateOfBirth = @DateOfBirth");
            }

            if (!srcClass.IsAddressNull())
            {
                setList.Add("Address = @Address");
            }

            if (!srcClass.IsPhoneNumber1Null())
            {
                setList.Add("PhoneNumber1 = @PhoneNumber1");
            }

            if (!srcClass.IsPhoneNumber2Null())
            {
                setList.Add("PhoneNumber2 = @PhoneNumber2");
            }

            if (!srcClass.IsProfilePictureNull())
            {
                setList.Add("ProfilePicture = @ProfilePicture");
            }

            if (!srcClass.IsGenderNull())
            {
                setList.Add("Gender = @Gender");
            }

            if (!srcClass.IsBusinessTypeNull())
            {
                setList.Add("BusinessType = @BusinessType");
            }

            if (!srcClass.IsMonthlyIncomeNull())
            {
                setList.Add("MonthlyIncome = @MonthlyIncome");
            }

            if (!srcClass.IsCompanyNameNull())
            {
                setList.Add("CompanyName = @CompanyName");
            }

            if (!srcClass.IsCompanyAddressNull())
            {
                setList.Add("CompanyAddress = @CompanyAddress");
            }

            if (!srcClass.IsCompanyPhoneNumberNull())
            {
                setList.Add("CompanyPhoneNumber = @CompanyPhoneNumber");
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

            if (!srcClass.IsStatusNull())
            {
                setList.Add("Status = @Status");
            }

            if (!srcClass.IsMaritalStatusNull())
            {
                setList.Add("MaritalStatus = @MaritalStatus");
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
            sql.AppendLine("     [TB_Customer] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(string.Join("," + Environment.NewLine, setList));
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     CustomerID = @CustomerID");

            var param = this.GetParameter(srcClass, false);

            int resultCount = (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
            if (resultCount != 1)
            {
                throw new Exception();
            }

            return resultCount;
        }
        #endregion

        #region "Data Delete"
        public virtual int DataDelete(
           DbConnection con,
           DbTransaction tran,
           int customerID)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" DELETE [TB_Customer] ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     CustomerID = @CustomerID");

            var param = new QueryParamList();
            param.Add("@CustomerID", customerID);

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
           BaseTB_CustomerEntity srcClass,
           bool createMode = true)
        {
            var param = new QueryParamList();

            param.Add("@CustomerID", srcClass.CustomerID);
            param.Add("@FirstName", srcClass.FirstName);
            param.Add("@LastName", srcClass.LastName);        
            param.Add("@Email", srcClass.Email);
            param.Add("@Password", srcClass.Password);
            param.Add("@FatherName", srcClass.FatherName);
            param.Add("@NRCNo", srcClass.NRCNo);
            param.Add("@DateOfBirth", srcClass.DateOfBirth);
            param.Add("@Address", srcClass.Address);
            param.Add("@PhoneNumber1", srcClass.PhoneNumber1);
            param.Add("@PhoneNumber2", srcClass.PhoneNumber2);
            param.Add("@ProfilePicture", srcClass.ProfilePicture);
            param.Add("@Gender", srcClass.Gender);
            param.Add("@BusinessType", srcClass.BusinessType);
            param.Add("@MonthlyIncome", srcClass.MonthlyIncome);
            param.Add("@CompanyName", srcClass.CompanyName);
            param.Add("@CompanyAddress", srcClass.CompanyAddress);
            param.Add("@CompanyPhoneNumber", srcClass.CompanyPhoneNumber);
            param.Add("@BankAccNo", srcClass.BankAccNo);
            param.Add("@CardNumber", srcClass.CardNumber);
            param.Add("@CardHolderName", srcClass.CardHolderName);
            param.Add("@ExpirationDate", srcClass.ExpirationDate);
            param.Add("@CVV", srcClass.CVV);
            param.Add("@Status", srcClass.CompanyPhoneNumber);
            param.Add("@MaritalStatus", srcClass.BankAccNo);
            param.Add("@CreatedAt", srcClass.CreatedAt);
            param.Add("@CreatedBy", srcClass.CreatedBy.ToNonNullable());
            param.Add("@UpdatedAt", srcClass.UpdatedAt);
            param.Add("@UpdatedBy", srcClass.UpdatedBy.ToNonNullable());

            return param;
        }
        #endregion
    }
}