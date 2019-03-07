using emira.BusinessLogicLayer;
using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Windows.Forms;
using emira.HelperFunctions;

namespace emira.GUI
{
    public partial class EmailChange : UserControl
    {
        Settings _settings;

        public EmailChange()
        {
            InitializeComponent();
        }

        private void btnUNameChange_Click(object sender, EventArgs e)
        {
            try
            {
                _settings = new Settings();

                // Null check
                if (tbOldEmail.Text.Trim() == string.Empty)
                {
                    MessageBox.Show(lOldEmail.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Null check
                if (tbNewEmail.Text.Trim() == string.Empty)
                {
                    MessageBox.Show(lNewEmail.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Null check
                if (tbNewEmailAgain.Text.Trim() == string.Empty)
                {
                    MessageBox.Show(lNewEmailAgain.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Wrong old e-mail
                if (!_settings.OldValueValidation(Texts.PersonProperties.Email, tbOldEmail.Text))
                {
                    MessageBox.Show(Texts.ErrorMessages.WrongOldEmail, Texts.Captions.WrongOldValue, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbOldEmail.Text = string.Empty;
                    return;
                }

                // Mismatched new e-mails
                if (tbNewEmail.Text != tbNewEmailAgain.Text)
                {
                    MessageBox.Show(Texts.ErrorMessages.NewEmailMismatched, Texts.Captions.MissmatchadEmails, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbNewEmailAgain.Text = string.Empty;
                    return;
                }

                // New e-mail is the same as the old e-mail
                if (tbOldEmail.Text == tbNewEmail.Text)
                {
                    MessageBox.Show(Texts.ErrorMessages.NewEmailSameAsOldEmail, Texts.Captions.NewEmaildIsNotAllowed, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbNewEmail.Text = string.Empty;
                    tbNewEmailAgain.Text = string.Empty;
                    return;
                }

                // Check of the e-mail address' format
                var email = new EmailAddressAttribute();
                if (!email.IsValid(tbNewEmail.Text))
                {
                    MessageBox.Show(Texts.ErrorMessages.EmailIsNotValid, Texts.Captions.InvalidEmail, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _settings.SetNewValue(Texts.PersonProperties.Email, tbOldEmail.Text, tbNewEmail.Text);
                MessageBox.Show(Texts.InformationMessages.EmailChanged, Texts.Captions.SuccessfulChange, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LogInfo.Email = tbNewEmail.Text;
                tbOldEmail.Text = string.Empty;
                tbNewEmail.Text = string.Empty;
                tbNewEmailAgain.Text = string.Empty;
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
