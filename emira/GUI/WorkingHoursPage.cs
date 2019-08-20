using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using emira.BusinessLogicLayer;
using emira.HelperFunctions;
using Nager.Date;

namespace emira.GUI
{
    public partial class WorkingHoursPage : Form
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        int togMove;
        int mValX;
        int mValY;

        WorkingHours workingHours;
        DataTable dataTable;
        List<DataGridViewCell> changedCells = new List<DataGridViewCell>();
        CustomMsgBox customMsgBox;

        public static string cbYearWithMonthValue = string.Empty;

        public WorkingHoursPage()
        {
            InitializeComponent();

            // Set the location of the form according to the parent form's location
            // If it is zero then it set to the center of the screen
            Point _zeroLocation = new Point(0, 0);

            if (LocationInfo._location == _zeroLocation)
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = LocationInfo._location;
            }

            WorkingHours _workingHours = new WorkingHours();

            // Fill the combox with months from DB
            List<string> _dates = _workingHours.GetYearsAndMonths();

            foreach (var item in _dates)
            {
                cbYearWithMonth.Items.Add(item);
            }
        }

        private void WorkingHours_Load(object sender, EventArgs e)
        {
            try
            {
                WorkingHours _workingHours = new WorkingHours();

                // Select the actual month in the combobox
                cbYearWithMonth.SelectedItem = _workingHours.GetActualMonth();

                // Update the working hours table
                UpdateWorkingHoursTable();
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void UpdateWorkingHoursTable()
        {
            try
            {
                // Clean up all modifications
                dgvWorkingHours.Columns.Clear();
                dgvWorkingHours.Rows.Clear();
                changedCells.Clear();

                int _maxTaskLength = 0;
                int _taskLength = 0;
                int _columns = 0;
                int _rows = 0;


                string _actualTaskID = string.Empty;
                string _acutalTaskName = string.Empty;
                string _actualCellColumnHeaderValue = string.Empty;
                string _actualCellRowHeaderValue = string.Empty;
                string _actualCellValue = string.Empty;
                string _date = string.Empty;

                DateTime _today = DateTime.UtcNow;
                dataTable = new DataTable();
                workingHours = new WorkingHours();

                // Give the name of the month to the table
                string _selectedYear = cbYearWithMonth.SelectedItem.ToString().Remove(4);
                string _selectedMonth = cbYearWithMonth.SelectedItem.ToString().Substring(5);

                // Get the year and month as int
                int _year = 0;
                int _month = 0;
                Int32.TryParse(_selectedYear, out _year);

                if (Int32.TryParse(_selectedMonth, out _month))
                {
                    CultureInfo ci = new CultureInfo("hu-HU");
                    lMonth.Text = ci.DateTimeFormat.GetMonthName(_month);
                }

                // Lenght of the actual month
                int _monthLength = 0;
                _monthLength = workingHours.GetDaysOfMonth(_year, _month);

                // Add the days of the actual month to the table
                string _day = string.Empty;
                for (int i = 1; i <= _monthLength; i++)
                {
                    if (i < 10)
                    {
                        _day = "0" + i.ToString();
                    }
                    else
                    {
                        _day = i.ToString();
                    }

                    DataGridViewTextBoxColumn _column = new DataGridViewTextBoxColumn()
                    {
                        Name = _day,
                        HeaderText = _day
                    };
                    dgvWorkingHours.Columns.Add(_column);
                }

                // Add 'Summary' column in the end of the columns
                DataGridViewTextBoxColumn _totalColumn = new DataGridViewTextBoxColumn()
                {
                    Name = "TotalHoursHeader",
                    HeaderText = "Total"
                };
                dgvWorkingHours.Columns.Add(_totalColumn);

                // Get selected tasks and fill the header row with it/them
                if (_today.Month != _month)
                {

                    dataTable = workingHours.GetTasksByMonth(cbYearWithMonth.SelectedItem.ToString());

                    foreach (DataRow item in dataTable.Rows)
                    {
                        _actualTaskID = item[Texts.TaskProperties.TaskID].ToString();
                        _acutalTaskName = item[Texts.TaskProperties.TaskName].ToString();

                        DataGridViewRow _row = new DataGridViewRow();
                        _row.CreateCells(dgvWorkingHours);
                        _row.HeaderCell.Value = _actualTaskID + " " + _acutalTaskName;
                        dgvWorkingHours.Rows.Add(_row);
                    }

                    if (btnLock.Text == "Unlock")
                    {
                        // AddRemoveTask button is disabled
                        btnAddRemoveTask.Enabled = false;

                        // Sorting is disabled and columns are read only
                        foreach (DataGridViewColumn column in dgvWorkingHours.Columns)
                        {
                            column.ReadOnly = true;
                            column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }
                    }
                }
                else
                {
                    dataTable = workingHours.GetSelectedTask();

                    foreach (DataRow item in dataTable.Rows)
                    {
                        _actualTaskID = item[Texts.TaskProperties.TaskID].ToString();
                        _acutalTaskName = item[Texts.TaskProperties.TaskName].ToString();

                        _taskLength = _actualTaskID.Length + _acutalTaskName.Length;

                        if (_maxTaskLength < _taskLength)
                        {
                            _maxTaskLength = _taskLength;
                        }

                        DataGridViewRow _row = new DataGridViewRow();
                        _row.CreateCells(dgvWorkingHours);
                        _row.HeaderCell.Value = _actualTaskID + " " + _acutalTaskName;
                        dgvWorkingHours.Rows.Add(_row);
                    }

                    // Sorting is disabled and columns are editable if it is not locked
                    // And AddRemoveTask button is enabled it is is not locked
                    foreach (DataGridViewColumn column in dgvWorkingHours.Columns)
                    {
                        if (btnLock.Text == "Unlock")
                        {
                            column.ReadOnly = true;
                            btnAddRemoveTask.Enabled = false;
                        }
                        else
                        {
                            column.ReadOnly = false;
                            btnAddRemoveTask.Enabled = true;
                        }
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }

                // Set the 'Task' column's width and alignment
                dgvWorkingHours.RowHeadersWidth = 150;
                dgvWorkingHours.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                // Set the colors in the table
                UpdateColorsInWorkingHoursTable();

                // Add holidays, public holidays and government holidays to the table
                AddHolidays(_year, _month);

                // Add 'Summary' row in the end of the rows
                DataGridViewRow _totalHoursRow = new DataGridViewRow();
                _totalHoursRow.CreateCells(dgvWorkingHours);
                _totalHoursRow.HeaderCell.Value = "Total hours:";
                dgvWorkingHours.Rows.Add(_totalHoursRow);

                // Add hours from Catalog
                _columns = dgvWorkingHours.ColumnCount - 1;
                _rows = dgvWorkingHours.RowCount - 1;

                for (int i = 0; i < _rows; i++)
                {
                    for (int j = 0; j < _columns; j++)
                    {
                        DataGridViewCell _cell = dgvWorkingHours.Rows[i].Cells[j];
                        DataGridViewRow _row = dgvWorkingHours.Rows[i];

                        _actualCellColumnHeaderValue = dgvWorkingHours.Columns[j].HeaderText;

                        _date = cbYearWithMonth.SelectedItem.ToString();

                        _date = _date + "-" + _actualCellColumnHeaderValue;

                        _actualCellRowHeaderValue = _row.HeaderCell.FormattedValue.ToString();

                        _actualCellValue = workingHours.GetHours(_actualCellRowHeaderValue, _date);

                        if (!string.IsNullOrEmpty(_actualCellValue))
                        {
                            _cell.Value = _actualCellValue;
                        }
                    }
                }

                // Update the hours for totals
                UpdateTotalHours();
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void AddHolidays(int year, int month)
        {
            try
            {
                string _date = string.Empty;
                int _daysInMonth = 0;
                int _workingHours = 0;
                int _indexOfNormalHoliday = 0;
                DateTime _startDate = new DateTime();
                DateTime _endDate = new DateTime();
                dataTable = new DataTable();
                workingHours = new WorkingHours();

                // Get the first and last day of the selected month
                DateTime _fistDay = new DateTime(year, month, 1);
                _daysInMonth = DateTime.DaysInMonth(year, month);
                DateTime _lastDay = new DateTime(year, month, _daysInMonth);

                // Get the selected date
                _date = cbYearWithMonth.SelectedItem.ToString();

                // Get the holidays for the selected month
                dataTable = workingHours.GetHolidaysForSelectedMonth(_date);

                DataGridViewRow _normalHolidayRow = new DataGridViewRow();
                _normalHolidayRow.CreateCells(dgvWorkingHours);
                _normalHolidayRow.HeaderCell.Value = "0_0 Normál szabadság";

                // Get working hours of the user
                _workingHours = workingHours.GetWorkingHoursOfTheUser();

                //// ADD NORMAL HOLIDAYS
                if (dataTable.Rows.Count != 0)
                {
                    // User has holiday for the selected month so it adds the '0_0 task' into the table
                    dgvWorkingHours.Rows.Add(_normalHolidayRow);

                    // Get the last row of the table 
                    _indexOfNormalHoliday = dgvWorkingHours.Rows.IndexOf(_normalHolidayRow);

                    foreach (DataRow item in dataTable.Rows)
                    {
                        DateTime.TryParse(item[Texts.HolidayProperties.StartDate].ToString(), out _startDate);
                        DateTime.TryParse(item[Texts.HolidayProperties.EndDate].ToString(), out _endDate);

                        // 1. If the Start Date is smaller than the first date of the selected month then
                        // every day is normal holiday until the End Date
                        if (_startDate < _fistDay)
                        {
                            for (int i = 0; i < _endDate.Day; i++)
                            {
                                dgvWorkingHours.Rows[_indexOfNormalHoliday].Cells[i].Value = _workingHours;
                                dgvWorkingHours.Columns[i].ReadOnly = true;
                                dgvWorkingHours.Columns[i].DefaultCellStyle.BackColor = Color.Plum;
                            }
                            continue;
                        }

                        // 2. If the End Date is bigger than the last day of the selected month then
                        // every day is normal holiday until the end of the month
                        if (_endDate > _lastDay)
                        {
                            for (int i = _startDate.Day - 1; i < _daysInMonth; i++)
                            {
                                dgvWorkingHours.Rows[_indexOfNormalHoliday].Cells[i].Value = _workingHours;
                                dgvWorkingHours.Columns[i].ReadOnly = true;
                                dgvWorkingHours.Columns[i].DefaultCellStyle.BackColor = Color.Plum;
                            }
                            continue;
                        }

                        // 3. If the Star Date is equal with the End Date then the actual day is the normal holiday
                        if (_startDate == _endDate)
                        {
                            dgvWorkingHours.Rows[_indexOfNormalHoliday].Cells[_startDate.Day - 1].Value = _workingHours;
                            dgvWorkingHours.Columns[_startDate.Day - 1].ReadOnly = true;
                            dgvWorkingHours.Columns[_startDate.Day - 1].DefaultCellStyle.BackColor = Color.Plum;
                            continue;
                        }

                        // 4. Every day is normal holiday from Start Date to End Date
                        for (int i = _startDate.Day - 1; i < _endDate.Day; i++)
                        {
                            dgvWorkingHours.Rows[_indexOfNormalHoliday].Cells[i].Value = _workingHours;
                            dgvWorkingHours.Columns[i].ReadOnly = true;
                            dgvWorkingHours.Columns[i].DefaultCellStyle.BackColor = Color.Plum;
                        }
                    }
                }

                //// ADD PUBLIC HOLIDAYS
                var _publicHolidays = DateSystem.GetPublicHoliday(year, "HU");

                foreach (var publicHoliday in _publicHolidays)
                {
                    if (publicHoliday.Date.Month == month)
                    {
                        if (!dgvWorkingHours.Rows.Contains(_normalHolidayRow))
                        {
                            dgvWorkingHours.Rows.Add(_normalHolidayRow);
                            _indexOfNormalHoliday = dgvWorkingHours.Rows.IndexOf(_normalHolidayRow);
                        }
                        dgvWorkingHours.Rows[_indexOfNormalHoliday].Cells[publicHoliday.Date.Day - 1].Value = _workingHours;
                        dgvWorkingHours.Columns[publicHoliday.Date.Day - 1].ReadOnly = true;
                        dgvWorkingHours.Columns[publicHoliday.Date.Day - 1].DefaultCellStyle.BackColor = Color.Plum;
                    }
                }

                //// ADD GOVERNMENT HOLIDAYS
                var _governmentHolidays = workingHours.GetGovernmentHolidays();
                DateTime _governmentHoliday = new DateTime();

                foreach (DataRow item in _governmentHolidays.Rows)
                {
                    DateTime.TryParse(item[Texts.GovernmentHolidaysProperties.Date].ToString(), out _governmentHoliday);

                    if (_governmentHoliday.Month == month)
                    {
                        if (!dgvWorkingHours.Rows.Contains(_normalHolidayRow))
                            dgvWorkingHours.Rows.Add(_normalHolidayRow);
                        dgvWorkingHours.Columns[_governmentHoliday.Day - 1].DefaultCellStyle.BackColor = Color.Plum;
                    }
                }
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void UpdateTotalHours()
        {
            try
            {
                int _columns = 0;
                int _rows = 0;
                int _tooManyHours = 0;
                double _result = 0;
                double _sumForDay = 0;
                double _sumForTask = 0;

                // Sum the hours of a day
                _columns = dgvWorkingHours.ColumnCount;
                _rows = dgvWorkingHours.RowCount - 1;

                for (int j = 0; j < _columns; j++)
                {
                    for (int i = 0; i < _rows; i++)
                    {
                        DataGridViewCell cell = dgvWorkingHours.Rows[i].Cells[j];
                        DataGridViewCell _TotalHoursCell = dgvWorkingHours.Rows[_rows].Cells[j];
                        DataGridViewCell _sumCell = dgvWorkingHours.Rows[_rows].Cells[j];

                        if (cell.Value != null)
                        {
                            if (Double.TryParse(cell.Value.ToString(), out _result))
                            {
                                _sumForDay += _result;
                                _TotalHoursCell.Value = _sumForDay;

                                if (_sumForDay >= 25.0)
                                {
                                    _sumCell.Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    _sumCell.Style.ForeColor = Color.Black;
                                }
                            }
                        }

                        if (_TotalHoursCell.Value == null)
                        {
                            _TotalHoursCell.Value = 0;
                        }
                    }
                    _sumForDay = 0;
                }

                // Sum the hours of the task
                _columns = dgvWorkingHours.ColumnCount - 1;
                _rows = dgvWorkingHours.RowCount;
                _tooManyHours = _columns * 24;

                for (int i = 0; i < _rows; i++)
                {
                    for (int j = 0; j < _columns; j++)
                    {
                        DataGridViewCell cell = dgvWorkingHours.Rows[i].Cells[j];
                        DataGridViewCell _TotalHoursCell = dgvWorkingHours.Rows[i].Cells[_columns];
                        DataGridViewCell _sumCell = dgvWorkingHours.Rows[i].Cells[_columns];

                        if (cell.Value != null)
                        {
                            if (Double.TryParse(cell.Value.ToString(), out _result))
                            {
                                _sumForTask += _result;
                                _TotalHoursCell.Value = _sumForTask;

                                if (_sumForTask > _tooManyHours)
                                {
                                    _sumCell.Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    _sumCell.Style.ForeColor = Color.Black;
                                }
                            }
                        }

                        if (_TotalHoursCell.Value == null)
                        {
                            _TotalHoursCell.Value = 0;
                        }
                    }
                    _sumForTask = 0;
                }

                // Total Hours are read only
                dgvWorkingHours.Columns[dgvWorkingHours.ColumnCount - 1].ReadOnly = true;
                dgvWorkingHours.Rows[dgvWorkingHours.RowCount - 1].ReadOnly = true;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void UpdateColorsInWorkingHoursTable()
        {
            int _selectedYear = 0;
            int _selectedMonth = 0;
            int _day = 0;
            int _i = 0;

            Int32.TryParse(cbYearWithMonth.SelectedItem.ToString().Remove(4), out _selectedYear);
            Int32.TryParse(cbYearWithMonth.SelectedItem.ToString().Substring(5), out _selectedMonth);

            foreach (DataGridViewColumn item in dgvWorkingHours.Columns)
            {
                _i++;

                if (_i == dgvWorkingHours.Columns.Count)
                {
                    break;
                }

                Int32.TryParse(item.HeaderText, out _day);

                DateTime _actualDate = new DateTime(_selectedYear, _selectedMonth, _day);

                if (_actualDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    dgvWorkingHours.Columns[item.HeaderText].DefaultCellStyle.BackColor = Color.LightSlateGray;
                    continue;
                }

                if (_actualDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    dgvWorkingHours.Columns[item.HeaderText].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                }
            }

            // Highlight the today in the table with color
            int _todayColumn = DateTime.Today.Day;
            dgvWorkingHours.Columns[_todayColumn - 1].DefaultCellStyle.BackColor = Color.Cornsilk;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int _selectedIndex = cbYearWithMonth.SelectedIndex;
            if (cbYearWithMonth.MaxDropDownItems != (_selectedIndex + 1))
            {
                cbYearWithMonth.SelectedIndex = _selectedIndex + 1;
                UpdateWorkingHoursTable();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int _selectedIndex = cbYearWithMonth.SelectedIndex;
            if (_selectedIndex != 0)
            {
                cbYearWithMonth.SelectedIndex = _selectedIndex - 1;
                UpdateWorkingHoursTable();
            }
        }

        private void cbYearWithMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbYearWithMonth_DropDownClosed(object sender, EventArgs e)
        {
            UpdateWorkingHoursTable();
        }

        private void dgvWorkingHours_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (DataGridViewCell cell in dgvWorkingHours.SelectedCells)
                {
                    cell.Value = cell.DefaultNewRowValue;
                    DataGridViewCell _changedCell = dgvWorkingHours.Rows[cell.RowIndex].Cells[cell.ColumnIndex];
                    if (string.IsNullOrEmpty(_changedCell.ErrorText))
                    {
                        changedCells.Add(_changedCell);
                    }
                }
                e.Handled = true;
                btnSave.Enabled = true;
                return;
            }

            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                foreach (DataGridViewCell cell in dgvWorkingHours.SelectedCells)
                {
                    cell.Value = Clipboard.GetText();
                    DataGridViewCell _changedCell = dgvWorkingHours.Rows[cell.RowIndex].Cells[cell.ColumnIndex];
                    if (string.IsNullOrEmpty(_changedCell.ErrorText))
                    {
                        changedCells.Add(_changedCell);
                    }
                }
                e.Handled = true;
                btnSave.Enabled = true;
                return;
            }

            if (e.KeyCode == Keys.X && e.Modifiers == Keys.Control)
            {
                foreach (DataGridViewCell cell in dgvWorkingHours.SelectedCells)
                {
                    Clipboard.SetText(cell.Value.ToString());
                    cell.Value = cell.DefaultNewRowValue;
                    DataGridViewCell _changedCell = dgvWorkingHours.Rows[cell.RowIndex].Cells[cell.ColumnIndex];
                    if (string.IsNullOrEmpty(_changedCell.ErrorText))
                    {
                        changedCells.Add(_changedCell);
                    }
                }
                e.Handled = true;
                btnSave.Enabled = true;
            }

        }

        private void dgvWorkingHours_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = true;
            DataGridViewCell _changedCell = dgvWorkingHours.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (string.IsNullOrEmpty(_changedCell.ErrorText))
            {
                changedCells.Add(_changedCell);
            }

            UpdateTotalHours();

        }

        private void dgvWorkingHours_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            Double ignored = new Double();

            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                DataGridViewCell cell = dgvWorkingHours.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ErrorText = string.Empty;
                return;
            }
            if (!double.TryParse(e.FormattedValue.ToString(), out ignored))
            {
                DataGridViewCell cell = dgvWorkingHours.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ErrorText = Texts.ErrorMessages.NumbericCell;

            }
            else if (double.Parse(e.FormattedValue.ToString()) > 24.0)
            {
                if (e.ColumnIndex != dgvWorkingHours.ColumnCount - 1 && e.RowIndex != dgvWorkingHours.RowCount - 1)
                {
                    DataGridViewCell cell = dgvWorkingHours.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ErrorText = Texts.ErrorMessages.BiggerThan24Hours;
                }
            }
            else
            {
                DataGridViewCell cell = dgvWorkingHours.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ErrorText = string.Empty;
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (changedCells != null && changedCells.Count != 0)
                {
                    workingHours = new WorkingHours();
                    string _actualCellColumnHeaderValue = string.Empty;
                    string _actualCellRowHeaderValue = string.Empty;
                    string _date = string.Empty;
                    double _actualCellValue = 0;
                    double _resultOfParse = 0;
                    bool _result = false;
                    bool _isSuccess = true;

                    foreach (var cell in changedCells)
                    {
                        _actualCellColumnHeaderValue = dgvWorkingHours.Columns[cell.ColumnIndex].HeaderText;

                        // Get the date from the dropdown list and the column header text
                        _date = cbYearWithMonth.SelectedItem.ToString();
                        _date = _date + "-" + _actualCellColumnHeaderValue;

                        // Get task
                        _actualCellRowHeaderValue = dgvWorkingHours.Rows[cell.RowIndex].HeaderCell.FormattedValue.ToString();

                        if (cell.Value == null || cell.Value.ToString() == "0")
                        {
                            _result = workingHours.RemoveHour(_actualCellRowHeaderValue, _date);
                            continue;
                        }
                        else
                        {
                            if (Double.TryParse(cell.Value.ToString(), out _resultOfParse))
                            {
                                _actualCellValue = Convert.ToDouble(cell.Value);
                            }
                        }

                        _result = workingHours.SaveHour(_actualCellRowHeaderValue, _date, _actualCellValue);

                        _isSuccess &= _result;
                    }

                    UpdateWorkingHoursTable();

                    if (_isSuccess)
                    {
                        MessageBox.Show(Texts.InformationMessages.SuccessfulSave, Texts.Captions.SuccessfulSave, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(Texts.ErrorMessages.ErrorDuringSave, Texts.Captions.ErrorSave, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                btnSave.Enabled = false;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (btnLock.Text == "Unlock")
            {
                btnLock.Text = "Lock";
                btnLock.Image = Properties.Resources.lock_icon_white_32;
                foreach (DataGridViewColumn column in dgvWorkingHours.Columns)
                {
                    column.ReadOnly = false;
                    btnAddRemoveTask.Enabled = true;
                }
            }
            else
            {
                btnLock.Text = "Unlock";
                btnLock.Image = Properties.Resources.unlock_icon_white_32;
                foreach (DataGridViewColumn column in dgvWorkingHours.Columns)
                {
                    column.ReadOnly = true;
                    btnAddRemoveTask.Enabled = false;
                }
            }
        }

        private void btnAddRemoveTask_Click(object sender, EventArgs e)
        {
            cbYearWithMonthValue = cbYearWithMonth.SelectedItem.ToString();

            AddRemoveTaskPage _addRemoveTaskPage = new AddRemoveTaskPage();
            _addRemoveTaskPage.ShowDialog();
            UpdateWorkingHoursTable();
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimalize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                btnMaximize.BackgroundImage = Properties.Resources.restore_icon_white_26;
                dgvWorkingHours.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                Invalidate();
            }
            else
            {
                WindowState = FormWindowState.Normal;
                btnMaximize.BackgroundImage = Properties.Resources.maximize_icon_white_26;
                dgvWorkingHours.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                Invalidate();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LocationInfo._location = this.Location;
            Cursor.Current = Cursors.WaitCursor;
            HomePage _homePage = new HomePage();
            _homePage.Show();
            Hide();
            Cursor.Current = Cursors.Default;
        }



        private void pHeader_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                btnMaximize.BackgroundImage = Properties.Resources.restore_icon_white_26;
                dgvWorkingHours.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                Invalidate();
            }
            else
            {
                WindowState = FormWindowState.Normal;
                btnMaximize.BackgroundImage = Properties.Resources.maximize_icon_white_26;
                dgvWorkingHours.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                Invalidate();
            }
        }

        private void pHeader_MouseUp(object sender, MouseEventArgs e)
        {
            togMove = 0;
        }

        private void pHeader_MouseDown(object sender, MouseEventArgs e)
        {
            togMove = 1;
            mValX = e.X;
            mValY = e.Y;
        }

        private void pHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (togMove == 1)
            {
                SetDesktopLocation(MousePosition.X - mValX, MousePosition.Y - mValY);
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle borderRectangle = new Rectangle(0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            e.Graphics.DrawRectangle(Pens.Black, borderRectangle);
            base.OnPaint(e);
        }
    }
}
