using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Windows.Forms;

using emira.BusinessLogicLayer;
using emira.Utilities;

namespace emira.GUI
{
    public partial class EmailChange : UserControl
    {
        CustomMsgBox customMsgBox;
        Settings settings;

        public EmailChange()
        {
            InitializeComponent();
        }

        private void btnUNameChange_Click(object sender, EventArgs e)
        {
            try
            {
                settings = new Settings();

                // Null check for value of old e-mail
                if (tbOldEmail.Text.Trim() == string.Empty)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(lOldEmail.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error);
                    return;
                }

                // Null check for value of new e-mail
                if (tbNewEmail.Text.Trim() == string.Empty)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(lNewEmail.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error);
                    return;
                }

                // Null check for value of new e-mail again
                if (tbNewEmailAgain.Text.Trim() == string.Empty)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(lNewEmailAgain.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error);
                    return;
                }

                // Wrong old e-mail
                if (!settings.OldValueValidation(Texts.PersonProperties.Email, tbOldEmail.Text))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(Texts.ErrorMessages.WrongOldEmail, Texts.Captions.WrongOldValue, CustomMsgBox.MsgBoxIcon.Error);
                    tbOldEmail.Text = string.Empty;
                    return;
                }

                // New e-mail address is the default
                if (tbNewEmail.Text == GeneralInfo.DefaultEmail)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(Texts.ErrorMessages.NewEmailIsDefault, Texts.Captions.NewEmaildIsNotAllowed, CustomMsgBox.MsgBoxIcon.Error);
                    tbNewEmailAgain.Text = string.Empty;
                    return;
                }

                // Mismatched new e-mails
                if (tbNewEmail.Text != tbNewEmailAgain.Text)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(Texts.ErrorMessages.NewEmailMismatched, Texts.Captions.MissmatchadEmails, CustomMsgBox.MsgBoxIcon.Error);
                    tbNewEmailAgain.Text = string.Empty;
                    return;
                }

                // New e-mail is the same as the old e-mail
                if (tbOldEmail.Text == tbNewEmail.Text)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(Texts.ErrorMessages.NewEmailSameAsOldEmail, Texts.Captions.NewEmaildIsNotAllowed, CustomMsgBox.MsgBoxIcon.Error);
                    tbNewEmail.Text = string.Empty;
                    tbNewEmailAgain.Text = string.Empty;
                    return;
                }

                // Check of the e-mail address' format
                var email = new EmailAddressAttribute();
                if (!email.IsValid(tbNewEmail.Text))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(Texts.ErrorMessages.EmailIsNotValid, Texts.Captions.InvalidEmail, CustomMsgBox.MsgBoxIcon.Error);
                    return;
                }

                // Set new value
                bool _isSuccess = false;
                _isSuccess = settings.SetNewValue(Texts.PersonProperties.Email, tbOldEmail.Text, tbNewEmail.Text);

                if (_isSuccess)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.InformationMessages.EmailChanged, Texts.Captions.SuccessfulChange, CustomMsgBox.MsgBoxIcon.Information, CustomMsgBox.Button.OK);
                    tbOldEmail.Text = string.Empty;
                    tbNewEmail.Text = string.Empty;
                    tbNewEmailAgain.Text = string.Empty;
                    if (GeneralInfo.AnnoyingMessage)
                        GeneralInfo.AnnoyingMessage = false;
                }
                else
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.ShowError(Texts.ErrorMessages.ErrorDuringSave, Texts.Captions.ErrorSave, CustomMsgBox.MsgBoxIcon.Error);
                    tbOldEmail.Text = string.Empty;
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
