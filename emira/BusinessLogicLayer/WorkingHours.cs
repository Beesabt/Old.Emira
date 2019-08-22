using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using emira.GUI;
using emira.DataAccessLayer;
using emira.HelperFunctions;

using NLog;


namespace emira.BusinessLogicLayer
{
    class WorkingHours
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        DatabaseHandler DBHandler;
        DataTable dataTable;
        DateTime today = DateTime.UtcNow;
        CustomMsgBox customMsgBox;

        /// <summary>
        /// Get the yers and months (back - 6 months, forward - 5 months)
        /// </summary>
        /// <returns>List of the years and months</returns>
        public List<string> GetYearsAndMonths()
        {
            List<string> _dates = new List<string>();
            try
            {
                DateTime _start = today.AddMonths(-7);
                StringBuilder _sb = new StringBuilder();

                string _actualMonth = string.Empty;
                string _actualYear = string.Empty;

                for (int i = 0; i < 12; i++)
                {
                    _start = _start.AddMonths(1);
                    _actualYear = _start.Year.ToString();

                    // Add '0' for the months of 1 - 9
                    if (_start.Month < 10)
                    {
                        _actualMonth = "0" + _start.Month.ToString();
                    }
                    else
                    {
                        _actualMonth = _start.Month.ToString();
                    }

                    // Add to list the 'year-month'
                    _sb.Append(_actualYear + "-" + _actualMonth);
                    _dates.Add(_sb.ToString());

                    // Clean up the string builder for the new 'year-month'
                    _sb = _sb.Clear();
                }

                return _dates;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _dates;
            }
        }

