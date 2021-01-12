using System;
using System.Collections.Generic;
using System.Data;

using emira.GUI;
using emira.DataAccessLayer;
using emira.ValueObjects;
using emira.Utilities;

namespace emira.BusinessLogicLayer
{
    class Holiday
    {
        DatabaseHandler DBHandler;
        DataTable dataTable;
        Person actualPerson;
        CustomMsgBox customMsgBox;

        /// <summary>
        /// It's fill out the dropdown list with years to the user can choose which year of holidays want to see.
        /// </summary>
        /// <returns>Return with the years as string list.</returns>
        public List<string> GetYears()
        {
            List<string> _years = new List<string>();

            try
            {
                DBHandler = new DatabaseHandler();
                int _year = 0;
                int _smallestYear = 0;
                int _actualYear = DateTime.Today.Year;
                string _smallestUsedYear = DBHandler.GetTheSmallestYear();

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
                MyLogger.GetInstance().Error(error.Message);

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
            dataTable = new DataTable();

            try
            {
                DBHandler = new DatabaseHandler();
                bool _selectedStatusDB = false;
                bool _state = false;
                int _numberOfDays = 0;
                DateTime _startDate = new DateTime();
                DateTime _endDate = new DateTime();

                if (selectedStatus != "All" && selectedStatus == "Actual")
                {
                    _selectedStatusDB = true;
                }

                dataTable = DBHandler.GetHolidaysFromDB(selectedYear, _selectedStatusDB);

                // Add checkbox column to the beginning table
                dataTable.Columns.Add("Select", typeof(Boolean)).SetOrdinal(0);

                // Set 'Approved' or 'Storno' for holidays
                dataTable.Columns.Add("State", typeof(String));

                foreach (DataRow row in dataTable.Rows)
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
                dataTable.Columns.Remove(Texts.HolidayProperties.Status);

                // Add Days column (Int32) to the end of the table
                dataTable.Columns.Add("Days", typeof(Int32)).SetOrdinal(4);

                // Count the days
                foreach (DataRow row in dataTable.Rows)
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

                return dataTable;
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
                return dataTable;
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
                int _holidaysLeftFromPreviousYear = 0;
                int _extraHoliday = 0;
                bool _healtDamage = false;
                actualPerson = new Person();
                DBHandler = new DatabaseHandler();
                dataTable = new DataTable();
                dataTable = DBHandler.GetPersonalInformationDBForHoliday();

                foreach (DataRow person in dataTable.Rows)
                {
                    if (DateTime.TryParse(person[Texts.PersonProperties.DateOfStart].ToString(), out _dateOfStart))
                    {
                        actualPerson.DateOfStart = _dateOfStart;
                    }

                    if (DateTime.TryParse(person[Texts.PersonProperties.DateOfBirth].ToString(), out _dateOfBirth))
                    {
                        actualPerson.DateOfBirth = _dateOfBirth;
                    }

                    if (Int32.TryParse(person[Texts.PersonProperties.NumberOfChildren].ToString(), out _numberOfChildren))
                    {
                        actualPerson.NumberOfChildren = _numberOfChildren;
                    }

                    if (Int32.TryParse(person[Texts.PersonProperties.NumberOfChildren].ToString(), out _numberOfDisabledChildren))
                    {
                        actualPerson.NumberOfDisabledChildren = _numberOfDisabledChildren;
                    }

                    if (Int32.TryParse(person[Texts.PersonProperties.NumberOfChildren].ToString(), out _numberOfNewBornBabies))
                    {
                        actualPerson.NumberOfNewBornBabies = _numberOfNewBornBabies;
                    }

                    if (Boolean.TryParse(person[Texts.PersonProperties.NumberOfChildren].ToString(), out _healtDamage))
                    {
                        actualPerson.HealthDamage = _healtDamage;
                    }

                    if (Int32.TryParse(person[Texts.PersonProperties.HolidaysLeftFromPreviousYear].ToString(), out _holidaysLeftFromPreviousYear))
                    {
                        actualPerson.HolidaysLeftFromPreviousYear = _holidaysLeftFromPreviousYear;
                    }

                    if (Int32.TryParse(person[Texts.PersonProperties.ExtraHoliday].ToString(), out _extraHoliday))
                    {
                        actualPerson.ExtraHoliday = _extraHoliday;
                    }
                }

                return actualPerson;
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
                actualPerson = new Person();
                return actualPerson;
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
            int _actualYear = DateTime.Today.Year;

            try
            {
                actualPerson = new Person();
                actualPerson = GetPersonalInformation();

                if (actualPerson.DateOfBirth == null)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.WarningMessages.PersonInformationMissing, Texts.Captions.Warning, CustomMsgBox.MsgBoxIcon.Warning);
                    return _holidays;
                }

                // Basic holidays
                _holidays = _numberOfBasicHolidays;

                // Age of the user
                int _dateOfBirth = actualPerson.DateOfBirth.Year;
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
                DateTime _dateOfStart = actualPerson.DateOfStart;
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
                int _numberOfChildren = actualPerson.NumberOfChildren;

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
                int _numberOfDisabledChildren = actualPerson.NumberOfDisabledChildren;

                if (_numberOfDisabledChildren > 0)
                {
                    _holidays += 2;
                }

                // Days after new born babies
                int _numberOfNewBornBabies = actualPerson.NumberOfNewBornBabies;

                if (_numberOfNewBornBabies == 1)
                {
                    _holidays += 5;

                }

                if (_numberOfNewBornBabies > 1)
                {
                    _holidays += 7;
                }

                // Days after 50% health damage
                bool _healthDamage = actualPerson.HealthDamage;

                if (_healthDamage)
                {
                    _holidays += 5;
                }

                // Add holidays from last year
                int _holidaysLeftFromPreviousYear = actualPerson.HolidaysLeftFromPreviousYear;

                if (_holidaysLeftFromPreviousYear > 0)
                {
                    _holidays += _holidaysLeftFromPreviousYear;
                }

                // Extra holidays
                int _extraHolidays = actualPerson.ExtraHoliday;

                if (_extraHolidays > 0)
                {
                    _holidays += _extraHolidays;
                }

                return _holidays;

            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
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
                MyLogger.GetInstance().Error(error.Message);
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
                DBHandler = new DatabaseHandler();
                dataTable = new DataTable();
                dataTable = DBHandler.GetUsedHolidays(year);
                foreach (DataRow holiday in dataTable.Rows)
                {
                    DateTime.TryParse(holiday[Texts.HolidayProperties.StartDate].ToString(), out _startDate);

                    DateTime.TryParse(holiday[Texts.HolidayProperties.EndDate].ToString(), out _endDate);

                    _usedDays += _endDate.Subtract(_startDate).Days + 1;
                }
                return _usedDays;
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
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
                DBHandler = new DatabaseHandler();
                dataTable = new DataTable();

                dataTable = DBHandler.GetConflictedDateIDs(startDate, endDate);
                if (dataTable != null)
                {
                    foreach (DataRow ID in dataTable.Rows)
                    {
                        _ID = ID[Texts.HolidayProperties.RowID].ToString();
                        _conflictedIDs.Add(_ID);
                    }
                }
                return _conflictedIDs;
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
                return _conflictedIDs;
            }
        }

