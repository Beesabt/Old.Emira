using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Microsoft.Office.Interop.Word;

using emira.DataAccessLayer;
using emira.Utilities;
using emira.GUI;

namespace emira.BusinessLogicLayer
{
    class WorkingHours
    {
        CustomMsgBox customMsgBox;
        DatabaseHandler DBHandler;
        System.Data.DataTable dataTable;
        DateTime today = DateTime.UtcNow;

        /// <summary>
        /// Get the years and months (back - 6 months, forward - 5 months)
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
                MyLogger.GetInstance().Error(error.Message);
                return _dates;
            }
        }

        /// <summary>
        /// Get the task according to the selected month
        /// </summary>
        /// <param name="date">selected month</param>
        /// <returns>Task(s) of the selected month</returns>
        public System.Data.DataTable GetTasksByMonth(string date)
        {
            dataTable = new System.Data.DataTable();
            try
            {
                DBHandler = new DatabaseHandler();
                dataTable = DBHandler.GetTasksByMonth(date);
                return dataTable;
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
                return dataTable;
            }
        }

        /// <summary>
        /// Get the selected task(s) from the DB
        /// </summary>
        /// <returns>data table with the task(s)</returns>
        public System.Data.DataTable GetSelectedTask()
        {
            dataTable = new System.Data.DataTable();
            try
            {
                DBHandler = new DatabaseHandler();
                dataTable = DBHandler.GetSelectedTaskFromDB();
                return dataTable;
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
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
                MyLogger.GetInstance().Error(error.Message);
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
            bool _isSuccess = false;

            try
            {
                string _groupID = string.Empty;
                string _taskID = string.Empty;
                string _taskName = string.Empty;
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
                    Dictionary<string, string> _data = new Dictionary<string, string>();
                    _data.Add(Texts.CatalogProperties.NumberOfHours, numberOfHours.ToString());

                    _isSuccess = DBHandler.ModifyHourInCatalog(_data, _rowid.ToString());

                    return _isSuccess;
                }

                _result = DBHandler.SaveHourToCatalog(_groupID, _taskID, _taskName, date, numberOfHours);

                if (_result > 0) { _isSuccess = true; }

                return _isSuccess;
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
                return _isSuccess;
            }
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
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool CheckBeforeLock(string date)
        {
            bool _lockIsPossible = false;

            try
            {
                DBHandler = new DatabaseHandler();
                int _numberOfRecords = 0;

                _numberOfRecords = DBHandler.GetNumberOfRecords(date);

                return _lockIsPossible;
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
                return _lockIsPossible;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool LockMonth(string date, string value)
        {
            bool _isSuccess = false;

            try
            {
                DBHandler = new DatabaseHandler();

                Dictionary<string, string> _lock = new Dictionary<string, string>();
                _lock.Add(Texts.CatalogProperties.Locked, value);

                _isSuccess = DBHandler.LockMonthInDB(_lock, date);

                return _isSuccess;
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
                return _isSuccess;
            }
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
                MyLogger.GetInstance().Error(error.Message);
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
                MyLogger.GetInstance().Error(error.Message);
                return _dayOfMonth;
            }
        }

        /// <summary>
        /// Get the holiday(s) of the user for the selected month
        /// </summary>
        /// <param name="date">Selected month ('year-month')</param>
        /// <returns>Holiday(s) for the selected month</returns>
        public System.Data.DataTable GetHolidaysForSelectedMonth(string date)
        {
            dataTable = new System.Data.DataTable();
            try
            {
                DBHandler = new DatabaseHandler();
                dataTable = DBHandler.GetHolidaysByMonth(date);
                return dataTable;
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
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
                MyLogger.GetInstance().Error(error.Message);
                return _workingHours;
            }
        }

        /// <summary>
        /// Get the government holidays which are set by the user
        /// </summary>
        /// <returns>Government holiday(s)</returns>
        public System.Data.DataTable GetGovernmentHolidays()
        {
            dataTable = new System.Data.DataTable();
            try
            {
                DBHandler = new DatabaseHandler();
                dataTable = DBHandler.GetGovernmentHolidaysFromDB();
                return dataTable;
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
                return dataTable;
            }
        }

        /// <summary>
        /// Export the working days into a word document
        /// </summary>
        /// <param name="dgv">The selected month</param>
        /// <param name="filename">file name</param>
        public void ExportToMSWord(DataGridView dgv, object filename)
        {
            int _cellRow = 0;
            int _cellColumn = 0;

            //Create a missing variable for missing value  
            object missing = System.Reflection.Missing.Value;

            //Create an instance for word app  
            Microsoft.Office.Interop.Word.Application _winword = new Microsoft.Office.Interop.Word.Application();

            try
            {
                //Set animation status for word application  
                _winword.ShowAnimation = false;

                //Set status for word application is to be visible or not.  
                _winword.Visible = false;

                //Create a new document  
                Document _document = _winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                //adding text to document
                _document.PageSetup.LeftMargin = 20f;
                _document.PageSetup.RightMargin = 20f;
                _document.PageSetup.BottomMargin = 20f;
                _document.PageSetup.TopMargin = 20f;
                _document.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
                _document.Content.SetRange(0, 0);
                _document.Content.Text = "This is test document " + Environment.NewLine;

                //Add paragraph with Normal style  
                Paragraph para1 = _document.Content.Paragraphs.Add(ref missing);
                object styleHeading1 = _document.Styles[WdBuiltinStyle.wdStyleNormal].NameLocal;
                para1.Range.set_Style(ref styleHeading1);
                para1.Range.Text = "Para 1 text";
                para1.Range.InsertParagraphAfter();
                para1.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                para1.Format.SpaceBefore = 0;
                para1.Format.SpaceAfter = 0;

                //Create the table 
                Table _wordTable = _document.Tables.Add(para1.Range, dgv.RowCount + 1, dgv.ColumnCount + 1, ref missing, ref missing);

                // Border of the table
                _wordTable.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                _wordTable.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                // Headers
                string[] _columnsText = new string[dgv.ColumnCount + 1];
                _columnsText[0] = "Task";
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    _columnsText[column.Index + 1] = column.HeaderText;
                }

                int _numberOfCells = dgv.Rows[0].Cells.Count;
                string[,] _rowsText = new string[dgv.RowCount, _numberOfCells + 1];


                for (int i = 0; i < dgv.RowCount; i++)
                {
                    _rowsText[i, 0] = dgv.Rows[i].HeaderCell.Value.ToString();
                    for (int j = 0; j < _numberOfCells; j++)
                    {
                        if (dgv.Rows[i].Cells[j].Value == null)
                        {
                            dgv.Rows[i].Cells[j].Value = string.Empty;
                        }
                        _rowsText[i, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                    }
                }

                foreach (Row row in _wordTable.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        //other format properties goes here  
                        cell.Range.Font.Name = "verdana";
                        cell.Range.Font.Size = 8;
                        cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                        //Center alignment for the Header cells  
                        cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                        //Header row  
                        if (cell.RowIndex == 1)
                        {
                            cell.Range.Text = _columnsText[cell.ColumnIndex - 1];
                        }
                        //Data row  
                        else
                        {
                            _cellRow = cell.RowIndex;
                            _cellColumn = cell.ColumnIndex;
                            cell.Range.Text = _rowsText[cell.RowIndex - 2, cell.ColumnIndex - 1];
                            cell.Shading.BackgroundPatternColor = WdColor.wdColorWhite;
                        }
                    }
                }

                _wordTable.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;


                // Width               
                _document.Tables[1].AllowAutoFit = true;
                _document.Tables[1].AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);


                //Save the document
                _document.SaveAs2(ref filename);
                _document.Close(ref missing, ref missing, ref missing);
                _document = null;
                _winword.Quit(ref missing, ref missing, ref missing);
                _winword = null;

                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.InformationMessages.SuccessfulDocumentCreation, Texts.Captions.Information, CustomMsgBox.MsgBoxIcon.Information, CustomMsgBox.Button.OK);

            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message + "The cell row: " + _cellRow + " column: " + _cellColumn);
                _winword.Quit(ref missing, ref missing, ref missing);
            }
        }
    }
}
