using System;
using System.Drawing;
using System.Windows.Forms;

using emira.HelperFunctions;

namespace emira.GUI
{
    public partial class SettingsForm : Form
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        CustomMsgBox customMsgBox;
        bool bTogMove;
        int iValX;
        int iValY;

        public SettingsForm()
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

        private void SettingsPage_Load(object sender, EventArgs e)
        {
            try
            {
                UCpersonalInformation.BringToFront();
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }



        private void btnPersonalInformation_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCpersonalInformation.BringToFront();
            Cursor.Current = Cursors.Default;
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCpasswordChange.BringToFront();
            Cursor.Current = Cursors.Default;
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCusernameChange.BringToFront();
            Cursor.Current = Cursors.Default;
        }

        private void btnTaskManager_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCtaskManager.BringToFront();
            Cursor.Current = Cursors.Default;
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LocationInfo._location = this.Location;
            Cursor.Current = Cursors.WaitCursor;
            HomeForm _homePage = new HomeForm();
            _homePage.Show();
            Hide();
            Cursor.Current = Cursors.Default;
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
