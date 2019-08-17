using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

using emira.DataAccessLayer;
using emira.ValueObjects;
using emira.HelperFunctions;
using emira.GUI;

namespace emira.BusinessLogicLayer
{
    class Settings
    {

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        bool bIsSuccess = false;
        DatabaseHandler DBHandler;
        DataTable dataTable;
        Person actualPerson;
        CustomMsgBox customMsgBox;

        /// <summary>
        /// Get the user's name, register number, company name, cost center and position
        /// </summary>
        /// <returns>Person object with the values</returns>
        public Person GetSomePersonalInformation()
        {
            try
            {
                actualPerson = new Person();
                DBHandler = new DatabaseHandler();
                dataTable = new DataTable();

                // Get information from the DB
                dataTable = DBHandler.GetSomePersonalInforamtionFromDB();

                // Add the information for a Person object
                foreach (DataRow person in dataTable.Rows)
                {
                    #region Name
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.Name]))
                    {
                        actualPerson.Name = person[Texts.PersonProperties.Name].ToString();
                    }
                    else
                    {
                        actualPerson.Name = string.Empty;
                    }
                    #endregion

                    #region RegisterNumber
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.RegisterNumber]))
                    {
                        int _registerNumber = 0;
                        Int32.TryParse(person[Texts.PersonProperties.RegisterNumber].ToString(), out _registerNumber);
                        actualPerson.RegisterNumber = _registerNumber;
                    }
                    else
                    {
                        actualPerson.RegisterNumber = 0;
                    }
                    #endregion

                    #region Company
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.Company]))
                    {
                        actualPerson.Company = person[Texts.PersonProperties.Company].ToString();
                    }
                    else
                    {
                        actualPerson.Company = string.Empty;
                    }
                    #endregion

                    #region CostCenter
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.CostCenter]))
                    {
                        actualPerson.CostCenter = person[Texts.PersonProperties.CostCenter].ToString();
                    }
                    else
                    {
                        actualPerson.CostCenter = string.Empty;
                    }
                    #endregion

                    #region Position
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.Position]))
                    {
                        actualPerson.Position = person[Texts.PersonProperties.Position].ToString();
                    }
                    else
                    {
                        actualPerson.Position = string.Empty;
                    }
                    #endregion          
                }

                return actualPerson;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);

                actualPerson = new Person();
                return actualPerson;
            }
        }

        /// <summary>
        /// Get the information from the user from DB
        /// </summary>
        /// <returns>actual user with data</returns>
        public Person GetPersonalInformation()
        {
            try
            {
                actualPerson = new Person();
                DBHandler = new DatabaseHandler();
                dataTable = new DataTable();

                // Get information from the DB
                dataTable = DBHandler.GetPersonalInformationDB();

                // Add the information for a Person object
                foreach (DataRow person in dataTable.Rows)
                {
                    #region Password
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.Password]))
                    {
                        actualPerson.Password = person[Texts.PersonProperties.Password].ToString();
                    }
                    else
                    {
                        actualPerson.Password = string.Empty;
                    }
                    #endregion

                    #region Email
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.Email]))
                    {
                        actualPerson.Email = person[Texts.PersonProperties.Email].ToString();
                    }
                    else
                    {
                        actualPerson.Email = string.Empty;
                    }
                    #endregion

                    #region Name
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.Name]))
                    {
                        actualPerson.Name = person[Texts.PersonProperties.Name].ToString();
                    }
                    else
                    {
                        actualPerson.Name = string.Empty;
                    }
                    #endregion

                    #region Gender
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.Gender]))
                    {
                        actualPerson.Gender = Convert.ToBoolean(person[Texts.PersonProperties.Gender]);
                    }
                    #endregion

                    #region RegisterNumber
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.RegisterNumber]))
                    {
                        int _registerNumber = 0;
                        Int32.TryParse(person[Texts.PersonProperties.RegisterNumber].ToString(), out _registerNumber);
                        actualPerson.RegisterNumber = _registerNumber;
                    }
                    else
                    {
                        actualPerson.RegisterNumber = 0;
                    }
                    #endregion

                    #region Company
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.Company]))
                    {
                        actualPerson.Company = person[Texts.PersonProperties.Company].ToString();
                    }
                    else
                    {
                        actualPerson.Company = string.Empty;
                    }
                    #endregion

                    #region CostCenter
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.CostCenter]))
                    {
                        actualPerson.CostCenter = person[Texts.PersonProperties.CostCenter].ToString();
                    }
                    else
                    {
                        actualPerson.CostCenter = string.Empty;
                    }
                    #endregion

                    #region Position
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.Position]))
                    {
                        actualPerson.Position = person[Texts.PersonProperties.Position].ToString();
                    }
                    else
                    {
                        actualPerson.Position = string.Empty;
                    }
                    #endregion

                    #region WorkingHours
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.WorkingHours]))
                    {
                        int _workingHours = 0;
                        Int32.TryParse(person[Texts.PersonProperties.WorkingHours].ToString(), out _workingHours);
                        actualPerson.WorkingHours = _workingHours;
                    }
                    else
                    {
                        actualPerson.WorkingHours = 0;
                    }
                    #endregion

                    #region DateOfStart
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.DateOfStart]))
                    {
                        DateTime _dateOfStart = new DateTime();
                        DateTime.TryParse(person[Texts.PersonProperties.DateOfStart].ToString(), out _dateOfStart);
                        actualPerson.DateOfStart = _dateOfStart;
                    }
                    else
                    {
                        actualPerson.DateOfStart = DateTime.Today;
                    }
                    #endregion

                    #region DateOfBirth
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.DateOfBirth]))
                    {
                        DateTime _dateOfBirth = new DateTime();
                        DateTime.TryParse(person[Texts.PersonProperties.DateOfBirth].ToString(), out _dateOfBirth);
                        actualPerson.DateOfBirth = _dateOfBirth;
                    }
                    else
                    {
                        actualPerson.DateOfBirth = DateTime.Today;
                    }
                    #endregion

                    #region NumberOfChildren
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.NumberOfChildren]))
                    {
                        int _numberOfChildren = 0;
                        Int32.TryParse(person[Texts.PersonProperties.NumberOfChildren].ToString(), out _numberOfChildren);
                        actualPerson.NumberOfChildren = _numberOfChildren;
                    }
                    else
                    {
                        actualPerson.NumberOfChildren = 0;
                    }
                    #endregion

                    #region NumberOfDisabledChildren
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.NumberOfDisabledChildren]))
                    {
                        int _numberOfDisabledChildren = 0;
                        Int32.TryParse(person[Texts.PersonProperties.NumberOfDisabledChildren].ToString(), out _numberOfDisabledChildren);
                        actualPerson.NumberOfDisabledChildren = _numberOfDisabledChildren;
                    }
                    else
                    {
                        actualPerson.NumberOfDisabledChildren = 0;
                    }
                    #endregion

                    #region NumberOfNewBornBabies
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.NumberOfNewBornBabies]))
                    {
                        int _numberOfNewBornBabies = 0;
                        Int32.TryParse(person[Texts.PersonProperties.NumberOfNewBornBabies].ToString(), out _numberOfNewBornBabies);
                        actualPerson.NumberOfNewBornBabies = _numberOfNewBornBabies;
                    }
                    else
                    {
                        actualPerson.NumberOfNewBornBabies = 0;
                    }
                    #endregion

                    #region HealthDamage
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.HealthDamage]))
                    {
                        bool _healthDamage = false;
                        Boolean.TryParse(person[Texts.PersonProperties.HealthDamage].ToString(), out _healthDamage);
                        actualPerson.HealthDamage = _healthDamage;
                    }
                    else
                    {
                        actualPerson.HealthDamage = false;
                    }
                    #endregion

                    #region HolidaysLeftFromPreviousYear
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.HolidaysLeftFromPreviousYear]))
                    {
                        int _holidaysLeftFromPreviousYear = 0;
                        Int32.TryParse(person[Texts.PersonProperties.HolidaysLeftFromPreviousYear].ToString(), out _holidaysLeftFromPreviousYear);
                        actualPerson.HolidaysLeftFromPreviousYear = _holidaysLeftFromPreviousYear;
                    }
                    else
                    {
                        actualPerson.HolidaysLeftFromPreviousYear = 0;
                    }
                    #endregion
                    
                    #region ExtraHoliday
                    if (!DBNull.Value.Equals(person[Texts.PersonProperties.ExtraHoliday]))
                    {
                        int _extraHoliday = 0;
                        Int32.TryParse(person[Texts.PersonProperties.ExtraHoliday].ToString(), out _extraHoliday);
                        actualPerson.ExtraHoliday = _extraHoliday;
                    }
                    else
                    {
                        actualPerson.ExtraHoliday = 0;
                    }
                    #endregion
                }

                return actualPerson;
            }
            catch(Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);

                actualPerson = new Person();
                return actualPerson;
            }
        }

        /// <summary>
        /// Set new value for Password or Email
        /// </summary>
        /// <param name="ID">User ID from DB</param>
        /// <param name="UserID">User ID from the program</param>
        /// <param name="NewValue">New value for password or email</param>
        /// <returns></returns>
        public bool SetNewValue(string ID, string UserID, string NewValue)
        {
            int _updatedRow = 0;
            try
            {
                DBHandler = new DatabaseHandler();
                Dictionary<string, string> _data = new Dictionary<string, string>();
                _data.Add(ID, NewValue);
                _updatedRow = DBHandler.SetNewValueDB(_data, ID, UserID, _updatedRow);
                if (_updatedRow > 0)
                    bIsSuccess = true;
                return bIsSuccess;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return bIsSuccess;
            }
        }

        /// <summary>
        /// Set the new values for the user
        /// </summary>
        /// <param name="ID">User ID from DB</param>
        /// <param name="UserID">User ID from the program</param>
        /// <param name="data">Informations</param>
        /// <returns></returns>
        public bool SetNewValues(string ID, string UserID, Dictionary<string, string> data)
        {
            int _updatedRow = 0;
            try
            {
                DBHandler = new DatabaseHandler();
                _updatedRow = DBHandler.SetNewValueDB(data, ID, UserID, _updatedRow);
                if (_updatedRow > 0)
                    bIsSuccess = true;
                return bIsSuccess;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return bIsSuccess;
            }
        }

        /// <summary>
        /// Validate the old value with the DB
        /// </summary>
        /// <param name="Key">Name of the field</param>
        /// <param name="Value">Value of the field</param>
        /// <returns>True if they match</returns>
        public bool OldValueValidation(string Key, string Value)
        {
            DBHandler = new DatabaseHandler();
            bIsSuccess = DBHandler.OldValueValidationDB(Key, Value);
            return bIsSuccess;
        }

        /// <summary>
        /// Validate the new password according the password's rules
        /// </summary>
        /// <param name="newPassword">Value of the new password</param>
        /// <returns>True if it is valid</returns>
        public bool IsValidPassword(string newPassword)
        {
            Regex _NumberRegex = new Regex(@"[0-9]+");
            Regex _UpperCharRegex = new Regex(@"[A-Z]+");
            Regex _Minimum8CharsRegex = new Regex(@".{8,}");
            bIsSuccess = _NumberRegex.IsMatch(newPassword) && _UpperCharRegex.IsMatch(newPassword) && _Minimum8CharsRegex.IsMatch(newPassword);
            return bIsSuccess;
        }
    }
}

