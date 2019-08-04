using emira.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace emira.BusinessLogicLayer
{
    class WorkingHours
    {

        DatabaseHandler _DBHandler;
        DataTable _dataTable;
        DateTime _today = DateTime.UtcNow;

        /// <summary>
        /// Get the selected task(s) from the DB
        /// </summary>
        /// <returns>data table with the task(s)</returns>
        public DataTable GetSelectedTask()
        {
            _DBHandler = new DatabaseHandler();
            _dataTable = new DataTable();
            _dataTable = _DBHandler.GetSelectedTaskFromDB();
            return _dataTable;
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
            _DBHandler = new DatabaseHandler();
            int _index = 0;
            string _taskID = string.Empty;
            string _date = string.Empty;

            _index = taskID.IndexOf(' ');
            _taskID = taskID.Remove(_index + 1);

            result = _DBHandler.GetHoursFromCathalogue(_taskID, date);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="beginOfTheWeek"></param>
        /// <param name="endOfTheWeek"></param>
        public void DeleteHoursOfTheWeek(string beginOfTheWeek, string endOfTheWeek)
        {
            int _result = 0;
            int _index = 0;
            string _beginDate = string.Empty;
            string _endDate = string.Empty;
            _DBHandler = new DatabaseHandler();

            _result = _DBHandler.DeleteWeek(_beginDate, _endDate);
        }

        public bool SaveHour(string taskID, string date, double numberOfHours)
        {
            bool _isSuccess = false;
            int _result = 0;

            int _index = 0;
            string _sID = string.Empty;
            int _iID = 0;
            string _taskID = string.Empty;
            string _date = string.Empty;


            _DBHandler = new DatabaseHandler();

            _index = taskID.IndexOf(' ');
            _taskID = taskID.Remove(_index + 1);

            // Cut the last point from the date
            _index = date.IndexOf('(');
            _date = date.Remove(_index - 4);

            // Replace the last two points to minus (SQL date format)
            _date = _date.Replace(". ", "-");

            _sID = _DBHandler.GetMaxIDFromCathalogue();
            if (string.IsNullOrEmpty(_sID))
            {
                _sID = "0";
            }
            _iID = Convert.ToInt32(_sID);
            _result = _DBHandler.SaveHourToCathalogue(_iID + 1, _taskID, _date, numberOfHours);
            if (_result > 0) { _isSuccess = true; }
            return _isSuccess;
        }

        public List<string> GetYearsAndMonths()
        {
            DateTime _start = _today.AddMonths(-7);
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

            _actualYear = _today.Year.ToString();
            if (_today.Month < 10)
            {
                _actualMonth = "0" + _today.Month.ToString();
            }
            else
            {
                _actualMonth = _today.Month.ToString();
            }

            sb.Append(_actualYear);
            sb.Append("-" + _actualMonth);

            return sb.ToString();
        }

        public int GetDaysOfMonth()
        {
            int _DayOfMonth = 0;

            _DayOfMonth = DateTime.DaysInMonth(_today.Year, _today.Month);

            return _DayOfMonth;
        }


    }
}
