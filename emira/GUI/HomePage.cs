using System;
using System.Drawing;
using System.Windows.Forms;
using emira.HelperFunctions;

namespace emira.GUI
{
    public partial class HomePage : Form
    {
        bool _bTogMove;
        int _iValX;
        int _iValY;

        public HomePage()
        {
            InitializeComponent();
        }

        private void MainPage_Shown(object sender, EventArgs e)
        {
            try
            {
                if (LogInfo.AnnoyingMessage)
                {
                    MessageBox.Show(Texts.ErrorMessages.DefaultEmailOrPassword, Texts.Captions.DefaultLoginParameters, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LogInfo.AnnoyingMessage = false;
                    return;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWorkingHours_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            WorkingHoursPage _workingHoursPage = new WorkingHoursPage();
            _workingHoursPage.Show();
            Hide();
            Cursor.Current = Cursors.Default;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SettingsPage _settingsPage = new SettingsPage();
            _settingsPage.Show();
            Hide();
            Cursor.Current = Cursors.Default;
        }

        private void btnHolidays_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            HolidaysPage _holidaysPage = new HolidaysPage();
            _holidaysPage.Show();
            Hide();
            Cursor.Current = Cursors.Default;

        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            //Hide();
            //StatisticsPage _statisticsPage = new StatisticsPage();
            //_statisticsPage.Show();
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
            _bTogMove = false;
        }

        private void pHeader_MouseDown(object sender, MouseEventArgs e)
        {
            _bTogMove = true;
            _iValX = e.X;
            _iValY = e.Y;
        }

        private void pHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (_bTogMove)
            {
                SetDesktopLocation(MousePosition.X - _iValX, MousePosition.Y - _iValY);
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
