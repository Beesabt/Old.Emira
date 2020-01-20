using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using NLog;
using Nager.Date;
using emira.HelperFunctions;
using emira.BusinessLogicLayer;

namespace emira.GUI
{
    public partial class AddGovernmentHolidaysPage : Form
    {

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        int togMove;
        int mValX;
        int mValY;
        CustomMsgBox customMsgBox;
        AddRemoveGovernmentHoliday governmentHoliday;
        DataTable dataTable;
        BindingSource bindingSource;

        public AddGovernmentHolidaysPage()
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
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
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
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
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

                // Check whether the day is public holiday
                var _publicHolidays = DateSystem.GetPublicHoliday(DateTime.Today.Year, "HU");
                foreach (var publicHoliday in _publicHolidays)
                {
                    if (dtpGovernmentHoliday.Value.ToShortDateString() == publicHoliday.Date.ToShortDateString())
                    {
                        customMsgBox = new CustomMsgBox();
                        customMsgBox.Show(Texts.ErrorMessages.PublicHolidaySelected, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                        return;
                    }
                }

                // Check whether the day does already exist in the DB
                bool _isExist = true;
                _isExist = governmentHoliday.isExist(Texts.DataTableNames.GovernmentHolidays, Texts.GovernmentHolidaysProperties.Date, dtpGovernmentHoliday.Text);
                if (_isExist)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.ErrorDateExist, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    return;
                }

                // Check whether the day does already exist in the holiday table
                _isExist = true;
                _isExist = governmentHoliday.isHoliday(dtpGovernmentHoliday.Text);
                if (_isExist)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.ErrorExistHoliday, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    return;
                }

                // Check whether the day does closed in the WorkingHours otherwise warn the user the hour(s) will be deleted
                _isExist = governmentHoliday.isExist(Texts.DataTableNames.Catalog, Texts.CatalogProperties.Date, dtpGovernmentHoliday.Text);
                if (_isExist)
                {
                    bool _isClosed = true;
                    _isClosed = governmentHoliday.isClosed(dtpGovernmentHoliday.Text);

                    if (_isClosed)
                    {
                        //TODO: error szöveg átírása
                        customMsgBox = new CustomMsgBox();
                        customMsgBox.Show(Texts.ErrorMessages.ErrorDateExist, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                        return;
                    }
                    else
                    {
                        //TODO: error szöveg átírása
                        var _result = MessageBox.Show(Texts.WarningMessages.DeleteTask,
                                           Texts.Captions.LossOfData,
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);
                        if (_result == DialogResult.No)
                        {
                            return;
                        }
                    }
                }

                // Add date
                governmentHoliday.AddHoliday(dtpGovernmentHoliday.Text);

                // Update government holiday table
                UpdateGovernmentHolidayTable();         
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Check the status of the selected date in the WorkingHours:
                //  - if the month is locked then warn the user and do not delete the date
                //  - if the month is unlocked then inform the user and delete the date


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
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
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
