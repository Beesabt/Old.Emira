using System;
using System.Data;
using System.Collections.Generic;

using NLog;
using Nager.Date;
using emira.GUI;
using emira.DataAccessLayer;
using emira.HelperFunctions;

namespace emira.BusinessLogicLayer
{
    class AddRemoveGovernmentHoliday
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        CustomMsgBox customMsgBox;
        DatabaseHandler DBHandler;
        DataTable dataTable;

        /// <summary>
        /// Get the years (back - 2 years, forward - 1 years)
        /// </summary>
        /// <returns>List of the years and months</returns>
        public List<string> GetYears()
        {
            List<string> _years = new List<string>();

            try
            {
                DateTime _today = DateTime.Today;
                int _startYear = _today.AddYears(-2).Year;
                int _actualYear = 0;

                for (int i = 0; i < 4; i++)
                {
                    _actualYear = _startYear + i;

                    // Add to list the year                     
                    _years.Add(_actualYear.ToString());
                }

                return _years;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);

                _years.Add(DateTime.Today.Year.ToString());
                return _years;
            }
        }

        /// <summary>
        /// It gives back the table what the user will see in the Government Holidays form
        /// </summary>
        /// <param name="selectedYear">The selected year from the combobox</param>
        /// <returns>The data table with all values</returns>
        public DataTable GetHolidaysTable(string selectedYear)
        {
            dataTable = new DataTable();

            try
            {
                DBHandler = new DatabaseHandler();
                dataTable = new DataTable();
                DateTime _date = new DateTime();

                dataTable = DBHandler.GetGovernmentHolidaysFromDB(selectedYear);

                // Add Select column to the table
                dataTable.Columns.Add("Select", typeof(Boolean)).SetOrdinal(0);

                // Add Day column to the table
                dataTable.Columns.Add("Day", typeof(String)).SetOrdinal(2);

                // Which day is the date
                foreach (DataRow row in dataTable.Rows)
                {
                    if (DateTime.TryParse(row[Texts.GovernmentHolidaysProperties.Date].ToString(), out _date))
                    {
                        row["Day"] = _date.DayOfWeek;
                    }
                }

                return dataTable;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return dataTable;
            }
        }     

        /// <summary>
        /// It gives back the date is holiday or not
        /// </summary>
        /// <param name="date">the selected date</param>
        /// <returns>True, if it exists and false if not</returns>
        public bool isHoliday(string date)
        {
            bool _isExist = true;
            try
            {
                DBHandler = new DatabaseHandler();

                _isExist = DBHandler.isHoliday(date);

                return _isExist;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);

                return _isExist;
            }
        }     

        /// <summary>
        /// Add holdiay to the Government holidays
        /// </summary>
        /// <param name="date">the selected day</param>
        public bool AddHoliday(string date)
        {
            bool _isSuccess = false;
            try
            {
                int _effectedRow = 0;
                DBHandler = new DatabaseHandler();

               _effectedRow = DBHandler.AddNewGovernmentHoliday(date);

                if (_effectedRow > 0)
                    _isSuccess = true;

                return _isSuccess;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _isSuccess;
            }
        }

        /// <summary>
        /// Delete the date form the Government holidays
        /// </summary>
        /// <param name="date">the selected date</param>
        public bool DeleteHoliday(string date)
        {
            bool _isSuccess = false;
            try
            {
                int _effectedRow = 0;
                DBHandler = new DatabaseHandler();

                _effectedRow = DBHandler.DeleteNewGovernmentHoliday(date);

                if (_effectedRow > 0)
                    _isSuccess = true;

                return _isSuccess;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _isSuccess;
            }
        }
    }
}
