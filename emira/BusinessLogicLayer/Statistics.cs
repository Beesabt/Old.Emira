using System;
using System.Collections.Generic;

using emira.GUI;
using emira.DataAccessLayer;
using emira.Utilities;

using System.Data;
using System.Globalization;


namespace emira.BusinessLogicLayer
{
    class Statistics
    {

        DatabaseHandler DBHandler;
        DataTable dataTable;
        DateTime today = DateTime.UtcNow;

        /// <summary>
        /// Get the years from the Catalog table
        /// </summary>
        /// <returns>Return with used years</returns>
        public List<string> GetYears()
        {
            List<string> _dates = new List<string>();
            try
            {
                DateTime _start = today.AddYears(-7);

                string _actualMonth = string.Empty;
                string _actualYear = string.Empty;

                for (int i = 0; i < 12; i++)
                {
                    _start = _start.AddYears(1);
                    _actualYear = _start.Year.ToString();

                    // Add to list the year
                    _dates.Add(_actualYear);
                }

                return _dates;
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
                return _dates;
            }
        }

        /// <summary>
        /// Get the current month's tasks with hours
        /// </summary>
        /// <param name="selectedYear">selected year</param>
        /// <param name="selectedMonth">selected month</param>
        /// <returns>Return with a datatable with tasks and hours</returns>
        public DataTable GetDataCurrentMonth(string selectedYear, string selectedMonth)
        {
            dataTable = new DataTable();
            try
            {
                DBHandler = new DatabaseHandler();

                // Get month with number
                CultureInfo ci = new CultureInfo("hu-HU");
                int _month;
                _month = DateTime.ParseExact(selectedMonth, "MMMM", ci).Month;

                // Add zero if the number is under 10
                string _selectedMonth = string.Empty;
                _selectedMonth = _month.ToString();
                if (_month < 10)
                {
                    _selectedMonth = "0" + _month.ToString();
                }

                // Get the data
                dataTable = DBHandler.GetTasksAndHours(selectedYear, _selectedMonth);

                return dataTable;
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
                return dataTable;
            }
        }



    }
}
