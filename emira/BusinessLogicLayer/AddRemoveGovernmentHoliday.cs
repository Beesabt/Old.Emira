using System;
using System.Collections.Generic;

using NLog;
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

        /// <summary>
        /// It's fill out the dropdown list with years to the user can choose which year of government holidays want to see.
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
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);

                _years.Add(DateTime.Today.Year.ToString());
                return _years;
            }
        }
    }
}
