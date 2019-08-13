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
        /// This method get the actual person's information related to holiday.
        /// </summary>
        /// <returns>Return with the actual person's informataion which are necessary for the holiday calculation.</returns>
        private Person GetPersonalInformation()
        {

            _actualPerson = new Person();
            _DBHandler = new DatabaseHandler();
            _dataTable = new DataTable();
            _dataTable = _DBHandler.GetPersonalInformationDB();

            foreach (DataRow person in _dataTable.Rows)
            {
                _actualPerson.DateOfStart = Convert.ToDateTime(person[Texts.PersonProperties.DateOfStart]);
                _actualPerson.DateOfBirth = Convert.ToDateTime(person[Texts.PersonProperties.DateOfBirth]);
                _actualPerson.NumberOfChildren = Convert.ToInt32(person[Texts.PersonProperties.NumberOfChildren]);
                _actualPerson.NumberOfDisabledChildren = Convert.ToInt32(person[Texts.PersonProperties.NumberOfDisabledChildren]);
                _actualPerson.NumberOfNewBornBabies = Convert.ToInt32(person[Texts.PersonProperties.NumberOfNewBornBabies]);
                _actualPerson.HealthDamage = Convert.ToBoolean(person[Texts.PersonProperties.HealthDamage]);
            }

            return _actualPerson;
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

        /// <summary>
        /// This method give back the number of the holidays which the actual person gets for the actual year.
        /// </summary>
        /// <returns>Returns back the number of the holdays for the actual year</returns>
        public int CountHolidays()
        {
            int HolidaysInTheYear = 20;

            DateTime today = DateTime.Today;
            int actualYear = today.Year;

            Person person = new Person();
            person = GetPersonalInformation();

            DateTime DateOfStart = person.DateOfStart;
            int DateOfBirth = person.DateOfBirth.Year;
            int NumberOfChildren = person.NumberOfChildren;
            int NumberOfDisabledChildren = person.NumberOfDisabledChildren;
            int NumberOfNewBornBabies = person.NumberOfNewBornBabies;
            bool HealthDamage = person.HealthDamage;

            int Age = actualYear - DateOfBirth;

            // Days after Age
            switch (Age)
            {
                case 25:
                    HolidaysInTheYear += 1;
                    break;
                case 28:
                    HolidaysInTheYear += 2;
                    break;
                case 31:
                    HolidaysInTheYear += 3;
                    break;
                case 33:
                    HolidaysInTheYear += 4;
                    break;
                case 35:
                    HolidaysInTheYear += 5;
                    break;
                case 37:
                    HolidaysInTheYear += 6;
                    break;
                case 39:
                    HolidaysInTheYear += 7;
                    break;
                case 41:
                    HolidaysInTheYear += 8;
                    break;
                case 43:
                    HolidaysInTheYear += 9;
                    break;
                case 45:
                    HolidaysInTheYear += 10;
                    break;
                default:
                    HolidaysInTheYear += 0;
                    break;
            }

            // Days after children
            if (NumberOfChildren != 0)
            {
                switch (NumberOfChildren)
                {
                    case 1:
                        HolidaysInTheYear += 2;
                        break;
                    case 2:
                        HolidaysInTheYear += 4;
                        break;
                    default:
                        HolidaysInTheYear += 7;
                        break;
                }
            }

            // Days after disabled children
            if (NumberOfDisabledChildren != 0)
            {
                HolidaysInTheYear += 2;
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
