using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Spring_Microfinance_Management_System.Extension;

namespace Spring_Microfinance_Management_System.Models.Base
{
    public class BaseTB_DelayInterestRateEntity
    {
        #region "private"

        private int? _delayInterestRateID;

        private decimal? _delayInterestRate;

        private DateTime? _createdAt;

        private string _createdBy;

        private DateTime? _updatedAt;

        private string _updatedBy;

        #endregion

        #region "Public"

        public int DelayInterestRateID { get { return this._delayInterestRateID.ToNonNullable(); } set { this._delayInterestRateID = value; } }

        public decimal DelayInterestRate { get { return this._delayInterestRate.ToNonNullable(); } set { this._delayInterestRate = value; } }

        public DateTime CreatedAt { get { return this._createdAt.ToNonNullable(); } set { this._createdAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CreatedBy { get { return this._createdBy; } set { this._createdBy = value; } }

        public DateTime UpdatedAt { get { return this._updatedAt.ToNonNullable(); } set { this._updatedAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }

        #endregion

        #region "IsNull"

        public bool IsDelayInterestRateIDNull() { return this._delayInterestRateID == null; }

        public bool IsDelayInterestRateNull() { return this._delayInterestRate == null; }

        public bool IsCreatedAtNull() { return this._createdAt == null; }

        public bool IsCreatedByNull() { return this._createdBy == null; }

        public bool IsUpdatedAtNull() { return this._updatedAt == null; }

        public bool IsUpdatedByNull() { return this._updatedBy == null; }

        #endregion

        #region "SetNull"

        public void SetInterestRateIDNull() { this._delayInterestRateID = null; }

        public void SetInterestRateNull() { this._delayInterestRate = null; }

        public void SetCreatedAtNull() { this._createdAt = null; }

        public void SetCreatedByNull() { this._createdBy = null; }

        public void SetUpdatedAtNull() { this._updatedAt = null; }

        public void SetUpdatedByNull() { this._updatedBy = null; }

        #endregion
    }
}