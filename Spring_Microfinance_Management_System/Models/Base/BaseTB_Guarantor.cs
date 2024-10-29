using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Web;
using Spring_Microfinance_Management_System.Common;

namespace Spring_Microfinance_Management_System.Models.Base
{
    public class BaseTB_Guarantor:BaseTB_GuarantorEntity
    {
        //#region "Get Data"
        //public virtual BaseTB_GuarantorEntity GetData(
        //   string email)
        //{
        //    var dic = new Dictionary<string, object>();
        //    var whereStr = new StringBuilder();

        //    dic["@Email"] = email;

        //    whereStr.AppendLine("     Email = @Email");

        //    var dt = this.GetDataTable(whereStr.ToString(), dic);
        //    if (dt.Rows.Count > 0)
        //    {
        //        var row = dt.Rows[0];
        //        this.SetData(this, row);
        //    }

        //    return this;
        //}
        //#endregion

        //#region "Get Data Table"
        //public virtual DataTable GetDataTable(
        //string selectWhere,
        //Dictionary<string, object> whereParam,
        //string strOrderBy = null)
        //{
        //    var sql = new StringBuilder();
        //    sql.AppendLine(" SELECT *");
        //    sql.AppendLine(" FROM ");
        //    sql.AppendLine("     [TB_Guarantor]");

        //    if (!string.IsNullOrEmpty(selectWhere))
        //    {
        //        sql.AppendLine(" WHERE ");
        //        sql.AppendLine(selectWhere);
        //    }

        //    if (!string.IsNullOrEmpty(strOrderBy))
        //    {
        //        sql.AppendLine(" ORDER BY ");
        //        sql.AppendLine(strOrderBy);
        //    }

        //    var param = new QueryParamList();
        //    foreach (var key in whereParam.Keys)
        //    {
        //        string k = key;
        //        object value = whereParam[key];

        //        param.Add(key, value);
        //    }

        //    return DataBase.ExecuteAdapter(sql.ToString(), param);
        //}
        //#endregion

        //#region "Get Data List"
        //public virtual List<BaseTB_GuarantorEntity> GetDataList()
        //{
        //    var list = new List<BaseTB_GuarantorEntity>();
        //    var dt = this.GetDataTableForList();
        //    for (var i = 0; i < dt.Rows.Count; i++)
        //    {
        //        var row = dt.Rows[i];
        //        var entity = new BaseTB_GuarantorEntity();

        //        this.SetData(entity, row);
        //        list.Add(entity);
        //    }
        //    return list;
        //}
        //#endregion

        //#region "Get Data Table For List"
        //public virtual DataTable GetDataTableForList()
        //{

        //    var sql = new StringBuilder();
        //    sql.AppendLine(" SELECT");
        //    sql.AppendLine(" * FROM [TB_Guarantor]");

        //    return DataBase.ExecuteAdapter(sql.ToString());
        //}
        //#endregion

        //#region "Set Data"
        //public virtual void SetData(
        //    BaseTB_GuarantorEntity targetClass,
        //    DataRow row)
        //{
        //    targetClass.GuarantorID = NullableValueExtension.DBNullToIntegerZero(row["GuarantorID"]);
        //    targetClass.RoleID = NullableValueExtension.DBNullToIntegerZero(row["RoleID"]);
        //    targetClass.FirstName = row["FirstName"].ToString();
        //    targetClass.LastName = row["LastName"].ToString();
        //    targetClass.Email = row["Email"].ToString();
        //    targetClass.Password = row["Password"].ToString();
        //    targetClass.FatherName = row["FatherName"].ToString();
        //    targetClass.NRCNo = row["NRCNo"].ToString();
        //    targetClass.Password = row["Password"].ToString();
        //    targetClass.Address = row["Address"].ToString();
        //    targetClass.PhoneNumber1 = row["PhoneNumber1"].ToString();
        //    targetClass.PhoneNumber2 = row["PhoneNumber2"].ToString();
        //    targetClass.ProfilePicture = row["ProfilePicture"].ToString();

        //    //Gender
        //    if (row["Gender"].Equals(0))
        //    { targetClass.Gender = CusGender.Male; }
        //    else if (row["Gender"].Equals(1))
        //    { targetClass.Gender = CusGender.Female; }
        //    else if (row["Gender"].Equals(2))
        //    { targetClass.Gender = CusGender.LGBT; }
        //    else if (row["Gender"].Equals(3))
        //    { targetClass.Gender = CusGender.Other; }


        //    //BusinessType
        //    if (row["BusinessType"].Equals(0))
        //    { targetClass.BusinessType = BusinessType.Retail; }
        //    else if (row["BusinessType"].Equals(1))
        //    { targetClass.BusinessType = BusinessType.Wholesale; }
        //    else if (row["BusinessType"].Equals(2))
        //    { targetClass.BusinessType = BusinessType.Service; }
        //    else if (row["BusinessType"].Equals(3))
        //    { targetClass.BusinessType = BusinessType.Manufacturing; }
        //    else if (row["BusinessType"].Equals(3))
        //    { targetClass.BusinessType = BusinessType.Other; }

        //    targetClass.MonthlyIncome = row["MonthlyIncome"].ToString();
        //    targetClass.CompanyName = row["CompanyName"].ToString();
        //    targetClass.CompanyAddress = row["CompanyAddress"].ToString();
        //    targetClass.CompanyPhoneNumber = row["CompanyPhoneNumber"].ToString();
        //    targetClass.BankAccNo = NullableValueExtension.DBNullToIntegerZero(row["BankAccNo"]);
        //    targetClass.CardNumber = row["CardNumber"].ToString();
        //    targetClass.CardHolderName = row["CardHolderName"].ToString();
        //    targetClass.CVV = NullableValueExtension.DBNullToIntegerZero(row["CVV"]);

