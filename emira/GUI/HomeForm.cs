using System;
using System.Drawing;
using System.Windows.Forms;

using emira.Utilities;

namespace emira.GUI
{
    public partial class HomeForm : Form
    {
        CustomMsgBox customMsgBox;
        bool bTogMove;
        int iValX;
        int iValY;

        public HomeForm()
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

        private void MainPage_Shown(object sender, EventArgs e)
        {
            try
            {
                if (GeneralInfo.AnnoyingMessage)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.InformationMessages.DefaultEmailOrPassword, Texts.Captions.DefaultLoginParameters, CustomMsgBox.MsgBoxIcon.Information, CustomMsgBox.Button.OK);
                    return;
                }
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
            }
        }

        private void btnWorkingHours_Click(object sender, EventArgs e)
        {
            LocationInfo._location = this.Location;
            Cursor.Current = Cursors.WaitCursor;
            WorkingHoursForm _workingHoursPage = new WorkingHoursForm();
            _workingHoursPage.Show();
            Hide();
            Cursor.Current = Cursors.Default;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            LocationInfo._location = this.Location;
            Cursor.Current = Cursors.WaitCursor;
            SettingsForm _settingsPage = new SettingsForm();
            _settingsPage.Show();
            Hide();
            Cursor.Current = Cursors.Default;
        }

        private void btnHolidays_Click(object sender, EventArgs e)
        {
            LocationInfo._location = this.Location;
            Cursor.Current = Cursors.WaitCursor;
            HolidaysForm _holidaysPage = new HolidaysForm();
            _holidaysPage.Show();
            Hide();
            Cursor.Current = Cursors.Default;
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            LocationInfo._location = this.Location;
            Cursor.Current = Cursors.WaitCursor;
            StatisticsForm _statisticsPage = new StatisticsForm();
            _statisticsPage.Show();
            Hide();
            Cursor.Current = Cursors.Default;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimalize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pHeader_MouseUp(object sender, MouseEventArgs e)
        {
            bTogMove = false;
        }

        private void pHeader_MouseDown(object sender, MouseEventArgs e)
        {
            bTogMove = true;
            iValX = e.X;
            iValY = e.Y;
        }

        private void pHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (bTogMove)
            {
                SetDesktopLocation(MousePosition.X - iValX, MousePosition.Y - iValY);
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
