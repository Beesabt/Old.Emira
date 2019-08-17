using emira.DataAccessLayer;
using emira.HelperFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace emira.BusinessLogicLayer
{
    class WorkingHours
    {

        DatabaseHandler DBHandler;
        DataTable dataTable;
        DateTime today = DateTime.UtcNow;

        public DataTable GetTasksByMonth(string date)
        {
            DBHandler = new DatabaseHandler();
            dataTable = new DataTable();
            dataTable = DBHandler.GetTasksByMonth(date);
            return dataTable;
        }

        /// <summary>
        /// Get the selected task(s) from the DB
        /// </summary>
        /// <returns>data table with the task(s)</returns>
        public DataTable GetSelectedTask()
        {
            DBHandler = new DatabaseHandler();
            dataTable = new DataTable();
            dataTable = DBHandler.GetSelectedTaskFromDB();
            return dataTable;
        }

        /// <summary>
        /// Get the saved hours for days from the DB
        /// </summary>
        /// <param name="taskID">task ID</param>
        /// <param name="date">selected date</param>
        /// <returns>Hour for the task in the selected date</returns>
        public string GetHours(string taskID, string date)
        {
            string result = string.Empty;
            DBHandler = new DatabaseHandler();
            int _index = 0;
            string _taskID = string.Empty;
            string _date = string.Empty;

            _index = taskID.IndexOf(' ');
            _taskID = taskID.Remove(_index);

            result = DBHandler.GetHoursFromCathalogue(_taskID, date);
            return result;
        }

        public bool SaveHour(string task, string date, double numberOfHours)
        {
            bool _isSuccess = false;
            int _result = 0;
            int _rowid = 0;
            int updatedRow = 0;
            DBHandler = new DatabaseHandler();

            // Get taskID
            int _index = 0;
            string _taskID = string.Empty;

            _index = task.IndexOf(' ');
            _taskID = task.Remove(_index);
            
            // If it is update
            _rowid = DBHandler.IsRecordExist(_taskID, date);

            if (_rowid > 0)
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add(Texts.CatalogProperties.NumberOfHours, numberOfHours.ToString());

                _isSuccess = DBHandler.ModifyHourInCathalog(data, _rowid.ToString(), updatedRow);

                return _isSuccess;
            }

            _result = DBHandler.SaveHourToCathalog(_taskID, date, numberOfHours);

            if (_result > 0) { _isSuccess = true; }

            return _isSuccess;
        }

        public bool RemoveHour(string task, string date)
        {
            bool _isSuccess = false;
            int _result = 0;
            DBHandler = new DatabaseHandler();

            // Get taskID
            int _index = 0;
            string _taskID = string.Empty;

            _index = task.IndexOf(' ');
            _taskID = task.Remove(_index);

            // Remove the record from the DB
           _result = DBHandler.DeleteHourFromCatalog(_taskID, date);

            if (_result > 0) { _isSuccess = true; }

            return _isSuccess;
        }

        public List<string> GetYearsAndMonths()
        {
            DateTime _start = today.AddMonths(-7);
            List<string> Dates = new List<string>();
            StringBuilder sb = new StringBuilder();
            string _actualMonth = string.Empty;
            string _actualYear = string.Empty;

            for (int i = 0; i < 12; i++)
            {
                _start = _start.AddMonths(1);
                _actualYear = _start.Year.ToString();
                if (_start.Month < 10)
                {
                    _actualMonth = "0" + _start.Month.ToString();
                }
                else
                {
                    _actualMonth = _start.Month.ToString();
                }

                sb.Append(_actualYear);
                sb.Append("-" + _actualMonth);

                Dates.Add(sb.ToString());

                sb = sb.Clear();

            }

            return Dates;
        }

        public string GetActualMonth()
        {
            string _actualMonth = string.Empty;
            string _actualYear = string.Empty;
            StringBuilder sb = new StringBuilder();

            _actualYear = today.Year.ToString();
            if (today.Month < 10)
            {
                _actualMonth = "0" + today.Month.ToString();
            }
            else
            {
                _actualMonth = today.Month.ToString();
            }

            sb.Append(_actualYear);
            sb.Append("-" + _actualMonth);

            return sb.ToString();
        }

        public int GetDaysOfMonth(int year, int month)
        {
            int _DayOfMonth = 0;

            _DayOfMonth = DateTime.DaysInMonth(year, month);

            return _DayOfMonth;
        }


    }
}
