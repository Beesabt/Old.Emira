using emira.HelperFunctions;
using emira.DataAccessLayer;
using emira.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using emira.GUI;
using System.Globalization;

namespace emira.BusinessLogicLayer
{
    class Holiday
    {

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        CustomMsgBox _customMsgBox;
        DatabaseHandler _DBHandler;
        DataTable _dataTable;
        Person _actualPerson;

        /// <summary>
        /// It's fill out the dropdown list with years to the user can choose which year of holidays want to see.
        /// </summary>
        /// <returns>Return with the years as string list.</returns>
        public List<string> GetYears()
        {
            List<string> _years = new List<string>();

            try
            {
                _DBHandler = new DatabaseHandler();
                int _year = 0;
                int _smallestYear = 0;
                int _actualYear = DateTime.Today.Year;
                string _smallestUsedYear = _DBHandler.GetTheSmallestYear();

                Int32.TryParse(_smallestUsedYear, out _smallestYear);

                if (_smallestYear == 0 || _smallestYear == _actualYear)
                {
                    _years.Add(_actualYear.ToString());
                    return _years;
                }

                for (int i = 0; _smallestYear < _actualYear; i++)
                {
                    _year = (_smallestYear + i);
                    _years.Add(_year.ToString());
                }

                return _years;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                _customMsgBox = new CustomMsgBox();
                _customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);

                _years.Add(DateTime.Today.Year.ToString());
                return _years;
            }
        }

        /// <summary>
        /// It gives back the table what the user will see in the Holidays form
        /// </summary>
        /// <param name="selectedYear">The selected year from the combobox</param>
        /// <param name="selectedStatus">The selected status from the combobox</param>
        /// <returns>The data table with all values</returns>
        public DataTable GetHolidaysTable(string selectedYear, string selectedStatus)
        {
            _dataTable = new DataTable();

            try
            {
                _DBHandler = new DatabaseHandler();
                bool _selectedStatusDB = false;
                bool _state = false;
                int _numberOfDays = 0;
                DateTime _startDate = new DateTime();
                DateTime _endDate = new DateTime();

                if (selectedStatus != "All" && selectedStatus == "Actual")
                {
                    _selectedStatusDB = true;
                }

                _dataTable = _DBHandler.GetHolidaysFromDB(selectedYear, _selectedStatusDB);

                // Remove the PersonalID column because it is not necessary for the user
                _dataTable.Columns.Remove(Texts.HolidayProperties.PersonID);

                // Add checkbox column to the beginning table
                _dataTable.Columns.Add("Select", typeof(Boolean)).SetOrdinal(0);

                // Set 'Approved' or 'Storno' for holidays
                _dataTable.Columns.Add("State", typeof(String));

                foreach (DataRow row in _dataTable.Rows)
                {
                    if (Boolean.TryParse(row[Texts.HolidayProperties.Status].ToString(), out _state))
                    {
                        if (_state)
                        {
                            row["State"] = "Approved";
                            row["Select"] = _state;
                        }
                        else
                        {
                            row["State"] = "Storno";
                            row["Select"] = _state;
                        }
                    }
                }

                // Remove the original Status column
                _dataTable.Columns.Remove(Texts.HolidayProperties.Status);

                // Add Days column (Int32) to the end of the table
                _dataTable.Columns.Add("Days", typeof(Int32)).SetOrdinal(3);

                // Count the days
                foreach (DataRow row in _dataTable.Rows)
                {
                    if (DateTime.TryParse(row[Texts.HolidayProperties.StartDate].ToString(), out _startDate))
                    {
                        if (DateTime.TryParse(row[Texts.HolidayProperties.EndDate].ToString(), out _endDate))
                        {
                            _numberOfDays = _endDate.Subtract(_startDate).Days;
                            row["Days"] = _numberOfDays + 1;
                        }
                    }
                }

                return _dataTable;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                _customMsgBox = new CustomMsgBox();
                _customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _dataTable;
            }
        }

