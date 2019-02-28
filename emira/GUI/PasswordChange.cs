using emira.BusinessLogicLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace emira.GUI
{
    public partial class PasswordChange : UserControl
    {
        Settings _settings;

        public PasswordChange()
        {
            InitializeComponent();
        }

        private void btnPasswordChange_Click(object sender, EventArgs e)
        {
            try
            {
                _settings = new Settings();

                // Null check
                if (string.IsNullOrEmpty(tbOldPassword.Text.Trim()))
                {
                    MessageBox.Show(lOldPassword.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Null check
                if (string.IsNullOrEmpty(tbNewPassword.Text.Trim()))
                {
                    MessageBox.Show(lNewPassword.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Null check
                if (string.IsNullOrEmpty(tbNewPasswordAgain.Text.Trim()))
                {
                    MessageBox.Show(lNewPasswordAgain.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Wrong old password
                if (!_settings.OldValueValidation(Texts.PersonProperties.Password, tbOldPassword.Text))
                {
                    MessageBox.Show(Texts.ErrorMessages.WrongOldPassword, Texts.Captions.WrongOldValue, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbOldPassword.Text = string.Empty;
                    return;
                }

                // Mismatched new passwords
                if (tbNewPassword.Text != tbNewPasswordAgain.Text)
                {
                    MessageBox.Show(Texts.ErrorMessages.NewPasswordsMismatched, Texts.Captions.MissmatchadPasswords, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbNewPasswordAgain.Text = string.Empty;
                    return;
                }

                // New password is the same as the old password
                if (tbOldPassword.Text == tbNewPassword.Text)
                {
                    MessageBox.Show(Texts.ErrorMessages.NewPasswordSameAsOldPassword, Texts.Captions.NewPasswordIsNotAllowed, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbNewPassword.Text = string.Empty;
                    tbNewPasswordAgain.Text = string.Empty;
                    return;
                }

                // Check of the password's rules
                if (!_settings.IsValidPassword(tbNewPassword.Text))
                {
                    MessageBox.Show(Texts.ErrorMessages.NewPasswordIsNotAllowed, Texts.Captions.NewPasswordIsNotAllowed, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbNewPassword.Text = string.Empty;
                    tbNewPasswordAgain.Text = string.Empty;
                    return;
                }

                _settings.SetNewValue(Texts.PersonProperties.Password, tbOldPassword.Text, tbNewPassword.Text);
                MessageBox.Show(Texts.InformationMessages.PasswordChanged, Texts.Captions.SuccessfulChange, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbOldPassword.Text = string.Empty;
                tbNewPassword.Text = string.Empty;
                tbNewPasswordAgain.Text = string.Empty;

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
