using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Windows.Forms;

using emira.BusinessLogicLayer;
using emira.HelperFunctions;

namespace emira.GUI
{
    public partial class EmailChange : UserControl
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
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
                    customMsgBox.Show(lOldEmail.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    return;
                }

                // Null check for value of new e-mail
                if (tbNewEmail.Text.Trim() == string.Empty)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(lNewEmail.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    return;
                }

                // Null check for value of new e-mail again
                if (tbNewEmailAgain.Text.Trim() == string.Empty)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(lNewEmailAgain.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    return;
                }

                // Wrong old e-mail
                if (!settings.OldValueValidation(Texts.PersonProperties.Email, tbOldEmail.Text))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.WrongOldEmail, Texts.Captions.WrongOldValue, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    tbOldEmail.Text = string.Empty;
                    return;
                }

                // Mismatched new e-mails
                if (tbNewEmail.Text != tbNewEmailAgain.Text)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.NewEmailMismatched, Texts.Captions.MissmatchadEmails, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    tbNewEmailAgain.Text = string.Empty;
                    return;
                }

                // New e-mail is the same as the old e-mail
                if (tbOldEmail.Text == tbNewEmail.Text)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.NewEmailSameAsOldEmail, Texts.Captions.NewEmaildIsNotAllowed, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    tbNewEmail.Text = string.Empty;
                    tbNewEmailAgain.Text = string.Empty;
                    return;
                }

                // Check of the e-mail address' format
                var email = new EmailAddressAttribute();
                if (!email.IsValid(tbNewEmail.Text))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.EmailIsNotValid, Texts.Captions.InvalidEmail, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    return;
                }

                // Set new value
                bool _isSuccess = false;
                _isSuccess = settings.SetNewValue(Texts.PersonProperties.Email, tbOldEmail.Text, tbNewEmail.Text);

                if (_isSuccess)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.InformationMessages.EmailChanged, Texts.Captions.SuccessfulChange, CustomMsgBox.MsgBoxIcon.Information, CustomMsgBox.Button.OK);
                    GeneralInfo.Email = tbNewEmail.Text;
                    tbOldEmail.Text = string.Empty;
                    tbNewEmail.Text = string.Empty;
                    tbNewEmailAgain.Text = string.Empty;
                }
                else
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.ErrorDuringSave, Texts.Captions.ErrorSave, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    tbOldEmail.Text = string.Empty;
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