        //    //Status
        //    if (row["Status"].Equals(0))
        //    { targetClass.Status = Status.Active; }
        //    else if (row["Status"].Equals(1))
        //    { targetClass.Status = Status.Deactive; }

        //    //MaritalStatus
        //    if (row["MaritalStatus"].Equals(0))
        //    { targetClass.MaritalStatus = MaritalStatus.Single; }
        //    else if (row["MaritalStatus"].Equals(1))
        //    { targetClass.MaritalStatus = MaritalStatus.Married; }
        //    else if (row["MaritalStatus"].Equals(2))
        //    { targetClass.MaritalStatus = MaritalStatus.Other; }


        //    if (!DBNull.Value.Equals(row["CreatedAt"]))
        //        targetClass.CreatedAt = (DateTime)row["CreatedAt"];
        //    targetClass.CreatedBy = row["CreatedBy"].ToString();
        //    if (!DBNull.Value.Equals(row["UpdatedAt"]))
        //        targetClass.UpdatedAt = (DateTime)row["UpdatedAt"];
        //    targetClass.UpdatedBy = row["UpdatedBy"].ToString();
        //}
        //#endregion


        #region "Data Insert"
        public virtual int DataInsert(
           DbConnection con,
           DbTransaction tran,
           BaseTB_GuarantorEntity srcClass = null)
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

            if (!srcClass.IsNameNull())
            {
                columnList.Add("Name");
                paramList.Add("@Name");
            }

            if (!srcClass.IsRelationNull())
            {
                columnList.Add("Relation");
                paramList.Add("@Relation");
            }

            if (!srcClass.IsEmailNull())
            {
                columnList.Add("Email");
                paramList.Add("@Email");
            }

            if (!srcClass.IsAddressNull())
            {
                columnList.Add("Address");
                paramList.Add("@Address");
            }

            if (!srcClass.IsPhNoNull())
            {
                columnList.Add("PhNo");
                paramList.Add("@PhNo");
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
            sql.AppendLine(" INSERT INTO [TB_Guarantor] ");
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
           BaseTB_GuarantorEntity srcClass = null)
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

            if (!srcClass.IsNameNull())
            {
                setList.Add("Name = @Name");

            }

            if (!srcClass.IsRelationNull())
            {
                setList.Add("Relation = @Relation");
            }


            if (!srcClass.IsNRCNoNull())
            {
                setList.Add("NRCNo = @NRCNo");

            }

            if (!srcClass.IsEmailNull())
            {
                setList.Add("Email = @Email ");
            }

            if (!srcClass.IsAddressNull())
            {
                setList.Add("Address = @Address");
            }

            if (!srcClass.IsPhNoNull())
            {
                setList.Add("PhNo = @PhNo");
            }

            if (!srcClass.IsGenderNull())
            {
                setList.Add("Gender = @Gender");
            }

            if (!srcClass.IsDateOfBirthNull())
            {
                setList.Add("DateOfBirth = @DateOfBirth");
            }

            if (!srcClass.IsProfilePictureNull())
            {
                setList.Add("ProfilePicture = @ProfilePicture");
            }

            if (!srcClass.IsProfilePictureNull())
            {
                setList.Add("ProfilePicture = @ProfilePicture");
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
            sql.AppendLine("     [TB_Guarantor] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(string.Join("," + Environment.NewLine, setList));
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     GuarantorID = @GuarantorID");

            var param = this.GetParameter(srcClass, false);

            int resultCount = (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
            if (resultCount != 1)
            {
                throw new Exception();
            }

            return resultCount;
        }
        #endregion

        //#region "Data Delete"
        //public virtual int DataDelete(
        //   DbConnection con,
        //   DbTransaction tran,
        //   int customerID)
        //{
        //    var sql = new StringBuilder();
        //    sql.AppendLine(" DELETE [TB_Guarantor] ");
        //    sql.AppendLine(" WHERE ");
        //    sql.AppendLine("     GuarantorID = @GuarantorID");

        //    var param = new QueryParamList();
        //    param.Add("@GuarantorID", customerID);

        //    int resultCount = (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
        //    if (resultCount != 1)
        //    {
        //        throw new Exception();
        //    }

        //    return resultCount;
        //}
        //#endregion

        #region "Get Parameter"
        private QueryParamList GetParameter(
           BaseTB_GuarantorEntity srcClass,
           bool createMode = true)
        {
            var param = new QueryParamList();

            param.Add("@CustomerID", srcClass.CustomerID);
            param.Add("@GuarantorID", srcClass.GuarantorID);
            param.Add("@Name", srcClass.Name);      
            param.Add("@Email", srcClass.Email);      
            param.Add("@NRCNo", srcClass.NRCNo);
            param.Add("@Relation", srcClass.Relation);
            param.Add("@DateOfBirth", srcClass.DateOfBirth);
            param.Add("@Address", srcClass.Address);
            param.Add("@PhNo", srcClass.PhNo);         
            param.Add("@ProfilePicture", srcClass.ProfilePicture);
            param.Add("@Gender", srcClass.Gender);            
            param.Add("@CardNumber", srcClass.CardNumber);
            param.Add("@CardHolderName", srcClass.CardHolderName);
            param.Add("@ExpirationDate", srcClass.ExpirationDate);
            param.Add("@CVV", srcClass.CVV);
            param.Add("@CreatedAt", srcClass.CreatedAt);
            param.Add("@CreatedBy", srcClass.CreatedBy.ToNonNullable());
            param.Add("@UpdatedAt", srcClass.UpdatedAt);
            param.Add("@UpdatedBy", srcClass.UpdatedBy.ToNonNullable());

            return param;
        }
        #endregion
    }
}