        /// <summary>
        /// This method get the actual person's information related to holiday.
        /// </summary>
        /// <returns>Return with the actual person's informataion which are necessary for the holiday calculation.</returns>
        private Person GetPersonalInformation()
        {
            try
            {
                DateTime _dateOfStart = new DateTime();
                DateTime _dateOfBirth = new DateTime();
                int _numberOfChildren = 0;
                int _numberOfDisabledChildren = 0;
                int _numberOfNewBornBabies = 0;
                bool _healtDamage = false;
                _actualPerson = new Person();
                _DBHandler = new DatabaseHandler();
                _dataTable = new DataTable();
                _dataTable = _DBHandler.GetPersonalInformationDB();

                foreach (DataRow person in _dataTable.Rows)
                {
                    if (DateTime.TryParse(person[Texts.PersonProperties.DateOfStart].ToString(), out _dateOfStart))
                    {
                        _actualPerson.DateOfStart = _dateOfStart;
                    }

                    if (DateTime.TryParse(person[Texts.PersonProperties.DateOfBirth].ToString(), out _dateOfBirth))
                    {
                        _actualPerson.DateOfBirth = _dateOfBirth;
                    }

                    if (Int32.TryParse(person[Texts.PersonProperties.NumberOfChildren].ToString(), out _numberOfChildren))
                    {
                        _actualPerson.NumberOfChildren = _numberOfChildren;
                    }

                    if (Int32.TryParse(person[Texts.PersonProperties.NumberOfChildren].ToString(), out _numberOfDisabledChildren))
                    {
                        _actualPerson.NumberOfDisabledChildren = _numberOfDisabledChildren;
                    }

                    if (Int32.TryParse(person[Texts.PersonProperties.NumberOfChildren].ToString(), out _numberOfNewBornBabies))
                    {
                        _actualPerson.NumberOfNewBornBabies = _numberOfNewBornBabies;
                    }

                    if (Boolean.TryParse(person[Texts.PersonProperties.NumberOfChildren].ToString(), out _healtDamage))
                    {
                        _actualPerson.HealthDamage = _healtDamage;
                    }
                }

                return _actualPerson;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                _customMsgBox = new CustomMsgBox();
                _customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                _actualPerson = new Person();
                return _actualPerson;
            }
        }

        /// <summary>
        /// This method give back the number of the holidays which the actual person gets for the actual year.
        /// </summary>
        /// <returns>Returns back the number of the holdays for the actual year</returns>
        public int CountHolidays()
        {
            int _numberOfBasicHolidays = 20;
            int _holidays = 0;
            DateTime _today = DateTime.Today;
            int _actualYear = _today.Year;
            Person _person;

            try
            {
                _person = new Person();
                _person = GetPersonalInformation();

                if (_person == null)
                {
                    _customMsgBox = new CustomMsgBox();
                    _customMsgBox.Show(Texts.WarningMessages.PersonInformationMissing, Texts.Captions.Warning, CustomMsgBox.MsgBoxIcon.Warning, CustomMsgBox.Button.Close);
                    return _holidays;
                }

                // Basic holidays
                _holidays = _numberOfBasicHolidays;

                // Age of the user
                int _dateOfBirth = _person.DateOfBirth.Year;
                int _age = _actualYear - _dateOfBirth;


                // Days after age of the user
                if (25 <= _age && _age < 28)
                {
                    _holidays += 1;
                }
                else if (_age < 31)
                {
                    _holidays += 2;
                }
                else if (_age < 33)
                {
                    _holidays += 3;
                }
                else if (_age < 35)
                {
                    _holidays += 4;
                }
                else if (_age < 37)
                {
                    _holidays += 5;
                }
                else if (_age < 39)
                {
                    _holidays += 6;
                }
                else if (_age < 41)
                {
                    _holidays += 7;
                }
                else if (_age < 43)
                {
                    _holidays += 8;
                }
                else if (_age < 45)
                {
                    _holidays += 9;
                }
                else if (45 <= _age)
                {
                    _holidays += 10;
                }

                // If the user starts to work in actual year
                DateTime _dateOfStart = _person.DateOfStart;
                double _remainHoliday = 0;
                if (_actualYear == _dateOfStart.Year)
                {
                    double _daysInYear = DateTime.IsLeapYear(_actualYear) ? 366 : 365;
                    double _daysLeftInYear = _daysInYear - _dateOfStart.DayOfYear;
                    _remainHoliday = (_holidays / _daysInYear) * _daysLeftInYear;
                    _remainHoliday = Math.Round(_remainHoliday, 0, MidpointRounding.AwayFromZero);
                    Int32.TryParse(_remainHoliday.ToString(), out _holidays);
                }

                // Days after children
                int _numberOfChildren = _person.NumberOfChildren;

                if (_numberOfChildren > 0)
                {
                    switch (_numberOfChildren)
                    {
                        case 1:
                            _holidays += 2;
                            break;
                        case 2:
                            _holidays += 4;
                            break;
                        default:
                            _holidays += 7;
                            break;
                    }
                }

                // Days after disabled children
                int _numberOfDisabledChildren = _person.NumberOfDisabledChildren;

                if (_numberOfDisabledChildren > 0)
                {
                    _holidays += 2;
                }

                // Days after new born babies
                int _numberOfNewBornBabies = _person.NumberOfNewBornBabies;

                if (_numberOfNewBornBabies == 1)
                {
                    _holidays += 5;

                }

                if (_numberOfNewBornBabies > 1)
                {
                    _holidays += 7;
                }

                // Days after 50% health damage
                bool _healthDamage = _person.HealthDamage;

                if (_healthDamage)
                {
                    _holidays += 5;
                }


                return _holidays;

            }
            catch (Exception error)
            {
                Logger.Error(error);
                _customMsgBox = new CustomMsgBox();
                _customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _holidays;
            }
        }

