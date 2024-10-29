using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spring_Microfinance_Management_System.Common;
using Spring_Microfinance_Management_System.Common.Const;
using Spring_Microfinance_Management_System.Models.Base;

namespace Spring_Microfinance_Management_System.Models
{
    public class RoleMaintenance : BaseDA
    {
        public RoleMaintenance()
        {
            this.RoleEntity = new BaseTB_RoleEntity();
            this.RoleList = new List<BaseTB_RoleEntity>();
        }

        public BaseTB_RoleEntity RoleEntity  { get; set; }

        public List<BaseTB_RoleEntity> RoleList { get; set; }

        #region "Get Data List"
        public void GetDataList()
        {
            BaseTB_Role role = new BaseTB_Role();
            this.RoleList = role.GetDataList();
        }
        #endregion

        #region "Get Data"
        public void GetData(int roleID)
        {
            BaseTB_Role role = new BaseTB_Role();
            this.RoleEntity = role.GetData(roleID);
        }
        #endregion

        #region "Add Data"
        public void AddData(BaseTB_RoleEntity entityInfo)
        {
            BaseTB_Role role = new BaseTB_Role();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {

                    this.StampCreated(entityInfo);
                    role.DataInsert(con, tran, entityInfo);
                    
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();                  
                }
                
            }
        }
        #endregion

        #region "Update Data"

        public void UpdateData(BaseTB_RoleEntity entityInfo)
        {
            BaseTB_Role role = new BaseTB_Role();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {

                    this.StampCreated(entityInfo);
                    role.DataUpdate(con, tran, entityInfo);

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }

            }
        }
        #endregion

        #region "Delete Data"
        public void DeleteData(int roleID)
        {
            BaseTB_Role role = new BaseTB_Role();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {

                    role.DataDelete(
                        con, tran, roleID);

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }

            }
        }
        #endregion
    }
}