using emira.DataAccessLayer;
using System;
using System.Data;

namespace emira.BusinessLogicLayer
{
    class WorkingHours
    {
        DatabaseHandler _DBHandler;
        DataTable _dataTable;

        public DataTable GetSelectedTask()
        {
            _DBHandler = new DatabaseHandler();
            _dataTable = new DataTable();
            _dataTable = _DBHandler.GetSelectedTaskFromDB();
            return _dataTable;
        }

        public string GetHours(string taskID, string date)
        {
            string result = string.Empty;
            _DBHandler = new DatabaseHandler();
            int _index = 0;
            string _taskID = string.Empty;
            string _date = string.Empty;

            _index = taskID.IndexOf(' ');
            _taskID = taskID.Remove(_index + 1);

            // Cut the last point from the date
            _index = date.IndexOf('(');
            _date = date.Remove(_index - 4);

            // Replace the last two points to minus (SQL date format)
            _date = _date.Replace(". ", "-");

            result = _DBHandler.GetHoursFromCathalogue(_taskID, _date);
            return result;
        }

        public void DeleteHoursOfTheWeek(string beginOfTheWeek, string endOfTheWeek)
        {
            int _result = 0;
            int _index = 0;
            string _beginDate = string.Empty;
            string _endDate = string.Empty;
            _DBHandler = new DatabaseHandler();

            // Cut the last point from the date
            _index = beginOfTheWeek.IndexOf('(');
            _beginDate = beginOfTheWeek.Remove(_index - 4);

            // Cut the last point from the date
            _index = endOfTheWeek.IndexOf('(');
            _endDate = endOfTheWeek.Remove(_index - 4);

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
            _result = _DBHandler.SaveHourToCathalogue(_iID+1, _taskID, _date, numberOfHours);
            if(_result > 0) { _isSuccess = true; }
            return _isSuccess;
        }


    }
}
