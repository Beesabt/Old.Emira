using emira.BusinessLogicLayer;
using emira.HelperFunctions;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace emira.GUI
{
    public partial class WorkingHoursPage : Form
    {
        int _togMove;
        int _mValX;
        int _mValY;
        WorkingHours _workingHours;
        DataTable _dataTable;

        private void UpdateWorkingHoursTable()
        {
            dgvWorkingHours.Rows.Clear();

            string _actualTaskID = string.Empty;
            string _acutalTaskName = string.Empty;
            int _maxTaskLength = 0;
            int _taskLength = 0;

            _dataTable = new DataTable();
            _workingHours = new WorkingHours();

            _dataTable = _workingHours.GetSelectedTask();

            foreach (DataRow item in _dataTable.Rows)
            {
                _actualTaskID = item[Texts.TaskProperties.TaskID].ToString();
                _acutalTaskName = item[Texts.TaskProperties.TaskName].ToString();

                _taskLength = _actualTaskID.Length + _acutalTaskName.Length;

                if(_maxTaskLength < _taskLength)
                {
                    _maxTaskLength = _taskLength;
                }

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvWorkingHours);
                row.HeaderCell.Value = _actualTaskID + " " + _acutalTaskName;
                dgvWorkingHours.Rows.Add(row);
            }

            // Add 'Summary' row in the end of the rows
            DataGridViewRow sumRow = new DataGridViewRow();
            sumRow.CreateCells(dgvWorkingHours);
            sumRow.HeaderCell.Value = "Total Hours:";
            dgvWorkingHours.Rows.Add(sumRow);

            dgvWorkingHours.RowHeadersWidth = _maxTaskLength + 125;
        }

        public WorkingHoursPage()
        {
            InitializeComponent();
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
                int _columns = 0;
                int _rows = 0;
                string _actualCellColumnHeaderValue = string.Empty;
                string _actualCellRowHeaderValue = string.Empty;
                string _actualCellValue = string.Empty;
                int _actualYear = DateTime.Now.Year;

                DateTime _today = DateTime.UtcNow;
                int _actualDay = (int)_today.DayOfWeek;
                int _numberOfSubstracedDays = 0 - (_actualDay - 1);
                DateTime _monday = _today;
                if (!(_today.DayOfWeek == DayOfWeek.Monday))
                {
                    _monday = _today.AddDays(_numberOfSubstracedDays);
                }

                // Add the days of the actual week
                for (double day = 0; day <= 6; day++)
                {
                    DateTime date = _monday.AddDays(day);

                    DayOfWeek dayofweek = date.DayOfWeek;

                    string ConcatenatedHeaderText = date.ToShortDateString() + "\r\n (" + dayofweek.ToString() + ")";

                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn()
                    {
                        Name = date.ToString(),
                        HeaderText = ConcatenatedHeaderText
                    };
                    dgvWorkingHours.Columns.Add(col);
                }

                // Add 'Summary' column in the end of the columns
                DataGridViewTextBoxColumn sumCol = new DataGridViewTextBoxColumn()
                {
                    Name = "TotalHoursHeader",
                    HeaderText = "Total Hours"
                };
                dgvWorkingHours.Columns.Add(sumCol);

                // Add task from the database as rows
                UpdateWorkingHoursTable();

                // Add hours from Cathalogue
                _columns = dgvWorkingHours.ColumnCount - 1;
                _rows = dgvWorkingHours.RowCount - 1;

                for (int i = 0; i < _rows; i++)
                {
                    for (int j = 0; j < _columns; j++)
                    {
                        DataGridViewCell cell = dgvWorkingHours.Rows[i].Cells[j];
                        DataGridViewRow row = dgvWorkingHours.Rows[i];
                        _workingHours = new WorkingHours();

                        _actualCellColumnHeaderValue = dgvWorkingHours.Columns[j].HeaderText;
                        _actualCellRowHeaderValue = row.HeaderCell.FormattedValue.ToString();

                        _actualCellValue = _workingHours.GetHours(_actualCellRowHeaderValue, _actualCellColumnHeaderValue);

                        if (!string.IsNullOrEmpty(_actualCellValue))
                        {
                            cell.Value = _actualCellValue;
                        }                 
                    }
                }

                //dgvWorkingHours.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
                //dgvWorkingHours.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                //dgvWorkingHours.ColumnHeadersHeight = dgvWorkingHours.ColumnHeadersHeight * 2;
                //dgvWorkingHours.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                string _actualCellColumnHeaderValue = string.Empty;
                string _actualCellRowHeaderValue = string.Empty;
                string _beginOfTheWeekValue = string.Empty;
                string _endOfTheWeekValue = string.Empty;
                double _actualCellValue = 0;

                int _columns = 0;
                int _rows = 0;

                bool _result = false;
                bool _isSuccess = true;

                _workingHours = new WorkingHours();

                _columns = dgvWorkingHours.ColumnCount - 1;
                _rows = dgvWorkingHours.RowCount - 1;

                _beginOfTheWeekValue = dgvWorkingHours.Columns[0].HeaderText;
                _endOfTheWeekValue = dgvWorkingHours.Columns[6].HeaderText;

                _workingHours.DeleteHoursOfTheWeek(_beginOfTheWeekValue, _endOfTheWeekValue);

                for (int i = 0; i < _rows; i++)
                {
                    for (int j = 0; j < _columns; j++)
                    {
                        DataGridViewCell cell = dgvWorkingHours.Rows[i].Cells[j];
                        DataGridViewRow row = dgvWorkingHours.Rows[i];
                        
                        if (!string.IsNullOrEmpty(cell.FormattedValue.ToString().Trim()))
                        {
                            _actualCellColumnHeaderValue = dgvWorkingHours.Columns[j].HeaderText;

                            _actualCellRowHeaderValue = row.HeaderCell.FormattedValue.ToString();

                            double.TryParse(cell.FormattedValue.ToString(), out _actualCellValue);

                            _result = _workingHours.SaveHour(_actualCellRowHeaderValue, _actualCellColumnHeaderValue, _actualCellValue);
                            _isSuccess &= _result;
                        }
                    }

                }

                if (_isSuccess)
                {
                    MessageBox.Show(Texts.InformationMessages.SuccessfulSave, Texts.Captions.SuccessfulSave, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Texts.ErrorMessages.ErrorDuringSave, Texts.Captions.ErrorSave, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception error)
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
                cell.ErrorText = Texts.ErrorMessages.NumericField;

            }
            else if (double.Parse(e.FormattedValue.ToString()) > 24.0)
            {
                DataGridViewCell cell = dgvWorkingHours.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ErrorText = Texts.ErrorMessages.NumericField;
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

    }
}
