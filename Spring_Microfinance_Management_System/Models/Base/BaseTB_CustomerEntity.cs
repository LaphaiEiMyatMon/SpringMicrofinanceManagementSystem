using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Spring_Microfinance_Management_System.Extension;

namespace Spring_Microfinance_Management_System.Models.Base
{
    public class BaseTB_CustomerEntity
    {
        
        #region "private"
        private int _customerID;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private string _fatherName;
        private string _nrcNo;
        private string _dateOfBirth;
        private string _address;
        private string _phNo1;
        private string _phNo2;
        private string _profilePicture;
        private CusGender _gender;
        private BusinessType _businessType;
        private string _monthlyIncome;
        private string _companyName;
        private string _companyAddress;
        private string _companyPhoneNumber;
        private int _bankAccNo;
        private string _cardNumber;
        private string _cardHolderName;
        private string _expirationDate;
        private int _cvv;
        private Status _status;
        private MaritalStatus _maritalStatus;
        private DateTime? _createdAt;
        private string _createdBy;
        private DateTime? _updatedAt;
        private string _updatedBy;
        #endregion

        #region "Public"

        public int CustomerID { get { return this._customerID; } set { this._customerID = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FirstName { get { return this._firstName; } set { this._firstName = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string LastName { get { return this._lastName; } set { this._lastName = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Email { get { return this._email; } set { this._email = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Password { get { return this._password; } set { this._password = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FatherName { get { return this._fatherName; } set { this._fatherName = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string NRCNo { get { return this._nrcNo; } set { this._nrcNo = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string DateOfBirth { get { return this._dateOfBirth; } set { this._dateOfBirth = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Address { get { return this._address; } set { this._address = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PhoneNumber1 { get { return this._phNo1; } set { this._phNo1 = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PhoneNumber2 { get { return this._phNo2; } set { this._phNo2 = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ProfilePicture { get { return this._profilePicture; } set { this._profilePicture = value; } }

        [Required]
        public CusGender Gender { get { return this._gender; } set { this._gender = value; } }

        [Required]
        public BusinessType BusinessType { get { return this._businessType; } set { this._businessType = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string MonthlyIncome { get { return this._monthlyIncome; } set { this._monthlyIncome = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CompanyAddress { get { return this._companyAddress; } set { this._companyAddress = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CompanyName { get { return this._companyName; } set { this._companyName = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CompanyPhoneNumber { get { return this._companyPhoneNumber; } set { this._companyPhoneNumber = value; } }

        [Required]
        public int BankAccNo { get { return this._bankAccNo; } set { this._bankAccNo = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CardNumber { get { return this._cardNumber; } set { this._cardNumber = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CardHolderName { get { return this._cardHolderName; } set { this._cardHolderName = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ExpirationDate { get { return this._expirationDate; } set { this._expirationDate = value; } }

        public int CVV { get { return this._cvv; } set { this._cvv = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public Status Status { get { return this._status; } set { this._status = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public MaritalStatus MaritalStatus { get { return this._maritalStatus; } set { this._maritalStatus = value; } }

        public DateTime CreatedAt { get { return this._createdAt.ToNonNullable(); } set { this._createdAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CreatedBy { get { return this._createdBy; } set { this._createdBy = value; } }

        public DateTime UpdatedAt { get { return this._updatedAt.ToNonNullable(); } set { this._updatedAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }

        public int RoleID { get; set; }

        #endregion

        #region "Is Null"
        public bool IsCustomerIDNull() { return this._customerID == 0; }

        public bool IsFirstNameNull() { return this._firstName == null; }

        public bool IsLastNameNull() { return this._lastName == null; }

        public bool IsEmailNull() { return this._email == null; }

        public bool IsPasswordNull() { return this._password == null; }

        public bool IsFatherNameNull() { return this._fatherName == null; }

        public bool IsNRCNoNull() { return this._nrcNo == null; }

        public bool IsDateOfBirthNull() { return this._dateOfBirth == null; }

        public bool IsAddressNull() { return this._address == null; }

        public bool IsPhoneNumber1Null() { return this._phNo1 == null; }

        public bool IsPhoneNumber2Null() { return this._phNo2 == null; }

        public bool IsProfilePictureNull() { return this._profilePicture == null; }

        public bool IsGenderNull() { return this._gender == null; }

        public bool IsBusinessTypeNull() { return this._businessType == null; }

        public bool IsMonthlyIncomeNull() { return this._monthlyIncome == null; }

        public bool IsCompanyAddressNull() { return this._companyAddress == null; }

        public bool IsCompanyNameNull() { return this._companyName == null; }

        public bool IsCompanyPhoneNumberNull() { return this._companyPhoneNumber == null; }

        public bool IsBankAccNoNull() { return this._bankAccNo == 0; }

        public bool IsCardNumberNull() { return this._cardNumber == null; }

        public bool IsCardHolderNameNull() { return this._cardHolderName == null; }

        public bool IsExpirationDateNull() { return this._expirationDate == null; }

        public bool IsCVVNull() { return this._cvv == 0; }

        public bool IsStatusNull() { return this._status  == null; }

        public bool IsMaritalStatusNull() { return this._maritalStatus == null; }

        public bool IsCreatedAtNull() { return this._createdAt == null; }

        public bool IsCreatedByNull() { return this._createdBy == null; }

        public bool IsUpdatedAtNull() { return this._updatedAt == null; }

        public bool IsUpdatedByNull() { return this._updatedBy == null; }
        #endregion


        #region "Set Null"
        public void SetFirstNameNull() { this._firstName = null; }

        public void SetLastNameNull() { this._lastName = null; }

        public void SetEmailNull() { this._email = null; }

        public void SetPasswordNull() { this._password = null; }

        public void SetFatherNameNull() {  this._fatherName = null; }

        public void SetNRCNoNull() {  this._nrcNo = null; }

        public void SetDateOfBirthNull() {  this._dateOfBirth = null; }

        public void SetAddressNull() {  this._address = null; }

        public void SetPhoneNumber1Null() {  this._phNo1 = null; }

        public void SetPhoneNumber2Null() {  this._phNo2 = null; }

        public void SetProfilePictureNull() {  this._profilePicture = null; }

        public void SetGenderNull() {  this._gender = 0; }

        public void SetBusinessTypeNull() {  this._businessType = 0; }

        public void SetMonthlyIncomeNull() {  this._monthlyIncome = null; }

        public void SetCompanyNameNull() { this._companyName = null; }

        public void SetCompanyAddressNull() {  this._companyAddress = null; }

        public void SetCompanyPhoneNumberNull() {  this._companyPhoneNumber = null; }

        public void SetCardNumberNull() {  this._cardNumber = null; }

        public void SetCardHolderNameNull() {  this._cardHolderName = null; }

        public void SetExpirationDateNull() {  this._expirationDate = null; }

        public void SetCVVNull() {  this._cvv = 0; }

        public void SetStatusNull() {  this._status = 0; }

        public void SetMaritalStatusNull() {  this._maritalStatus = 0; }

        public void SetCreatedAtNull() { this._createdAt = null; }

        public void SetCreatedByNull() { this._createdBy = null; }

        public void SetUpdatedAtNull() { this._updatedAt = null; }

        public void SetUpdatedByNull() { this._updatedBy = null; }
        #endregion
    }


}