        /// <summary>
        /// This method gives back the number of the remaining days for the actual years
        /// </summary>
        /// <returns>number of the remaining days for the year</returns>
        public int GetRemainingDaysForActualYear()
        {
            int _holidays = 0;
            int _numberOfTheUsedDays = 0;
            int _remainingDays = 0;
            try
            {
                _holidays = CountHolidays();
                _numberOfTheUsedDays = GetUsedHolidays(DateTime.Today.Year);

                _remainingDays = _holidays - _numberOfTheUsedDays;

                return _remainingDays;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                _customMsgBox = new CustomMsgBox();
                _customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _remainingDays;
            }
        }

        /// <summary>
        /// This method give back the number of the used holidays which the actual person has used already in the actual year.
        /// </summary>
        /// <returns>Return with the number of the used holidays in the actual year.</returns>
        public int GetUsedHolidays(int year)
        {
            DateTime _startDate = new DateTime();
            DateTime _endDate = new DateTime();
            int _usedDays = 0;

            try
            {
                _DBHandler = new DatabaseHandler();
                _dataTable = new DataTable();
                _dataTable = _DBHandler.GetUsedHolidays(year);
                foreach (DataRow holiday in _dataTable.Rows)
                {
                    DateTime.TryParse(holiday[Texts.HolidayProperties.StartDate].ToString(), out _startDate);

                    DateTime.TryParse(holiday[Texts.HolidayProperties.EndDate].ToString(), out _endDate);

                    _usedDays += _endDate.Subtract(_startDate).Days + 1;
                }
                return _usedDays;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                _customMsgBox = new CustomMsgBox();
                _customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _usedDays;
            }
        }

        /// <summary>
        /// The selected holiday period can be already approved therefore needs a date validation
        /// </summary>
        /// <param name="startDate">start date of the selected holiday period</param>
        /// <param name="endDate">end date of the selected holiday period</param>
        /// <returns>RowID(s) of the conflicted holiday(s)</returns>
        public List<string> ChooseDateValidation(string startDate, string endDate)
        {
            List<string> _conflictedIDs = new List<string>();

            try
            {
                string _ID = string.Empty;
                _DBHandler = new DatabaseHandler();
                _dataTable = new DataTable();

                _dataTable = _DBHandler.GetConflictedDateIDs(startDate, endDate);
                if (_dataTable != null)
                {
                    foreach (DataRow ID in _dataTable.Rows)
                    {
                        _ID = ID[Texts.HolidayProperties.RowID].ToString();
                        _conflictedIDs.Add(_ID);
                    }
                }
                return _conflictedIDs;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                _customMsgBox = new CustomMsgBox();
                _customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _conflictedIDs;
            }
        }

        /// <summary>
        /// Add holiday
        /// </summary>
        /// <param name="startDate">start date of the selected holiday period</param>
        /// <param name="endDate">end date of the selected holiday period</param>
        /// <returns>True if the add was successful</returns>
        public bool AddNewHoliday(string startDate, string endDate)
        {
            bool _isSuccess = false;

            try
            {
                int _result = 0;

                _DBHandler = new DatabaseHandler();
                _dataTable = new DataTable();
                _result = _DBHandler.AddNewHolidayToDB(LogInfo.UserID, startDate, endDate);
                if (_result > 0)
                    _isSuccess = true;
                return _isSuccess;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                _customMsgBox = new CustomMsgBox();
                _customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _isSuccess;
            }
        }

        /// <summary>
        /// Remove holiday from the Actual holidays
        /// </summary>
        /// <param name="startDate">start date of the selected holiday period</param>
        /// <param name="endDate">end date of the selected holiday period</param>
        /// <returns>True if the holiday is removed from Actual holidays</returns>
        public bool DeleteHoliday(string startDate, string endDate)
        {
            bool _isSuccess = false;
            try
            {
                _DBHandler = new DatabaseHandler();
                string _ID = string.Empty;
                int updatedRow = 0;

                // Get the rowID of the holiday
                // Cut the time
                startDate = startDate.Remove(12);
                endDate = endDate.Remove(12);

                // Replace the delimiter to '-'
                startDate = startDate.Replace(". ", "-");
                endDate = endDate.Replace(". ", "-");

                _ID = _DBHandler.GetRowID(startDate, endDate);
     
                // Remove the holiday from Actual
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add(Texts.HolidayProperties.Status, "False");
                updatedRow =_DBHandler.UpdateHoliday(data, Texts.HolidayProperties.RowID, _ID, updatedRow);
                if (updatedRow > 0)
                    _isSuccess = true;
                return _isSuccess;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                _customMsgBox = new CustomMsgBox();
                _customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _isSuccess;
            }
        }

    }
}
