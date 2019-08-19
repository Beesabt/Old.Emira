using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using emira.BusinessLogicLayer;
using emira.ValueObjects;
using emira.HelperFunctions;

namespace emira.GUI
{
    public partial class PersonalDataChangePage : Form
    {

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        bool bTogMove;
        int iValX;
        int iValY;
        Settings settings;
        Person person;
        CustomMsgBox customMsgBox;

        public PersonalDataChangePage()
        {
            InitializeComponent();
        }

        private void DataChangePage_Load(object sender, EventArgs e)
        {
            try
            {
                settings = new Settings();
                person = new Person();

                person = settings.GetPersonalInformation();

                // If the Person object is null then it returns
                if (person.Email == null)
                    return;

                //// Personal Information

                tbName.Text = person.Name;

                if (person.Gender)
                {
                    rbMale.Select();
                }
                else
                {
                    rbFemale.Select();
                }

                //// Company Related Information

                tbRegisterNumber.Text = person.RegisterNumber.ToString();

                tbCompany.Text = person.Company;

                tbCostCenter.Text = person.CostCenter;

                tbPosition.Text = person.Position;

                nupWorkingHours.Value = person.WorkingHours;

                //// Holiday Related Information

                dtpDateOfBirth.Text = person.DateOfBirth.ToShortDateString();
                dtpDateOfStart.Text = person.DateOfStart.ToShortDateString();

                if (person.NumberOfChildren > 0)
                {
                    cbYesChild.Checked = true;
                    nupNumberOfChildren.Value = person.NumberOfChildren;

                    lDoYouHaveDiasabledChild.Show();
                    cbNoDisabledChild.Show();
                    cbYesDisabledChild.Show();
                }
                else
                {
                    cbNoChild.Checked = true;
                }

                if (person.NumberOfDisabledChildren > 0)
                {
                    cbYesChild.Checked = true;
                    nupNumberOfDisabledChildren.Value = person.NumberOfDisabledChildren;

                    lDoYouHaveDiasabledChild.Show();
                    cbNoDisabledChild.Show();
                    cbYesDisabledChild.Show();
                    cbYesDisabledChild.Checked = true;
                }
                else
                {
                    cbNoDisabledChild.Checked = true;
                }

                if (person.NumberOfNewBornBabies > 0 && rbMale.Checked)
                {
                    cbYesChild.Checked = true;
                    nupNumberOfNewBornBabies.Value = person.NumberOfNewBornBabies;

                    lNumberOfChildren.Show();
                    nupNumberOfChildren.Show();
                    lDoYouHaveDiasabledChild.Show();
                    cbNoDisabledChild.Show();
                    cbYesDisabledChild.Show();
                    lNumberOfNewBornBabies.Show();
                    nupNumberOfNewBornBabies.Show();                                    
                }
                else
                {
                    lNumberOfNewBornBabies.Hide();
                    nupNumberOfNewBornBabies.Hide();
                }

                if (rbFemale.Checked)
                {
                    lNumberOfNewBornBabies.Hide();
                    nupNumberOfNewBornBabies.Hide();
                }

                if (person.HealthDamage)
                {
                    cbYesHealthDamage.Checked = true;
                }
                else
                {
                    cbNoHealthDamage.Checked = true;
                }

                int _actaulYear = DateTime.Today.Year;
                if (person.DateOfStart.Year == _actaulYear)
                {
                    lHolidaysLeft.Show();
                    nupHolidaysLeft.Show();
                    if (person.HolidaysLeftFromPreviousYear > 0)
                    {
                        nupHolidaysLeft.Value = person.HolidaysLeftFromPreviousYear;
                    }
                }

                if (person.ExtraHoliday > 0)
                {
                    nupExtraHoliday.Value = person.ExtraHoliday;
                }

                // Save button is not enabled
                btnSave.Enabled = false;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }



        // Personal Information
        private void tbName_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                // If the user is male and he has child/children
                // then the NewBornBabies is available for him
                if (rbMale.Checked && cbYesChild.Checked)
                {
                    lNumberOfNewBornBabies.Show();
                    nupNumberOfNewBornBabies.Show();
                }

                // Save button is enabled
                btnSave.Enabled = true;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                // If the user is female then the NewBornBabies value is zero
                // and the controls are hidden
                if (rbFemale.Checked)
                {
                    nupNumberOfNewBornBabies.Value = 0;
                    lNumberOfNewBornBabies.Hide();
                    nupNumberOfNewBornBabies.Hide();
                }

                // Save button is enabled
                btnSave.Enabled = true;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }



        // Company Related Information
        private void tbRegisterNumber_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void tbCompany_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void tbCostCenter_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void tbPosition_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void nupWorkingHours_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }



