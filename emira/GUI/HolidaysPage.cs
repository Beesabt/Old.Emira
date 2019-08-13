using emira.HelperFunctions;
using emira.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace emira.GUI
{
    public partial class HolidaysPage : Form
    {

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        int _togMove;
        int _mValX;
        int _mValY;
        Holiday _holiday;
        DataTable _dataTable;
        BindingSource _bindingSource;
        CustomMsgBox _customMsgBox;

        public HolidaysPage()
        {
            InitializeComponent();
        }

        private void HolidaysPage_Load(object sender, EventArgs e)
        {
            // Parameters
            _holiday = new Holiday();
            DateTime today = DateTime.Today;
            int actualYear = today.Year;

            try
            {
                // Fill the combobox               
                List<string> years = new List<string>();
                years = _holiday.GetYears();
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


                // Set the national holidays in the date time pickers
                // TODO Implement

                UpdateHolidayTable();
            }
            catch (Exception error)
            {
                Logger.Error(error);
                _customMsgBox = new CustomMsgBox();
                _customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        public void UpdateHolidayTable()
        {
            // Parameters
            _holiday = new Holiday();
            DateTime today = DateTime.Today;
            int actualYear = today.Year;

            try
            {
                // Fill the data grid view with the datas of Holiday table
                _holiday = new Holiday();
                _dataTable = new DataTable();
                bool _state = false;

                if (string.IsNullOrEmpty(cbYears.Text))
                {
                    _dataTable = _holiday.GetHolidaysTable(actualYear.ToString(), cbState.SelectedItem.ToString());
                }
                else
                {
                    _dataTable = _holiday.GetHolidaysTable(cbYears.SelectedItem.ToString(), cbState.SelectedItem.ToString());
                }


                // Set the checkbox state according the state of the holiday
                _bindingSource = new BindingSource();
                _bindingSource.Clear();
                _bindingSource.DataSource = _dataTable;
                dgvHolidays.DataSource = _bindingSource;

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

            }
            catch (Exception error)
            {
                Logger.Error(error);
                _customMsgBox = new CustomMsgBox();
                _customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }

            try
            {
                // Set Frame and Selected numbers
                int _remainingDays = _holiday.GetRemainingDaysForActualYear();
                lFrameDays.Text = _remainingDays.ToString();
                lSelectedDays.Text = "0";


                // Set the holiday information
                lAnnualOpeningFrameDays.Text = _holiday.CountHolidays().ToString();
                lAppliedDays.Text = _holiday.GetUsedHolidays(actualYear).ToString();
                lPredictableDays.Text = lFrameDays.Text;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                _customMsgBox = new CustomMsgBox();
                _customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
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
                _customMsgBox = new CustomMsgBox();
                _customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
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
                _customMsgBox = new CustomMsgBox();
                _customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                lErrorMessage.Text = string.Empty;
                int actualYear = DateTime.Today.Year;
                DateTime from = dtpFrom.Value;
                DateTime to = dtpTo.Value;
                to = to.AddHours(24.0);
                _holiday = new Holiday();

                if (to < from)
                {
                    lErrorMessage.Text = Texts.ErrorMessages.SmallerEndDate;
                    return;
                }

                if (from.Year > actualYear || from.Year < actualYear)
                {
                    lErrorMessage.Text = Texts.ErrorMessages.StartDayInActualYear;
                    return;
                }

                double _NumberOfSelectedDays = to.Subtract(from).Days;
                lSelectedDays.Text = _NumberOfSelectedDays.ToString();
                int _remainingDays = _holiday.GetRemainingDaysForActualYear();

                if (_remainingDays < _NumberOfSelectedDays)
                {
                    lErrorMessage.Text = Texts.ErrorMessages.TooFewRemainingDays;
                    return;
                }

                List<string> _conflictedIDs = new List<string>();
                _conflictedIDs = _holiday.ChooseDateValidation(from, to);
                StringBuilder sb = new StringBuilder();
                sb.Append(Texts.ErrorMessages.ConflictIDs);
                if (_conflictedIDs.Count != 0)
                {
                    foreach (var item in _conflictedIDs)
                    {
                        sb.Append(item);
                        if (_conflictedIDs.Last() != item)
                        {
                            sb.Append(", ");
                        }
                    }
                    lErrorMessage.Text = sb.ToString();
                    return;
                }

                btnCheck.Hide();
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
                btnCancel.Show();
                btnAdd.Show();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime from = dtpFrom.Value;
                DateTime to = dtpTo.Value;
                int actualYear = DateTime.Today.Year;
                _holiday = new Holiday();
                _holiday.AddNewHoliday(from, to);
                //UpdateHolidayTable(actualYear.ToString());
                btnCancel.Hide();
                btnAdd.Hide();
                btnCheck.Show();
                lFrameDays.Text = _holiday.GetRemainingDaysForActualYear().ToString();
                lAppliedDays.Text = _holiday.GetUsedHolidays(actualYear).ToString();
                lPredictableDays.Text = lFrameDays.Text;
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                btnCancel.Hide();
                btnAdd.Hide();
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
                btnCheck.Show();

                lSelectedDays.Text = "0";
                lErrorMessage.Text = String.Empty;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancellation_Click(object sender, EventArgs e)
        {
            try
            {
                int actualYear = DateTime.Today.Year;
                foreach (DataGridViewRow actualRow in dgvHolidays.SelectedRows)
                {
                    string _ID = actualRow.Cells[1].Value.ToString();
                    _holiday = new Holiday();
                    _holiday.DeleteHoliday(_ID);
                }
                //UpdateHolidayTable(actualYear.ToString());
                lFrameDays.Text = _holiday.GetRemainingDaysForActualYear().ToString();
                lAppliedDays.Text = _holiday.GetUsedHolidays(actualYear).ToString();
                lPredictableDays.Text = lFrameDays.Text;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHolidays_Sorted(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvHolidays.RowCount; i++)
                {
                    if (!Convert.ToBoolean(dgvHolidays.Rows[i].Cells[4].Value.ToString()))
                    {
                        dgvHolidays.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(239, 154, 154);
                        DataGridViewCell cell = dgvHolidays.Rows[i].Cells[0];
                        DataGridViewCheckBoxCell chkCell = cell as DataGridViewCheckBoxCell;
                        chkCell.FlatStyle = FlatStyle.Flat;
                        chkCell.Value = false;
                        cell.ReadOnly = true;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Hide();
            HomePage HP = new HomePage();
            HP.Show();
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
