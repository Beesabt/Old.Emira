using System;
using System.Drawing;
using System.Windows.Forms;

using emira.BusinessLogicLayer;
using emira.HelperFunctions;

namespace emira.GUI
{
    public partial class PasswordChange : UserControl
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
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
                    customMsgBox.Show(lOldPassword.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    return;
                }

                // Null check
                if (string.IsNullOrEmpty(tbNewPassword.Text.Trim()))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(lNewPassword.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    return;
                }

                // Null check
                if (string.IsNullOrEmpty(tbNewPasswordAgain.Text.Trim()))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(lNewPasswordAgain.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    return;
                }

                // Wrong old password
                if (!settings.OldValueValidation(Texts.PersonProperties.Password, tbOldPassword.Text))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.WrongOldPassword, Texts.Captions.WrongOldValue, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    tbOldPassword.Text = string.Empty;
                    return;
                }

                // Mismatched new passwords
                if (tbNewPassword.Text != tbNewPasswordAgain.Text)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.NewPasswordsMismatched, Texts.Captions.MissmatchadPasswords, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    tbNewPasswordAgain.Text = string.Empty;
                    return;
                }

                // New password is the same as the old password
                if (tbOldPassword.Text == tbNewPassword.Text)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.NewPasswordSameAsOldPassword, Texts.Captions.NewPasswordIsNotAllowed, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    tbNewPassword.Text = string.Empty;
                    tbNewPasswordAgain.Text = string.Empty;
                    return;
                }

                // Check of the password's rules
                if (!settings.IsValidPassword(tbNewPassword.Text))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.NewPasswordIsNotAllowed, Texts.Captions.NewPasswordIsNotAllowed, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
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
                }
                else
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.ErrorDuringSave, Texts.Captions.ErrorSave, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    tbOldPassword.Text = string.Empty;
                }


            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
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
