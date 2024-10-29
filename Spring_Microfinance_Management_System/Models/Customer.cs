using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using Spring_Microfinance_Management_System.Models.Base;

namespace Spring_Microfinance_Management_System.Models
{

    public class Customer:BaseDA
    {
        public Customer()
        {
            this.CustomerEntity = new BaseTB_CustomerEntity();
        }


        public BaseTB_CustomerEntity CustomerEntity { get; set; }
        public List<BaseTB_CustomerEntity> CustomerList { get; set; }

        public bool IsPasswordCorrect { get; private set; }
        public bool IsUserDetected { get; set; }
        public bool IsLoginScceeded { get; set; }
        public bool IsPasswordForceChange { get; set; }
        public int RoleID { get; set; }

        [Required(ErrorMessage = "Please enter your Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Password.")]
        public string Password { get; set; }



        #region "Get Data By ID"
        public void GetData(int customerNo)
        {
            BaseTB_Customer customer = new BaseTB_Customer();
            this.CustomerEntity = customer.GetDataByID(customerNo);
        }
        #endregion

        #region "Get Data List"
        public void GetDataList(Customer customer)
        {
            BaseTB_Customer customerBase = new BaseTB_Customer();
            this.CustomerList = customerBase.GetDataList(customer);
        }
        #endregion


        #region "Add Data"
        public ResultStatus AddData(Customer customer)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Customer cus = new BaseTB_Customer();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
     
                    this.StampCreated(customer.CustomerEntity);
                    cus.DataInsert(con, tran, customer.CustomerEntity);

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

        public ResultStatus UpdateData(BaseTB_CustomerEntity entityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Customer role = new BaseTB_Customer();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {

                    this.StampUpdated(entityInfo);
                    role.DataUpdate(con, tran, entityInfo);
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



        public ResultStatus GetUser(Customer customer)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Customer cus = new BaseTB_Customer();
            var cusEntity = cus.GetData(customer.Email);

            if (!customer.Email.Equals(cusEntity.Email))
            {
                result.Status = false;
                return result;
            }
            if (!customer.Password.Equals(cusEntity.Password))
            {
                result.Status = false;
                return result;
            }

            if (customer.Email.Equals(cusEntity.Email) && customer.Password.Equals(cusEntity.Password))
            {
                LoginInfo.UserID = cus.CustomerID.ToString();
                LoginInfo.UserName = string.IsNullOrEmpty(cus.FirstName) ? cus.FirstName : cus.FirstName;
                LoginInfo.RoleID = cus.RoleID.ToString();
            }
            return result;
        }






    }

   







}