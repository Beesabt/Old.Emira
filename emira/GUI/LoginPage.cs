using System;
using System.Drawing;
using System.Windows.Forms;
using emira.BusinessLogicLayer;
using emira.HelperFunctions;

namespace emira.GUI
{
    partial class LoginPage : Form
    {
        bool _bTogMove;
        int _iValX;
        int _iValY;
        Login _login;
        HomeForm _homePage;
        CustomMsgBox _msgBox;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            tbEmail.Select();
            btnLogin.Focus();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbEmail.Text))
                {
                    _msgBox = new CustomMsgBox();
                    _msgBox.Show(lEmail.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Warning);                  
                    return;
                }

                if (string.IsNullOrEmpty(tbPassword.Text))
                {
                    _msgBox = new CustomMsgBox();
                    _msgBox.Show(lPassword.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Warning);                   
                    return;
                }

                _login = new Login();

                if (!_login.LoginValidation(tbEmail.Text, tbPassword.Text))
                {
                    _msgBox = new CustomMsgBox();
                    //_msgBox.Show(Texts.ErrorMessages.WrongEmailPassword, Texts.Captions.LoginFailed, CustomMsgBox.MsgBoxIcon.Error);
                    tbPassword.Text = string.Empty;
                    tbEmail.Text = string.Empty;
                    return;
                }

                // Save the e-mail address for identification
                GeneralInfo.DefaultEmail = tbEmail.Text;

                // Wait until everything is loaded
                Cursor.Current = Cursors.WaitCursor;
                _homePage = new HomeForm();
                _homePage.Show();
                Hide();
                Cursor.Current = Cursors.Default;           
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
