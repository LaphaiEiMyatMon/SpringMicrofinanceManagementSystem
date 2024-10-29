using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Spring_Microfinance_Management_System.Extension;

namespace Spring_Microfinance_Management_System.Models.Base
{
    public class BaseTB_ProductTypeEntity
    {
        #region "private"

        private int? _productTypeID;

        private string _productType;

        private DateTime? _createdAt;

        private string _createdBy;

        private DateTime? _updatedAt;

        private string _updatedBy;

        #endregion

        #region "Public"

        public int ProductTypeID { get { return this._productTypeID.ToNonNullable(); } set { this._productTypeID = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ProductType { get { return this._productType; } set { this._productType = value; } }
      
        public DateTime CreatedAt { get { return this._createdAt.ToNonNullable(); } set { this._createdAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CreatedBy { get { return this._createdBy; } set { this._createdBy = value; } }

        public DateTime UpdatedAt { get { return this._updatedAt.ToNonNullable(); } set { this._updatedAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }

        #endregion

        #region "IsNull"

        public bool IsProductTypeIDNull() { return this._productTypeID == null; }

        public bool IsProductTypeNull() { return this._productType == null; }

        public bool IsCreatedAtNull() { return this._createdAt == null; }

        public bool IsCreatedByNull() { return this._createdBy == null; }

        public bool IsUpdatedAtNull() { return this._updatedAt == null; }

        public bool IsUpdatedByNull() { return this._updatedBy == null; }

        #endregion

        #region "SetNull"

        public void SetProductTypeIDNull() { this._productTypeID = null; }

        public void SetProductTypeNull() { this._productType = null; }

        public void SetCreatedAtNull() { this._createdAt = null; }

        public void SetCreatedByNull() { this._createdBy = null; }

        public void SetUpdatedAtNull() { this._updatedAt = null; }

        public void SetUpdatedByNull() { this._updatedBy = null; }

        #endregion
    }
}