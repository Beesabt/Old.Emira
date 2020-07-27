using System;
using System.Drawing;
using System.Windows.Forms;
using emira.HelperFunctions;

namespace emira.GUI
{
    public partial class HomePage : Form
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        CustomMsgBox customMsgBox;
        bool bTogMove;
        int iValX;
        int iValY;

        public HomePage()
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
                    //customMsgBox.Show(Texts.ErrorMessages.DefaultEmailOrPassword, Texts.Captions.DefaultLoginParameters, CustomMsgBox.MsgBoxIcon.Information, CustomMsgBox.Button.OK);
                    GeneralInfo.AnnoyingMessage = false;
                    return;
                }
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void btnWorkingHours_Click(object sender, EventArgs e)
        {
            LocationInfo._location = this.Location;
            Cursor.Current = Cursors.WaitCursor;
            WorkingHoursPage _workingHoursPage = new WorkingHoursPage();
            _workingHoursPage.Show();
            Hide();
            Cursor.Current = Cursors.Default;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            LocationInfo._location = this.Location;
            Cursor.Current = Cursors.WaitCursor;
            SettingsPage _settingsPage = new SettingsPage();
            _settingsPage.Show();
            Hide();
            Cursor.Current = Cursors.Default;
        }

        private void btnHolidays_Click(object sender, EventArgs e)
        {
            LocationInfo._location = this.Location;
            Cursor.Current = Cursors.WaitCursor;
            HolidaysPage _holidaysPage = new HolidaysPage();
            _holidaysPage.Show();
            Hide();
            Cursor.Current = Cursors.Default;
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            LocationInfo._location = this.Location;
            Cursor.Current = Cursors.WaitCursor;
            StatisticsPage _statisticsPage = new StatisticsPage();
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