        /// <summary>
        /// It gives back the date exists or not
        /// </summary>
        /// <param name="tableName">table name</param>
        /// <param name="columnName">column name in the table</param>
        /// <param name="date">the selected date</param>
        /// <returns>True, if it exists and false if not</returns>
        public bool isExist(string tableName, string columnName, string date)
        {
            bool _isExist = true;
            try
            {
                DBHandler = new DatabaseHandler();

                _isExist = DBHandler.DoesExistHoliday(tableName, columnName, date);

                return _isExist;
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);

                return _isExist;
            }
        }

        /// <summary>
        /// It gives back the date is locked in the WorkingHours or not
        /// </summary>
        /// <param name="date">the selected date</param>
        /// <returns>True, if it is locked and false if not</returns>
        public bool isClosed(string date)
        {
            bool _isClosed = true;
            try
            {
                DBHandler = new DatabaseHandler();

                _isClosed = DBHandler.IsClosed(date);

                return _isClosed;
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);

                return _isClosed;
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
                DBHandler = new DatabaseHandler();
                dataTable = new DataTable();
                _result = DBHandler.AddNewHolidayToDB(startDate, endDate);
                if (_result > 0)
                    _isSuccess = true;
                return _isSuccess;
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
                return _isSuccess;
            }
        }

        /// <summary>
        /// Remove holiday from the Actual holidays
        /// </summary>
        /// <param name="startDate">start date of the selected holiday period</param>
        /// <param name="endDate">end date of the selected holiday period</param>
        /// <returns>True if the holiday is removed from Actual holidays</returns>
        public bool DeleteHoliday(DateTime startDate, DateTime endDate)
        {
            bool _isSuccess = false;
            try
            {
                DBHandler = new DatabaseHandler();
                string _ID = string.Empty;

                // Get the rowID of the holiday
                _ID = DBHandler.GetRowID(startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
     
                // Remove the holiday from Actual
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add(Texts.HolidayProperties.Status, "False");
                _isSuccess = DBHandler.UpdateHoliday(data, Texts.HolidayProperties.RowID, _ID);
                return _isSuccess;
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
                return _isSuccess;
            }
        }
    }
}
