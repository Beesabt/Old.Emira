using emira.HelperFunctions;
using emira.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Nager.Date;

namespace emira.GUI
{
    public partial class HolidaysPage : Form
    {

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        int togMove;
        int mValX;
        int mValY;
        Holiday holiday;
        DataTable dataTable;
        BindingSource bindingSource;
        CustomMsgBox customMsgBox;

        public HolidaysPage()
        {
            InitializeComponent();

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
        }

        private void HolidaysPage_Load(object sender, EventArgs e)
        {
            // Parameters
            holiday = new Holiday();
            DateTime today = DateTime.Today;
            int actualYear = today.Year;

            try
            {
                // Fill the combobox               
                List<string> years = new List<string>();
                years = holiday.GetYears();
                years.Reverse();
                foreach (var item in years)
                {
                    cbYears.Items.Add(item);
                }

                cbYears.SelectedItem = years.First();

                // Determine the day of the date time pickers
                DayOfWeek day = today.DayOfWeek;
                switch (day)
                {
                    case DayOfWeek.Saturday:
                        dtpFrom.Value = today.AddDays(2);
                        dtpTo.Value = today.AddDays(2);
                        break;
                    case DayOfWeek.Sunday:
                        dtpFrom.Value = today.AddDays(1);
                        dtpTo.Value = today.AddDays(1);
                        break;
                    default:
                        dtpFrom.Value = today;
                        dtpTo.Value = today;
                        break;
                }

                UpdateHolidayTable();
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        public void UpdateHolidayTable()
        {
            holiday = new Holiday();
            DateTime today = DateTime.Today;
            int actualYear = today.Year;

            try
            {
                // Fill the data grid view with the datas of Holiday table
                holiday = new Holiday();
                dataTable = new DataTable();
                bool _state = false;

                if (string.IsNullOrEmpty(cbYears.Text))
                {
                    dataTable = holiday.GetHolidaysTable(actualYear.ToString(), cbState.SelectedItem.ToString());
                }
                else
                {
                    dataTable = holiday.GetHolidaysTable(cbYears.SelectedItem.ToString(), cbState.SelectedItem.ToString());
                }

                // Set the checkbox state according the state of the holiday
                bindingSource = new BindingSource();
                bindingSource.Clear();
                bindingSource.DataSource = dataTable;
                dgvHolidays.DataSource = bindingSource;

                for (int i = 0; i < dgvHolidays.RowCount; i++)
                {
                    if (Boolean.TryParse(dgvHolidays.Rows[i].Cells[0].Value.ToString(), out _state))
                    {
                        DataGridViewCell cell = dgvHolidays.Rows[i].Cells[0];
                        cell.Value = false;

                        if (!_state)
                        {
                            cell.ReadOnly = true;
                        }
                    }
                }

                // Sorting is disabled and columns are read only
                foreach (DataGridViewColumn column in dgvHolidays.Columns)
                {
                    if (column.Name != "Select")
                    {
                        column.ReadOnly = true;
                    }
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                // Rename the columns headerText
                dgvHolidays.Columns[1].HeaderText = Texts.HolidayProperties.ID;
                dgvHolidays.Columns[2].HeaderText = Texts.HolidayProperties.StartDateHeaderText;
                dgvHolidays.Columns[3].HeaderText = Texts.HolidayProperties.EndDateHeaderText;
                dgvHolidays.Columns[5].HeaderText = Texts.HolidayProperties.Status;

            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }

            try
            {
                // Set the numbers for Frame and Selected
                lFrameDays.Text = holiday.GetRemainingDaysForActualYear().ToString();
                lSelectedDays.Text = "0";

                // Set the holiday information
                lAnnualOpeningFrameDays.Text = holiday.CountHolidays().ToString();
                lAppliedDays.Text = holiday.GetUsedHolidays(actualYear).ToString();
                lPredictableDays.Text = lFrameDays.Text;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void cbYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateHolidayTable();
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void cbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateHolidayTable();
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void cbYears_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbState_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dgvHolidays_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                lErrorMessage.Text = string.Empty;
                DateTime _fromDate = dtpFrom.Value;
                DateTime _toDate = dtpTo.Value;
                string _sToDate = dtpTo.Text;
                string _sFromDate = dtpFrom.Text;
                int _actualYear = DateTime.Today.Year;
                _toDate = _toDate.AddHours(24.0);
                int _numberOfSelectedDays = _toDate.Subtract(_fromDate).Days;
                int _remainingDays = 0;
                holiday = new Holiday();

                // Error if the end date is smaller the the start date
                if (_toDate < _fromDate)
                {
                    lErrorMessage.Text = Texts.ErrorMessages.SmallerEndDate;
                    return;
                }

                // Error if the start date year is in the past or the future year
                if (_fromDate.Year > _actualYear || _fromDate.Year < _actualYear)
                {
                    lErrorMessage.Text = Texts.ErrorMessages.StartDayInActualYear;
                    return;
                }

                // Error if the selected start or end date is public holiday
                var _publicHolidays = DateSystem.GetPublicHoliday(_actualYear, "HU");
                foreach (var publicHoliday in _publicHolidays)
                {
                    if (_fromDate == publicHoliday.Date || _toDate == publicHoliday.Date)
                    {
                        lErrorMessage.Text = Texts.ErrorMessages.PublicHoliday;
                        return;
                    }
                }

                // Error if the selected holiday period include public holiday
                DateTime _day = new DateTime();

                for (int i = 1; i < _numberOfSelectedDays; i++)
                {
                    _day = _fromDate.AddDays(i);

                    foreach (var publicHoliday in _publicHolidays)
                    {
                        if (_day == publicHoliday.Date)
                        {
                            lErrorMessage.Text = Texts.ErrorMessages.PublicHolidayIncluded;
                            return;
                        }
                    }
                }

                // Error if the user does not have enough remaining days
                Int32.TryParse(lPredictableDays.Text, out _remainingDays);

                if (_remainingDays < _numberOfSelectedDays)
                {
                    lErrorMessage.Text = Texts.ErrorMessages.TooFewRemainingDays;
                    return;
                }

                // Error if the selected period is already approved
                List<string> _conflictedIDs = new List<string>();
                _conflictedIDs = holiday.ChooseDateValidation(_sFromDate, _sToDate);
                StringBuilder _sb = new StringBuilder();
                _sb.Append(Texts.ErrorMessages.ConflictIDs);
                if (_conflictedIDs.Count != 0)
                {
                    foreach (var item in _conflictedIDs)
                    {
                        _sb.Append(item);
                        if (_conflictedIDs.Last() != item)
                        {
                            _sb.Append(", ");
                        }
                    }
                    lErrorMessage.Text = _sb.ToString();
                    return;
                }

                lSelectedDays.Text = _numberOfSelectedDays.ToString();

                // Hide check button
                btnCheck.Hide();

                // Make the dateTimePikers readonly
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;

                // Show the Add and Cancel buttons
                btnAdd.Show();
                btnCancel.Show();
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool _isSuccess = true;

                // Add the selected holiday period
                string _from = dtpFrom.Text;
                string _to = dtpTo.Text;
                holiday = new Holiday();
                _isSuccess = holiday.AddNewHoliday(_from, _to);

                if (!_isSuccess)
                {
                    Logger.Error(Texts.ErrorMessages.ErrorDuringSave);
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.ErrorDuringSave, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    return;
                }

                // Update the holiday table
                UpdateHolidayTable();

                // Hide the Cancel and Add buttons 
                btnAdd.Hide();
                btnCancel.Hide();

                // Show the Check button
                btnCheck.Show();

                // Update the remaining days
                lFrameDays.Text = holiday.GetRemainingDaysForActualYear().ToString();

                // Enable the dateTimePikers
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                // Hide Add and Cancel buttons
                btnCancel.Hide();
                btnAdd.Hide();

                // Enable the dateTimePikers
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;

                // Show the Check button
                btnCheck.Show();

                // Clear the labels
                lSelectedDays.Text = "0";
                lErrorMessage.Text = string.Empty;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void btnCancellation_Click(object sender, EventArgs e)
        {
            try
            {
                bool _isSuccess = true;

                // Delete the selected holiday(s)
                foreach (DataGridViewRow actualRow in dgvHolidays.SelectedRows)
                {
                    string _startDate = actualRow.Cells[2].Value.ToString();
                    string _endDate = actualRow.Cells[3].Value.ToString();
                    holiday = new Holiday();
                    _isSuccess = holiday.DeleteHoliday(_startDate, _endDate);
                    _isSuccess &= _isSuccess;
                }

                if (!_isSuccess)
                {
                    Logger.Error(Texts.ErrorMessages.ErrorDuringCancellation);
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.ErrorDuringCancellation, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    return;
                }

                // Update the holiday table
                UpdateHolidayTable();
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpTo.Value = dtpFrom.Value;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimalized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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
