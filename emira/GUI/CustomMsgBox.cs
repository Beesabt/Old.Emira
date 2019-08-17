using System;
using System.Drawing;
using System.Windows.Forms;

namespace emira.GUI
{
    public partial class CustomMsgBox : Form
    {
        bool bTogMove;
        int iValX;
        int iValY;
        static CustomMsgBox MsgBox;

        public CustomMsgBox()
        {
            InitializeComponent();
        }

        public DialogResult Show(string text, string caption, MsgBoxIcon icon)
        {
            DialogResult dlgResult = DialogResult.None;
            MsgBox = new CustomMsgBox();
            MsgBox.lCaption.Text = caption;
            MsgBox.lblMessage.Text = text;
            switch (icon)
            {
                case MsgBoxIcon.Information:
                    MsgBox.pbIcon.BackgroundImage = Properties.Resources.info_icon_color_48;
                    break;
                case MsgBoxIcon.Warning:
                    MsgBox.pbIcon.BackgroundImage = Properties.Resources.warning_icon_color_48;
                    break;
                case MsgBoxIcon.Error:
                    MsgBox.pbIcon.BackgroundImage = Properties.Resources.error_icon_color_48;
                    break;
            }

            MsgBox.btnClose.Visible = true;
            MsgBox.ShowDialog();
            return dlgResult;
        }

        public DialogResult Show(string text, string caption, MsgBoxIcon icon, Button button)
        {
            DialogResult dlgResult = DialogResult.None;
            MsgBox = new CustomMsgBox();
            MsgBox.lCaption.Text = caption;
            MsgBox.lblMessage.Text = text;

            switch (icon)
            {
                case MsgBoxIcon.Information:
                    MsgBox.pbIcon.BackgroundImage = Properties.Resources.info_icon_color_48;
                    break;
                case MsgBoxIcon.Warning:
                    MsgBox.pbIcon.BackgroundImage = Properties.Resources.warning_icon_color_48;
                    break;
                case MsgBoxIcon.Error:
                    MsgBox.pbIcon.BackgroundImage = Properties.Resources.error_icon_color_48;
                    break;
            }

            switch (button)
            {
                case Button.Close:
                    MsgBox.btnClose.Visible = true;
                    MsgBox.btnClose.Text = "Close";
                    break;
                case Button.OK:
                    MsgBox.btnClose.Visible = true;
                    MsgBox.btnClose.Text = "OK";
                    break;
                case Button.YesNo:
                    MsgBox.btnYes.Visible = true;
                    MsgBox.btnNo.Visible = true;
                    MsgBox.btnNo.Text = "No";
                    MsgBox.btnYes.Text = "Yes";
                    break;
                default:
                    break;
            }

            MsgBox.ShowDialog();

            return dlgResult;
        }

        public enum MsgBoxIcon
        {
            None = 0,
            Error = 1,
            Question = 2,
            Warning = 3,
            Information = 4
        }

        public enum Button
        {
            Close = 0,
            OK = 1,
            YesNo = 2,
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
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