        /// <summary>
        /// Get the task according to the selected month
        /// </summary>
        /// <param name="date">selected month</param>
        /// <returns>Task(s) of the selected month</returns>
        public DataTable GetTasksByMonth(string date)
        {
            dataTable = new DataTable();
            try
            {
                DBHandler = new DatabaseHandler();
                dataTable = DBHandler.GetTasksByMonth(date);
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
        /// Get the selected task(s) from the DB
        /// </summary>
        /// <returns>data table with the task(s)</returns>
        public DataTable GetSelectedTask()
        {
            dataTable = new DataTable();
            try
            {
                DBHandler = new DatabaseHandler();
                dataTable = DBHandler.GetSelectedTaskFromDB();
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
        /// Get the saved hours for days from the DB
        /// </summary>
        /// <param name="task">task</param>
        /// <param name="date">selected date</param>
        /// <returns>Hour for the task in the selected date</returns>
        public string GetHours(string task, string date)
        {
            string _result = string.Empty;
            try
            {
                DBHandler = new DatabaseHandler();
                string _groupID = string.Empty;
                string _taskID = string.Empty;
                string _date = string.Empty;

                // Remove the task Name
                _taskID = task.Remove(task.IndexOf(' '));

                // Get the group ID and task ID
                _groupID = _taskID.Remove(_taskID.IndexOf('_'));
                _taskID = _taskID.Substring(_taskID.IndexOf('_') + 1);

                _result = DBHandler.GetHoursFromCatalog(_groupID, _taskID, date);

                return _result;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _result;   
            }          
        }

        /// <summary>
        /// Save the hours into the Catalog
        /// </summary>
        /// <param name="task">Task name wiht ID and Name</param>
        /// <param name="date">The date</param>
        /// <param name="numberOfHours">The hours</param>
        /// <returns>True if it was success</returns>
        public bool SaveHour(string task, string date, double numberOfHours)
        {
            string _groupID = string.Empty;
            string _taskID = string.Empty;
            string _taskName = string.Empty;
            bool _isSuccess = false;
            int _result = 0;
            int _rowid = 0;
            DBHandler = new DatabaseHandler();

            // Remove the task Name
            _taskID = task.Remove(task.IndexOf(' '));
            _taskName = task.Substring(task.IndexOf(' ') + 1);

            // Get the group ID and task ID
            _groupID = _taskID.Remove(_taskID.IndexOf('_'));
            _taskID = _taskID.Substring(_taskID.IndexOf('_') + 1);

            // If it is update
            _rowid = DBHandler.IsRecordExist(_groupID, _taskID, date);

            if (_rowid > 0)
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add(Texts.CatalogProperties.NumberOfHours, numberOfHours.ToString());

                _isSuccess = DBHandler.ModifyHourInCatalog(data, _rowid.ToString());

                return _isSuccess;
            }

            _result = DBHandler.SaveHourToCatalog(_groupID, _taskID, _taskName, date, numberOfHours);

            if (_result > 0) { _isSuccess = true; }

            return _isSuccess;
        }

        /// <summary>
        /// Delete the hours from the Catalog
        /// </summary>
        /// <param name="task">Task name wiht ID and Name</param>
        /// <param name="date">The date</param>
        /// <returns>True if it was success</returns>
        public bool RemoveHour(string task, string date)
        {
            string _groupID = string.Empty;
            string _taskID = string.Empty;
            bool _isSuccess = false;
            int _result = 0;
            DBHandler = new DatabaseHandler();

            // Remove the task Name
            _taskID = task.Remove(task.IndexOf(' '));

            // Get the group ID and task ID
            _groupID = _taskID.Remove(_taskID.IndexOf('_'));
            _taskID = _taskID.Substring(_taskID.IndexOf('_') + 1);

            // Remove the record from the DB
            _result = DBHandler.DeleteHourFromCatalog(_groupID, _taskID, date);

            if (_result > 0) { _isSuccess = true; }

            return _isSuccess;
        }

        /// <summary>
        /// Get the acutal year and month
        /// </summary>
        /// <returns>Actual 'year-month'</returns>
        public string GetActualMonth()
        {
            StringBuilder _sb = new StringBuilder();
            try
            {
                string _actualMonth = string.Empty;
                string _actualYear = string.Empty;

                // Get the actual year
                _actualYear = today.Year.ToString();

                // Get actual month and add '0' for the months of 1 - 9
                if (today.Month < 10)
                {
                    _actualMonth = "0" + today.Month.ToString();
                }
                else
                {
                    _actualMonth = today.Month.ToString();
                }

                _sb.Append(_actualYear + "-" + _actualMonth);

                return _sb.ToString();
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _sb.ToString();
            }
        }

        /// <summary>
        /// Get the days of the actual selected month
        /// </summary>
        /// <param name="year">year of the selected date</param>
        /// <param name="month">month of the selected date</param>
        /// <returns>Days of the selected month</returns>
        public int GetDaysOfMonth(int year, int month)
        {
            int _dayOfMonth = 0;
            try
            {
                _dayOfMonth = DateTime.DaysInMonth(year, month);

                return _dayOfMonth;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _dayOfMonth;
            }
        }

        /// <summary>
        /// Get the holiday(s) of the user for the selected month
        /// </summary>
        /// <param name="date">Selected month ('year-month')</param>
        /// <returns>Holiday(s) for the selected month</returns>
        public DataTable GetHolidaysForSelectedMonth(string date)
        {
            dataTable = new DataTable();
            try
            {
                DBHandler = new DatabaseHandler();
                dataTable = DBHandler.GetHolidaysByMonth(date);
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
        /// Get the working hours of the user
        /// </summary>
        /// <returns>Working hours</returns>
        public int GetWorkingHoursOfTheUser()
        {
            int _workingHours = 8;
            try
            {
                DBHandler = new DatabaseHandler();
                _workingHours = DBHandler.GetWorkingHours();
                return _workingHours;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _workingHours;
            }
        }

        /// <summary>
        /// Get the government holidays which are set by the user
        /// </summary>
        /// <returns>Government holiday(s)</returns>
        public DataTable GetGovernmentHolidays()
        {
            dataTable = new DataTable();
            try
            {
                DBHandler = new DatabaseHandler();
                dataTable = DBHandler.GetGovernmentHolidaysFromDB();
                return dataTable;
            }
            catch(Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return dataTable;
            }
        }
    }
}
