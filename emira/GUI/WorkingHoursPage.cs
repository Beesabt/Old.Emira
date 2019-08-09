﻿using emira.BusinessLogicLayer;
using emira.HelperFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace emira.GUI
{
    public partial class WorkingHoursPage : Form
    {
        int _togMove;
        int _mValX;
        int _mValY;
        int _monthLength = 0;
        string _day = string.Empty;
        WorkingHours _workingHours;
        DataTable _dataTable;
        List<DataGridViewCell> _changedCells = new List<DataGridViewCell>();

        private void UpdateWorkingHoursTable()
        {
            // Clean all modifications
            dgvWorkingHours.Columns.Clear();
            dgvWorkingHours.Rows.Clear();
            _changedCells.Clear();

            int _maxTaskLength = 0;
            int _taskLength = 0;
            int _columns = 0;
            int _rows = 0;
            int _resultMonth = 0;
            int _resultYear = 0;
            string _actualTaskID = string.Empty;
            string _acutalTaskName = string.Empty;
            string _actualCellColumnHeaderValue = string.Empty;
            string _actualCellRowHeaderValue = string.Empty;
            string _actualCellValue = string.Empty;
            string _date = string.Empty;

            DateTime _today = DateTime.UtcNow;
            _dataTable = new DataTable();
            _workingHours = new WorkingHours();

            // Give the name of the month to the table
            string _selectedYear = cbYearWithMonth.SelectedItem.ToString().Remove(4);
            string _selectedMonth = cbYearWithMonth.SelectedItem.ToString().Substring(5);

            Int32.TryParse(_selectedYear, out _resultYear);

            if (Int32.TryParse(_selectedMonth, out _resultMonth))
            {
                CultureInfo ci = new CultureInfo("en-US");
                lMonth.Text = ci.DateTimeFormat.GetMonthName(_resultMonth);
            }
            else
            {
                lMonth.Text = "Month";
            }

            // Lenght of the actual month + 1
            _monthLength = _workingHours.GetDaysOfMonth(_resultYear, _resultMonth);

            // Add the days of the actual month
            for (int i = 1; i < _monthLength + 1; i++)
            {
                if (i < 10)
                {
                    _day = "0" + i.ToString();
                }
                else
                {
                    _day = i.ToString();
                }

                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn()
                {
                    Name = _day,
                    HeaderText = _day
                };
                dgvWorkingHours.Columns.Add(col);
            }

            // Add 'Summary' column in the end of the columns
            DataGridViewTextBoxColumn sumCol = new DataGridViewTextBoxColumn()
            {
                Name = "TotalHoursHeader",
                HeaderText = "Total"
            };
            dgvWorkingHours.Columns.Add(sumCol);

            // Get selected tasks and fill the header row with it/them
            // And if we choose a prevous monnth or a future months then the AddRemoveTask button is disabled
            // and we can not edit the values
            if (_today.Month != _resultMonth)
            {

                _dataTable = _workingHours.GetTasksByMonth(cbYearWithMonth.SelectedItem.ToString());

                foreach (DataRow item in _dataTable.Rows)
                {
                    _actualTaskID = item[Texts.TaskProperties.TaskID].ToString();
                    _acutalTaskName = item[Texts.TaskProperties.TaskName].ToString();


                    _taskLength = _actualTaskID.Length + _acutalTaskName.Length;

                    if (_maxTaskLength < _taskLength)
                    {
                        _maxTaskLength = _taskLength;
                    }

                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvWorkingHours);
                    row.HeaderCell.Value = _actualTaskID + " " + _acutalTaskName;
                    dgvWorkingHours.Rows.Add(row);
                }

                // AddRemoveTask button is disabled
                btnAddRemoveTask.Enabled = false;

                // Sorting is disabled and columns are read only
                foreach (DataGridViewColumn column in dgvWorkingHours.Columns)
                {
                    column.ReadOnly = true;
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

            }
            else
            {
                _dataTable = _workingHours.GetSelectedTask();

                foreach (DataRow item in _dataTable.Rows)
                {
                    _actualTaskID = item[Texts.TaskProperties.TaskID].ToString();
                    _acutalTaskName = item[Texts.TaskProperties.TaskName].ToString();

                    _taskLength = _actualTaskID.Length + _acutalTaskName.Length;

                    if (_maxTaskLength < _taskLength)
                    {
                        _maxTaskLength = _taskLength;
                    }

                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvWorkingHours);
                    row.HeaderCell.Value = _actualTaskID + " " + _acutalTaskName;
                    dgvWorkingHours.Rows.Add(row);
                }

                // AddRemoveTask button is enabled
                btnAddRemoveTask.Enabled = true;

                // Sorting is disabled and columns are editable
                foreach (DataGridViewColumn column in dgvWorkingHours.Columns)
                {
                    column.ReadOnly = false;
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                // Highlight the today in the table with color
                int _todayColumn = _today.Day;
                dgvWorkingHours.Columns[_todayColumn - 1].DefaultCellStyle.BackColor = Color.Cornsilk;
            }

            // Set the 'Task' column's width
            dgvWorkingHours.RowHeadersWidth = _maxTaskLength + 125;
            dgvWorkingHours.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Add 'Summary' row in the end of the rows
            DataGridViewRow sumRow = new DataGridViewRow();
            sumRow.CreateCells(dgvWorkingHours);
            sumRow.HeaderCell.Value = "Total hours:";
            dgvWorkingHours.Rows.Add(sumRow);

            // Add hours from Cathalogue
            _columns = dgvWorkingHours.ColumnCount - 1;
            _rows = dgvWorkingHours.RowCount - 1;

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    DataGridViewCell cell = dgvWorkingHours.Rows[i].Cells[j];
                    DataGridViewRow row = dgvWorkingHours.Rows[i];

                    _actualCellColumnHeaderValue = dgvWorkingHours.Columns[j].HeaderText;

                    _date = cbYearWithMonth.SelectedItem.ToString();

                    _date = _date + "-" + _actualCellColumnHeaderValue;

                    _actualCellRowHeaderValue = row.HeaderCell.FormattedValue.ToString();

                    _actualCellValue = _workingHours.GetHours(_actualCellRowHeaderValue, _date);

                    if (!string.IsNullOrEmpty(_actualCellValue))
                    {
                        cell.Value = _actualCellValue;
                    }
                }
            }

            UpdateTotalHours();          
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
                                _sumForDay += Convert.ToDouble(cell.Value);
                                _TotalHoursCell.Value = _sumForDay;

                                if (_sumForDay >= 25.0)
                                {
                                    _sumCell.Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    _sumCell.Style.BackColor = Color.White;
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
                                _sumForTask += Convert.ToDouble(cell.Value);
                                _TotalHoursCell.Value = _sumForTask;

                                if (_sumForTask > _tooManyHours)
                                {
                                    _sumCell.Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    _sumCell.Style.BackColor = Color.White;
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
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public WorkingHoursPage()
        {
            InitializeComponent();

            WorkingHours _workingHours = new WorkingHours();
            // Fill the combox with months from DB
            List<string> Dates = _workingHours.GetYearsAndMonths();

            foreach (var item in Dates)
            {
                cbYearWithMonth.Items.Add(item);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimalize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Hide();
            HomePage _homePage = new HomePage();
            _homePage.Show();
        }

        private void WorkingHours_Load(object sender, EventArgs e)
        {
            try
            {
                WorkingHours _workingHours = new WorkingHours();

                // Select the actual month in the combobox
                cbYearWithMonth.SelectedItem = _workingHours.GetActualMonth();

                UpdateWorkingHoursTable();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddRemoveTask_Click(object sender, EventArgs e)
        {
            AddRemoveTaskPage adtp = new AddRemoveTaskPage();
            adtp.ShowDialog();
            UpdateWorkingHoursTable();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_changedCells != null && _changedCells.Count != 0)
                {
                    _workingHours = new WorkingHours();
                    string _actualCellColumnHeaderValue = string.Empty;
                    string _actualCellRowHeaderValue = string.Empty;
                    string _date = string.Empty;
                    double _actualCellValue = 0;
                    double _resultOfParse = 0;
                    bool _result = false;
                    bool _isSuccess = true;

                    foreach (var cell in _changedCells)
                    {
                        _actualCellColumnHeaderValue = dgvWorkingHours.Columns[cell.ColumnIndex].HeaderText;

                        // Get the date from the dropdown list and the column header text
                        _date = cbYearWithMonth.SelectedItem.ToString();
                        _date = _date + "-" + _actualCellColumnHeaderValue;

                        // Get task
                        _actualCellRowHeaderValue = dgvWorkingHours.Rows[cell.RowIndex].HeaderCell.FormattedValue.ToString();

                        if (cell.Value == null || cell.Value.ToString() == "0")
                        {
                            _result = _workingHours.RemoveHour(_actualCellRowHeaderValue, _date);
                            continue;
                        }
                        else
                        {
                            if (Double.TryParse(cell.Value.ToString(), out _resultOfParse))
                            {
                                _actualCellValue = Convert.ToDouble(cell.Value);
                            }
                        }

                        _result = _workingHours.SaveHour(_actualCellRowHeaderValue, _date, _actualCellValue);

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

        private void pHeader_MouseUp(object sender, MouseEventArgs e)
        {
            _togMove = 0;
        }

        private void pHeader_MouseDown(object sender, MouseEventArgs e)
        {
            _togMove = 1;
            _mValX = e.X;
            _mValY = e.Y;
        }

        private void pHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (_togMove == 1)
            {
                SetDesktopLocation(MousePosition.X - _mValX, MousePosition.Y - _mValY);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                dgvWorkingHours.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                Invalidate();
            }
            else
            {
                WindowState = FormWindowState.Normal;
                dgvWorkingHours.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                Invalidate();
            }
        }

        private void dgvWorkingHours_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = true;
            DataGridViewCell _changedCell = dgvWorkingHours.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (string.IsNullOrEmpty(_changedCell.ErrorText))
            {
                _changedCells.Add(_changedCell);
            }

            UpdateTotalHours();

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
                        _changedCells.Add(_changedCell);
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
                        _changedCells.Add(_changedCell);
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
                        _changedCells.Add(_changedCell);
                    }
                }
                e.Handled = true;
                btnSave.Enabled = true;
                return;
            }

        }

        private void cbYearWithMonth_DropDownClosed(object sender, EventArgs e)
        {
            UpdateWorkingHoursTable();
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
    }
}
