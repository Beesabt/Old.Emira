using System;
using System.Drawing;
using System.Windows.Forms;

using emira.BusinessLogicLayer;
using emira.Utilities;

namespace emira.GUI
{
    public partial class PasswordChange : UserControl
    {
        CustomMsgBox customMsgBox;
        Settings settings;

        public PasswordChange()
        {
            InitializeComponent();
        }

        private void btnPasswordChange_Click(object sender, EventArgs e)
        {
            try
            {
                settings = new Settings();

                // Null check
                if (string.IsNullOrEmpty(tbOldPassword.Text.Trim()))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(lOldPassword.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error);
                    return;
                }

                // Null check
                if (string.IsNullOrEmpty(tbNewPassword.Text.Trim()))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(lNewPassword.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error);
                    return;
                }

                // Null check
                if (string.IsNullOrEmpty(tbNewPasswordAgain.Text.Trim()))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(lNewPasswordAgain.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error);
                    return;
                }

                // Wrong old password
                if (!settings.OldValueValidation(Texts.PersonProperties.Password, tbOldPassword.Text))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(Texts.ErrorMessages.WrongOldPassword, Texts.Captions.WrongOldValue, CustomMsgBox.MsgBoxIcon.Error);
                    tbOldPassword.Text = string.Empty;
                    return;
                }

                // New password is the default
                if (tbNewPassword.Text == GeneralInfo.DefaultPassword)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(Texts.ErrorMessages.NewPasswordIsDefault, Texts.Captions.NewPasswordIsNotAllowed, CustomMsgBox.MsgBoxIcon.Error);
                    tbNewPasswordAgain.Text = string.Empty;
                    return;
                }

                // Mismatched new passwords
                if (tbNewPassword.Text != tbNewPasswordAgain.Text)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(Texts.ErrorMessages.NewPasswordsMismatched, Texts.Captions.MissmatchadPasswords, CustomMsgBox.MsgBoxIcon.Error);
                    tbNewPasswordAgain.Text = string.Empty;
                    return;
                }

                // New password is the same as the old password
                if (tbOldPassword.Text == tbNewPassword.Text)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(Texts.ErrorMessages.NewPasswordSameAsOldPassword, Texts.Captions.NewPasswordIsNotAllowed, CustomMsgBox.MsgBoxIcon.Error);
                    tbNewPassword.Text = string.Empty;
                    tbNewPasswordAgain.Text = string.Empty;
                    return;
                }

                // Check of the password's rules
                if (!settings.IsValidPassword(tbNewPassword.Text))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(Texts.ErrorMessages.NewPasswordIsNotAllowed, Texts.Captions.NewPasswordIsNotAllowed, CustomMsgBox.MsgBoxIcon.Error);
                    tbNewPassword.Text = string.Empty;
                    tbNewPasswordAgain.Text = string.Empty;
                    return;
                }

                // Set new value
                bool _isSuccessful = false;
                _isSuccessful = settings.SetNewValue(Texts.PersonProperties.Password, tbOldPassword.Text, tbNewPassword.Text);

                if (_isSuccessful)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.InformationMessages.PasswordChanged, Texts.Captions.SuccessfulChange, CustomMsgBox.MsgBoxIcon.Information, CustomMsgBox.Button.OK);
                    tbOldPassword.Text = string.Empty;
                    tbNewPassword.Text = string.Empty;
                    tbNewPasswordAgain.Text = string.Empty;
                    if (GeneralInfo.AnnoyingMessage)
                        GeneralInfo.AnnoyingMessage = false;
                }
                else
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(Texts.ErrorMessages.ErrorDuringSave, Texts.Captions.ErrorSave, CustomMsgBox.MsgBoxIcon.Error);
                    tbOldPassword.Text = string.Empty;
                }


            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
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
