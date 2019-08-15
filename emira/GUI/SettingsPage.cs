using System;
using System.Drawing;
using System.Windows.Forms;

namespace emira.GUI
{
    public partial class SettingsPage : Form
    {
        bool _bTogMove;
        int _iValX;
        int _iValY;

        public SettingsPage()
        {
            InitializeComponent();
        }

        private void SettingsPage_Load(object sender, EventArgs e)
        {
            try
            {
                UCpersonalInformation.BringToFront();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Hide();
            HomePage _homePage = new HomePage();
            _homePage.Show();
        }

        private void btnPersonalInformation_Click(object sender, EventArgs e)
        {
            UCpersonalInformation.BringToFront();
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            UCpasswordChange.BringToFront();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            UCusernameChange.BringToFront();
        }

        private void btnTaskManager_Click(object sender, EventArgs e)
        {
            UCtaskManager.BringToFront();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
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