        // Holiday Related Information
        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void dtpDateOfStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDateOfStart.Value.Year == DateTime.Today.Year)
            {
                // Show controls
                lHolidaysLeft.Show();
                nupHolidaysLeft.Show();
            }
            else
            {
                // Hide controls
                lHolidaysLeft.Hide();
                nupHolidaysLeft.Hide();
                nupHolidaysLeft.Value = 0;
            }

            btnSave.Enabled = true;
        }

        private void cbNoChild_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbNoChild.Checked)
                {
                    // Set values
                    cbYesChild.Checked = false;
                    nupNumberOfChildren.Value = 0;
                    cbYesDisabledChild.Checked = false;
                    nupNumberOfDisabledChildren.Value = 0;
                    nupNumberOfNewBornBabies.Value = 0;

                    // Hide controls
                    lNumberOfChildren.Hide();
                    nupNumberOfChildren.Hide();
                    lDoYouHaveDiasabledChild.Hide();
                    cbNoDisabledChild.Hide();
                    cbYesDisabledChild.Hide();
                    lNumberOfDisabledChildren.Hide();
                    nupNumberOfDisabledChildren.Hide();
                    lNumberOfNewBornBabies.Hide();
                    nupNumberOfNewBornBabies.Hide();
                }

                // Save button is enabled
                btnSave.Enabled = true;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void cbYesChild_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbYesChild.Checked)
                {
                    // Set value
                    cbNoChild.Checked = false;

                    // Show controls
                    lNumberOfChildren.Show();
                    nupNumberOfChildren.Show();
                    lDoYouHaveDiasabledChild.Show();
                    cbNoDisabledChild.Show();
                    cbYesDisabledChild.Show();

                    if (cbYesDisabledChild.Checked)
                    {
                        lNumberOfDisabledChildren.Show();
                        nupNumberOfDisabledChildren.Show();
                    }
                    else
                    {
                        lNumberOfDisabledChildren.Hide();
                        nupNumberOfDisabledChildren.Hide();
                    }

                    // If the user is femaile then the NewBornBabies is hidden
                    if (rbFemale.Checked)
                    {
                        lNumberOfNewBornBabies.Hide();
                        nupNumberOfNewBornBabies.Hide();
                    }
                    else
                    {
                        lNumberOfNewBornBabies.Show();
                        nupNumberOfNewBornBabies.Show();
                    }
                }

                btnSave.Enabled = true;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void nupNumberOfChildren_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void cbNoDisabledChild_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbNoDisabledChild.Checked)
                {
                    // Set value
                    cbYesDisabledChild.Checked = false;
                    nupNumberOfDisabledChildren.Value = 0;

                    // Hide controls
                    lNumberOfDisabledChildren.Hide();
                    nupNumberOfDisabledChildren.Hide();
                }

                btnSave.Enabled = true;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void cbYesDisabledChild_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbYesDisabledChild.Checked)
                {
                    // Set value
                    cbNoDisabledChild.Checked = false;

                    // Show controls
                    lNumberOfDisabledChildren.Show();
                    nupNumberOfDisabledChildren.Show();
                }

                btnSave.Enabled = true;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void nupNumberOfDisabledChildren_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void nupNumberOfNewBornBabies_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void cbNoHealthDamage_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbNoHealthDamage.Checked)
                {
                    cbYesHealthDamage.Checked = false;
                }

                btnSave.Enabled = true;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void cbYesHealthDamage_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbYesHealthDamage.Checked)
                {
                    cbNoHealthDamage.Checked = false;
                }

                btnSave.Enabled = true;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void nupHolidaysLeft_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void nupExtraHoliday_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }



        // The number up down and the date time picker controls can not modify by manual
        private void nupWorkingHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dtpDateOfBirth_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dtpDateOfStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void nupNumberOfChildren_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void nupNumberOfDisabledChildren_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void nupNumberOfNewBornBabies_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void nupHolidaysLeft_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void nupExtraHoliday_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }



        // Save and Cancel buttons
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                settings = new Settings();
                customMsgBox = new CustomMsgBox();
                bool _isSuccess = false;

                // Null check
                if (string.IsNullOrEmpty(tbName.Text.Trim()))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(lName.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.OK);
                    tbName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(tbCompany.Text.Trim()))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(lCompany.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.OK);
                    tbCompany.Focus();
                    return;
                }

                // Name contains number or special character (exception: '.' and '-')
                if (!System.Text.RegularExpressions.Regex.IsMatch(tbName.Text, @"^[a-zA-Z\s\.-]*$"))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(lRegisterNumber.Text.Trim(':') + Texts.ErrorMessages.TextField, Texts.Captions.TextField, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.OK);
                    tbName.Focus();
                    return;
                }

                // Register number contains only numbers
                if (!System.Text.RegularExpressions.Regex.IsMatch(tbRegisterNumber.Text, "^[0-9]*$"))
                {
                    MessageBox.Show(lRegisterNumber.Text.Trim(':') + Texts.ErrorMessages.NumericField, Texts.Captions.NumericField, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lRegisterNumber.Focus();
                    return;
                }

                // Employee can not be younger than 15 years old
                if (dtpDateOfBirth.Value > DateTime.Today.AddYears(-16))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.WorkNotAllowed15, Texts.Captions.BirthOfDateError, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.OK);
                    dtpDateOfBirth.Focus();
                    return;
                }

                // Employee can not be older than 100 years old
                if (dtpDateOfBirth.Value <= DateTime.Today.AddYears(-100))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.WorkNotAllowed100, Texts.Captions.BirthOfDateError, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.OK);
                    dtpDateOfBirth.Focus();
                    return;
                }

                // Birth date check with start of date
                if (dtpDateOfBirth.Value > dtpDateOfStart.Value)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.StartOfDateTooSmall, Texts.Captions.StartOfDateError, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.OK);
                    dtpDateOfStart.Focus();
                    return;
                }

                // Start date can not be bigger than the actual date
                if (dtpDateOfStart.Value > DateTime.Today)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.StartOfDateBiggerThanTodayDate, Texts.Captions.StartOfDateError, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.OK);
                    dtpDateOfStart.Focus();
                    return;
                }

                // If the checkbox of the disabled children is yes, then it can not be null
                if (cbYesDisabledChild.Checked && nupNumberOfDisabledChildren.Value == 0)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.DisabledChildrenIsNull, Texts.Captions.NumberOfTheChildrenError, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.OK);
                    nupNumberOfDisabledChildren.Focus();
                    return;
                }

                // if the 'Yes' is checked for the question 'Do you have children?', but nothing is added
                if (nupNumberOfChildren.Value == 0 && nupNumberOfDisabledChildren.Value == 0 && nupNumberOfNewBornBabies.Value == 0 && cbYesChild.Checked)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.NumberOfChildren, Texts.Captions.NumberOfTheChildrenError, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.OK);
                    nupNumberOfChildren.Focus();
                    return;
                }

                // Collect information
                Dictionary<string, string> _data = new Dictionary<string, string>();
                _data.Add(Texts.PersonProperties.Name, tbName.Text.TrimStart().TrimEnd());
                _data.Add(Texts.PersonProperties.Gender, rbMale.Checked.ToString().ToLower());
                _data.Add(Texts.PersonProperties.RegisterNumber, tbRegisterNumber.Text);
                _data.Add(Texts.PersonProperties.Company, tbCompany.Text);
                _data.Add(Texts.PersonProperties.CostCenter, tbCostCenter.Text);
                _data.Add(Texts.PersonProperties.Position, tbPosition.Text);
                _data.Add(Texts.PersonProperties.WorkingHours, nupWorkingHours.Value.ToString());
                _data.Add(Texts.PersonProperties.DateOfStart, dtpDateOfStart.Text.ToString());
                _data.Add(Texts.PersonProperties.DateOfBirth, dtpDateOfBirth.Text.ToString());
                _data.Add(Texts.PersonProperties.NumberOfChildren, nupNumberOfChildren.Value.ToString());
                _data.Add(Texts.PersonProperties.NumberOfDisabledChildren, nupNumberOfDisabledChildren.Value.ToString());
                _data.Add(Texts.PersonProperties.NumberOfNewBornBabies, nupNumberOfNewBornBabies.Value.ToString());
                _data.Add(Texts.PersonProperties.HealthDamage, cbYesHealthDamage.Checked.ToString().ToLower());
                _data.Add(Texts.PersonProperties.HolidaysLeftFromPreviousYear, nupHolidaysLeft.Value.ToString());
                _data.Add(Texts.PersonProperties.ExtraHoliday, nupExtraHoliday.Value.ToString());

                // Set new values
                _isSuccess = settings.SetNewValues(Texts.PersonProperties.Email, GeneralInfo.Email, _data);

                if (_isSuccess)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.InformationMessages.PersonalInformationChanged, Texts.Captions.SuccessfulChange, CustomMsgBox.MsgBoxIcon.Information, CustomMsgBox.Button.OK);
                    Close();
                }
                else
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.ErrorDuringSave, Texts.Captions.ErrorSave, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.OK);
                }
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }


        // Exit button
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
            Color _Win10BlueBorderColor = new Color();
            _Win10BlueBorderColor = Color.FromArgb(24, 116, 188);
            e.Graphics.DrawRectangle(new Pen(_Win10BlueBorderColor), borderRectangle);
            base.OnPaint(e);
        }
    }
}
