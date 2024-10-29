using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Spring_Microfinance_Management_System.Extension;

namespace Spring_Microfinance_Management_System.Models.Base
{
    public class BaseTB_GuarantorEntity
    {
        #region Private
        private int _guarantorID;
        private int _customerID;
        private string _name;
        private string _email;
        private string _dateOfBirth;
        private CusGender _gender;
        private string _profilePicture;
        private string _relation;
        private string _address;
        private string _phNo;
        private string _nrcNo;
        private string _cardNumber;
        private string _cardHolderName;
        private string _expirationDate;
        private int _cvv;
        private DateTime? _createdAt;
        private string _createdBy;
        private DateTime? _updatedAt;
        private string _updatedBy;
        #endregion

        #region Public
        public int CustomerID { get { return this._customerID; } set { this._customerID = value; } }

        public int GuarantorID { get { return this._guarantorID; } set { this._guarantorID = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Name { get { return this._name; } set { this._name = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Relation { get { return this._relation; } set { this._relation = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Address { get { return this._address; } set { this._address = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PhNo { get { return this._phNo; } set { this._phNo = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string NRCNo { get { return this._nrcNo; } set { this._nrcNo = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Email { get { return this._email; } set { this._email = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string DateOfBirth { get { return this._dateOfBirth; } set { this._dateOfBirth = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ProfilePicture { get { return this._profilePicture; } set { this._profilePicture = value; } }

        [Required]
        public CusGender Gender { get { return this._gender; } set { this._gender = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CardNumber { get { return this._cardNumber; } set { this._cardNumber = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CardHolderName { get { return this._cardHolderName; } set { this._cardHolderName = value; } }
        
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ExpirationDate { get { return this._expirationDate; } set { this._expirationDate = value; } }

        public int CVV { get { return this._cvv; } set { this._cvv = value; } }

        public DateTime CreatedAt { get { return this._createdAt.ToNonNullable(); } set { this._createdAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CreatedBy { get { return this._createdBy; } set { this._createdBy = value; } }

        public DateTime UpdatedAt { get { return this._updatedAt.ToNonNullable(); } set { this._updatedAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }
        #endregion

        #region Is Null

        public bool IsCustomerIDNull() { return this._customerID == 0; }

        public bool IsGuarantorNull() { return this._guarantorID == 0; }

        public bool IsNameNull() { return this._name == null; }

        public bool IsRelationNull() { return this._relation == null; }

        public bool IsAddressNull() { return this._address == null; }

        public bool IsPhNoNull() { return this._phNo == null; }

        public bool IsNRCNoNull() { return this._nrcNo == null; }

        public bool IsCardNumberNull() { return this._cardNumber == null; }

        public bool IsCardHolderNameNull() { return this._cardHolderName == null; }

        public bool IsExpirationDateNull() { return this._expirationDate == null; }

        public bool IsCVVNull() { return this._cvv == 0; }

        public bool IsEmailNull() { return this._email == null; }

        public bool IsDateOfBirthNull() { return this._dateOfBirth == null; }

        public bool IsProfilePictureNull() { return this._profilePicture == null; }

        public bool IsGenderNull() { return this._gender == null; }

        public bool IsCreatedAtNull() { return this._createdAt == null; }

        public bool IsCreatedByNull() { return this._createdBy == null; }

        public bool IsUpdatedAtNull() { return this._updatedAt == null; }

        public bool IsUpdatedByNull() { return this._updatedBy == null; }
        #endregion

    }
}