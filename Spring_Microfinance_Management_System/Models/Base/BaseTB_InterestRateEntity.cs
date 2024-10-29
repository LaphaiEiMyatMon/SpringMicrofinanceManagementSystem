using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Spring_Microfinance_Management_System.Extension;

namespace Spring_Microfinance_Management_System.Models.Base
{
    public class BaseTB_InterestRateEntity
    {
        #region "private"
        
        private int? _interestRateID;

        private decimal? _interestRate;

        private DateTime? _createdAt;

        private string _createdBy;

        private DateTime? _updatedAt;

        private string _updatedBy;

        #endregion

        #region "Public"

        public int InterestRateID { get { return this._interestRateID.ToNonNullable(); } set { this._interestRateID = value; } }

        public decimal InterestRate { get { return this._interestRate.ToNonNullable(); } set { this._interestRate = value; } }

        public DateTime CreatedAt { get { return this._createdAt.ToNonNullable(); } set { this._createdAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CreatedBy { get { return this._createdBy; } set { this._createdBy = value; } }
     
        public DateTime UpdatedAt { get { return this._updatedAt.ToNonNullable(); } set { this._updatedAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }

        #endregion

        #region "IsNull"

        public bool IsInterestRateIDNull() { return this._interestRateID == null; }

        public bool IsInterestRateNull() { return this._interestRate == null; }

        public bool IsCreatedAtNull() { return this._createdAt == null; }
      
        public bool IsCreatedByNull() { return this._createdBy == null; }
        
        public bool IsUpdatedAtNull() { return this._updatedAt == null; }
        
        public bool IsUpdatedByNull() { return this._updatedBy == null; }

        #endregion

        #region "SetNull"
 
        public void SetInterestRateIDNull() { this._interestRateID = null; }

        public void SetInterestRateNull() { this._interestRate = null; }

        public void SetCreatedAtNull() { this._createdAt = null; }

        public void SetCreatedByNull() { this._createdBy = null; }

        public void SetUpdatedAtNull() { this._updatedAt = null; }

        public void SetUpdatedByNull() { this._updatedBy = null; }

        #endregion
    }
}