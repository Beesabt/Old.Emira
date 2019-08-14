using emira.HelperFunctions;
using emira.DataAccessLayer;
using emira.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using emira.GUI;

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
            try
            {
                _DBHandler = new DatabaseHandler();
                List<string> _years = new List<string>();
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

                List<string> _years = new List<string>();
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
            try
            {
                _DBHandler = new DatabaseHandler();
                _dataTable = new DataTable();
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
                _dataTable = new DataTable();
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


            //DateTime DateOfStart = person.DateOfStart;


            //int NumberOfNewBornBabies = person.NumberOfNewBornBabies;
            //bool HealthDamage = person.HealthDamage;

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
                switch (_age)
                {
                    case 25:
                        _holidays += 1;
                        break;
                    case 28:
                        _holidays += 2;
                        break;
                    case 31:
                        _holidays += 3;
                        break;
                    case 33:
                        _holidays += 4;
                        break;
                    case 35:
                        _holidays += 5;
                        break;
                    case 37:
                        _holidays += 6;
                        break;
                    case 39:
                        _holidays += 7;
                        break;
                    case 41:
                        _holidays += 8;
                        break;
                    case 43:
                        _holidays += 9;
                        break;
                    case 45:
                        _holidays += 10;
                        break;
                    default:
                        break;
                }

                // If the user starts to work in actual year
                DateTime _dateOfStart = _person.DateOfStart;

                if (_actualYear == _dateOfStart.Year)
                {
                    int _daysInYear = DateTime.IsLeapYear(_actualYear) ? 366 : 365;
                    int _daysLeftInYear = _daysInYear - _dateOfStart.DayOfYear;
                    _holidays = _holidays / _daysInYear + _daysLeftInYear;
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


            }
            catch (Exception error)
            {
                Logger.Error(error);
                _customMsgBox = new CustomMsgBox();
                _customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }


           

         

            

            // Days after new born babies
            if (NumberOfNewBornBabies > 1)
            {
                HolidaysInTheYear += 7;
            }
            else if (NumberOfChildren == 1)
            {
                HolidaysInTheYear += 5;
            }

            // Days after 50% health damage
            if (HealthDamage == true)
            {
                HolidaysInTheYear += 5;
            }

            // Remaining days, if he/she starts in the actual year
            if (DateOfStart.Year == actualYear)
            {
                DateTime LastDayOfTheYear = new DateTime(actualYear, 12, 31);
                double holidayForDay = Convert.ToDouble(HolidaysInTheYear) / 365;
                int RemainingDays = Convert.ToInt32((LastDayOfTheYear.Subtract(DateOfStart)).TotalDays);
                HolidaysInTheYear = Convert.ToInt32(Math.Ceiling(holidayForDay * RemainingDays));
            }


            // If the user starts after 1st of October
            if (DateOfStart.Month == 10 && DateOfStart.Year == actualYear - 1 && today.Month <= 3 && today.Day <= 31)
            {
                int UsedHolidaysInLastYear = GetUsedHolidays(actualYear - 1);

            }

            return HolidaysInTheYear;
        }
















        public bool AddNewHoliday(DateTime from, DateTime to)
        {
            bool _isSuccess = false;
            int _result = 0;
            string _sID = string.Empty;
            int _iID = 0;
            string _startDate = string.Empty;
            string _endDate = string.Empty;

            _startDate = from.ToShortDateString().Replace(". ", "-").Trim('.');
            _endDate = to.ToShortDateString().Replace(". ", "-").Trim('.');

            _DBHandler = new DatabaseHandler();
            _dataTable = new DataTable();
            _sID = _DBHandler.GetMaxIDFromHoliday();
            if (string.IsNullOrEmpty(_sID))
            {
                _sID = "0";
            }

            _iID = Convert.ToInt32(_sID);
            _result = _DBHandler.AddNewHolidayToDB(_iID + 1, LogInfo.UserID, _startDate, _endDate);
            if (_result > 0) { _isSuccess = true; }
            return _isSuccess;
        }

        public bool DeleteHoliday(string ID)
        {
            bool _isSuccess = false;
            //int updatedRow = 0;        
            //_DBHandler = new DatabaseHandler();
            //Dictionary<string, string> data = new Dictionary<string, string>();
            //data.Add(Texts.HolidayProperties.Status, "False");
            //_isSuccess = _DBHandler.UpdateHoliday(data, Texts.HolidayProperties.ID, ID, updatedRow);
            return _isSuccess;
        }





        /// <summary>
        /// This method give back the number of the used holidays which the actual person has used already in the actual year.
        /// </summary>
        /// <returns>Return with the number of the used holidays in the actual year.</returns>
        public int GetUsedHolidays(int year)
        {
            DateTime StartDate;
            DateTime EndDate;
            double UsedDays = 0;

            _DBHandler = new DatabaseHandler();
            _dataTable = new DataTable();
            _dataTable = _DBHandler.GetUsedHolidays(year);
            foreach (DataRow holiday in _dataTable.Rows)
            {
                StartDate = Convert.ToDateTime(holiday[Texts.HolidayProperties.StartDate]);
                EndDate = Convert.ToDateTime(holiday[Texts.HolidayProperties.StartDate]);

                //TODO: kiszedni ezt az if-et innen és megoldani 24h-val
                if (StartDate == EndDate)
                {
                    UsedDays += 1;
                }
                else
                {
                    TimeSpan Days = EndDate.Subtract(StartDate);
                    UsedDays += Days.TotalDays;
                }
            }

            return Convert.ToInt32(UsedDays);
        }



        public int GetRemainingDaysForActualYear()
        {

            int HolidaysInTheYear = CountHolidays();
            int NumberOfTheUsedDays = GetUsedHolidays(DateTime.Today.Year);

            int RemainingDays = HolidaysInTheYear - NumberOfTheUsedDays;

            return RemainingDays;
        }

        public List<string> ChooseDateValidation(DateTime startDate, DateTime endDate)
        {
            List<string> _conflictedIDs = new List<string>();
            string _startDate = string.Empty;
            string _endDate = string.Empty;
            string _ID = string.Empty;

            _startDate = startDate.ToShortDateString().Replace(". ", "-").Trim('.');
            _endDate = endDate.ToShortDateString().Replace(". ", "-").Trim('.');

            _DBHandler = new DatabaseHandler();
            _dataTable = new DataTable();
            _dataTable = _DBHandler.GetConflictedDateIDs(_startDate, _endDate);
            if (_dataTable != null)
            {
                foreach (DataRow ID in _dataTable.Rows)
                {
                    // _ID = ID[Texts.HolidayProperties.ID].ToString();
                    _conflictedIDs.Add(_ID);
                }
            }
            return _conflictedIDs;
        }
    }
}
