using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Nager.Date;

using emira.BusinessLogicLayer;
using emira.Utilities;

namespace emira.GUI
{
    public partial class AddGovernmentHolidaysForm : Form
    {
        int togMove;
        int mValX;
        int mValY;
        CustomMsgBox customMsgBox;
        AddRemoveGovernmentHoliday governmentHoliday;
        Holiday holiday;
        DataTable dataTable;
        BindingSource bindingSource;

        public AddGovernmentHolidaysForm()
        {
            InitializeComponent();

            governmentHoliday = new AddRemoveGovernmentHoliday();

            // Fill the combox with years
            List<string> _dates = governmentHoliday.GetYears();

            foreach (var item in _dates)
            {
                cbYears.Items.Add(item);
            }
        }

        private void AddGovernmentHolidaysPage_Load(object sender, EventArgs e)
        {
            try
            {
                // Select the actual year in the combobox
                cbYears.SelectedItem = DateTime.Today.Year.ToString();

                // Update the government holiday table
                UpdateGovernmentHolidayTable();
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
            }
        }

        private void cbYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateGovernmentHolidayTable();
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
            }
        }

        private void cbYears_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dgvGovernmentHoliday_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                governmentHoliday = new AddRemoveGovernmentHoliday();
                holiday = new Holiday();

                // Check whether the day is public holiday
                var _publicHolidays = DateSystem.GetPublicHoliday(DateTime.Today.Year, "HU");
                foreach (var publicHoliday in _publicHolidays)
                {
                    if (dtpGovernmentHoliday.Value.ToShortDateString() == publicHoliday.Date.ToShortDateString())
                    {
                        customMsgBox = new CustomMsgBox();
                        customMsgBox.ShowError(Texts.ErrorMessages.PublicHolidaySelected, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error);
                        return;
                    }
                }

                // Check whether the day does already exist in the DB
                bool _isExist = true;
                _isExist = holiday.isExist(Texts.DataTableNames.GovernmentHolidays, Texts.GovernmentHolidaysProperties.Date, dtpGovernmentHoliday.Text);
                if (_isExist)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(Texts.ErrorMessages.ErrorDateExist, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error);
                    return;
                }

                // Check whether the day does already exist in the holiday table
                _isExist = true;
                _isExist = governmentHoliday.isHoliday(dtpGovernmentHoliday.Text);
                if (_isExist)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(Texts.ErrorMessages.ErrorExistHoliday, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error);
                    return;
                }

                // Check whether the day does closed in the WorkingHours
                bool _isClosed = true;
                DateTime _selectedDate;
                DateTime.TryParse(dtpGovernmentHoliday.Text, out _selectedDate);
                _isClosed = holiday.isClosed(_selectedDate.ToString("yyyy-MM"));

                if (_isClosed)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(Texts.ErrorMessages.ErrorLockedHoliday, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error);
                    return;
                }

                // Add date
                governmentHoliday.AddHoliday(dtpGovernmentHoliday.Text);

                // Update government holiday table
                UpdateGovernmentHolidayTable();
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool _isSuccess = false;

                // Check the status of the selected date in the WorkingHours:
                // if the month is locked then warn the user and do not delete the date

                holiday = new Holiday();
                bool _cellValue;
                DateTime _selectedDate = DateTime.Today;

                for (int i = 0; i < dgvGovernmentHoliday.Rows.Count; i++)
                {
                    Boolean.TryParse(dgvGovernmentHoliday.Rows[i].Cells[0].Value.ToString(), out _cellValue);
                    if (_cellValue)
                    {
                        _selectedDate = (DateTime)dgvGovernmentHoliday.Rows[i].Cells[1].Value;
                        break;
                    }
                }

                // Check whether the day does closed in the WorkingHours
                bool _isClosed = true;
                _isClosed = holiday.isClosed(_selectedDate.ToString("yyyy-MM"));

                if (_isClosed)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(Texts.ErrorMessages.ErrorLockedHoliday, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error);
                    return;
                }

                // Delete date
                _isSuccess = governmentHoliday.DeleteHoliday(_selectedDate.ToString("yyyy-MM-dd"));

                if (_isSuccess)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(Texts.InformationMessages.SuccessfulLocked, Texts.Captions.Information, CustomMsgBox.MsgBoxIcon.Information);
                }
                else
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(Texts.ErrorMessages.ErrorDuringCancellation, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error);
                }

                // Update government holiday table
                UpdateGovernmentHolidayTable();
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateGovernmentHolidayTable()
        {
            try
            {
                // Fill the data grid view with the datas of government holiday table
                governmentHoliday = new AddRemoveGovernmentHoliday();
                dataTable = new DataTable();

                if (string.IsNullOrEmpty(cbYears.Text))
                {
                    dataTable = governmentHoliday.GetHolidaysTable(DateTime.Today.Year.ToString());
                }
                else
                {
                    dataTable = governmentHoliday.GetHolidaysTable(cbYears.SelectedItem.ToString());
                }

                // Set the checkbox state according the state of the holiday
                bindingSource = new BindingSource();
                bindingSource.Clear();
                bindingSource.DataSource = dataTable;
                dgvGovernmentHoliday.DataSource = bindingSource;

                // Sorting is disabled
                foreach (DataGridViewColumn column in dgvGovernmentHoliday.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
            }
        }

        private void dgvGovernmentHoliday_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check the checkbox colum is clicked
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                // Uncheck other checkboxes
                foreach (DataGridViewRow row in dgvGovernmentHoliday.Rows)
                {
                    if (row.Index == e.RowIndex)
                    {
                        row.Cells[0].Value = !Convert.ToBoolean(row.Cells[0].EditedFormattedValue);
                    }
                    else
                    {
                        row.Cells[0].Value = false;
                    }
                }
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
            Color _Win10BlueBorderColor = new Color();
            _Win10BlueBorderColor = Color.FromArgb(24, 116, 188);
            e.Graphics.DrawRectangle(new Pen(_Win10BlueBorderColor), borderRectangle);
            base.OnPaint(e);
        }
        
    }
}
