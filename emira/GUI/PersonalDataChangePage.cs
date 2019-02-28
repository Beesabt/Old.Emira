using emira.BusinessLogicLayer;
using emira.ValueObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace emira.GUI
{
    public partial class PersonalDataChangePage : Form
    {

        bool _bTogMove;
        int _iValX;
        int _iValY;
        Settings _settings;
        Person _person;

        public PersonalDataChangePage()
        {
            InitializeComponent();
        }

        private void DataChangePage_Load(object sender, EventArgs e)
        {
            try
            {
                _settings = new Settings();
                _person = new Person();

                _person = _settings.GetPersonalInformation();

                // Personal Informatiion
                tbName.Text = _person.Name;
                if (_person.Gender == true)
                {
                    rbMale.Select();
                }
                else
                {
                    rbFemale.Select();
                }

                // Company Related Information
                tbRegisterNumber.Text = _person.RegisterNumber.ToString();
                tbCompany.Text = _person.Company;
                tbCostCenter.Text = _person.CostCenter;
                tbPosition.Text = _person.Position;

                // Holiday Related Information
                if (!string.IsNullOrEmpty(_person.DateOfBirth.ToShortDateString())) { dtpDateOfBirth.Text = _person.DateOfBirth.ToShortDateString(); }
                if (!string.IsNullOrEmpty(_person.DateOfStart.ToShortDateString())) { dtpDateOfStart.Text = _person.DateOfStart.ToShortDateString(); }
                nupNumberOfChildren.Value = _person.NumberOfChildren;
                nupNumberOfDisabledChildren.Value = _person.NumberOfDisabledChildren;

                if (rbFemale.Checked)
                {
                    lNumberOfNewBornBabies.Hide();
                    nupNumberOfNewBornBabies.Hide();
                }
                else
                {
                    nupNumberOfNewBornBabies.Value = _person.NumberOfNewBornBabies;
                }

                btnSave.Enabled = false;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _settings = new Settings();
                bool _isSuccess = false;

                // Null check
                if (string.IsNullOrEmpty(tbName.Text.Trim()))
                {
                    MessageBox.Show(lName.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(tbRegisterNumber.Text.Trim()))
                {
                    MessageBox.Show(lRegisterNumber.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(tbCompany.Text.Trim()))
                {
                    MessageBox.Show(lCompany.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(tbCostCenter.Text.Trim()))
                {
                    MessageBox.Show(lCostCenter.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(tbPosition.Text.Trim()))
                {
                    MessageBox.Show(lPosition.Text.Trim(':') + Texts.ErrorMessages.FieldIsEmpty, Texts.Captions.EmptyRequiredField, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Register number contains only numbers
                if (!System.Text.RegularExpressions.Regex.IsMatch(tbRegisterNumber.Text, "^[0-9]*$"))
                {
                    MessageBox.Show(lRegisterNumber.Text.Trim(':') + Texts.ErrorMessages.NumericField, Texts.Captions.NumericField, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Employee can not be younger than 15 years old
                DateTime _IsSixteenYearsOld = new DateTime(DateTime.Today.Date.Year - 16, DateTime.Today.Date.Month, DateTime.Today.Date.Day);
                if (_IsSixteenYearsOld < dtpDateOfBirth.Value)
                {
                    MessageBox.Show(Texts.ErrorMessages.WorkNotAllowed15, Texts.Captions.BirthOfDateError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Employee can not be older than 100 years old
                DateTime _IsOneHundredYearsOld = new DateTime(DateTime.Today.Date.Year - 100, DateTime.Today.Date.Month, DateTime.Today.Date.Day);
                if (_IsOneHundredYearsOld >= dtpDateOfBirth.Value)
                {
                    MessageBox.Show(Texts.ErrorMessages.WorkNotAllowed100, Texts.Captions.BirthOfDateError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Birth date check with start of date
                if (dtpDateOfBirth.Value > dtpDateOfStart.Value)
                {
                    MessageBox.Show(Texts.ErrorMessages.StartOfDateTooSmall, Texts.Captions.StartOfDateError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Number of the disabled children can not bigger than the number of the children
                if (nupNumberOfDisabledChildren.Value > nupNumberOfChildren.Value)
                {
                    MessageBox.Show(lNumberOfDisabledChildren.Text.Trim(':') + Texts.ErrorMessages.BiggerNumberThanNumberOfChildren, Texts.Captions.NumberOfTheChildrenError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Number of the new born babies can not bigger than the number of the children
                if (nupNumberOfNewBornBabies.Value > nupNumberOfChildren.Value)
                {
                    MessageBox.Show(lNumberOfNewBornBabies.Text.Trim(':') + Texts.ErrorMessages.BiggerNumberThanNumberOfChildren, Texts.Captions.NumberOfTheChildrenError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Number of the disabled children and new born babies can not bigger than the number of the children
                if ((nupNumberOfNewBornBabies.Value + nupNumberOfDisabledChildren.Value) > nupNumberOfChildren.Value)
                {
                    MessageBox.Show(Texts.ErrorMessages.DiabledAndNewBornBigger, Texts.Captions.NumberOfTheChildrenError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add(Texts.PersonProperties.Name, tbName.Text);
                if (rbMale.Checked)
                {
                    data.Add(Texts.PersonProperties.Gender, "true");
                }
                else
                {
                    data.Add(Texts.PersonProperties.Gender, "false");
                }
                data.Add(Texts.PersonProperties.RegisterNumber, tbRegisterNumber.Text);
                data.Add(Texts.PersonProperties.Company, tbCompany.Text);
                data.Add(Texts.PersonProperties.CostCenter, tbCostCenter.Text);
                data.Add(Texts.PersonProperties.Position, tbPosition.Text);
                data.Add(Texts.PersonProperties.DateOfStart, dtpDateOfStart.Value.ToShortDateString().Replace(". ", "-").Trim('.'));
                data.Add(Texts.PersonProperties.DateOfBirth, dtpDateOfBirth.Value.ToShortDateString().Replace(". ", "-").Trim('.'));
                data.Add(Texts.PersonProperties.NumberOfChildren, nupNumberOfChildren.Value.ToString());
                data.Add(Texts.PersonProperties.NumberOfDisabledChildren, nupNumberOfDisabledChildren.Value.ToString());
                data.Add(Texts.PersonProperties.NumberOfNewBornBabies, nupNumberOfNewBornBabies.Value.ToString());
               
                _isSuccess = _settings.SetNewValues(Texts.PersonProperties.ID, LogInfo.UserID.ToString(), data);
                if (_isSuccess)
                {
                    MessageBox.Show(Texts.InformationMessages.PersonalInformationChanged, Texts.Captions.SuccessfulChange, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbMale.Checked)
                {
                    lNumberOfNewBornBabies.Show();
                    nupNumberOfNewBornBabies.Show();
                }
                btnSave.Enabled = true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbFemale.Checked)
                {
                    lNumberOfNewBornBabies.Hide();
                    nupNumberOfNewBornBabies.Hide();
                }
                btnSave.Enabled = true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

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

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void dtpDateOfStart_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void nupNumberOfChildren_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void nupNumberOfDisabledChildren_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void nupNumberOfNewBornBabies_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void rbYes_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
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
            Color _Win10BlueBorderColor = new Color();
            _Win10BlueBorderColor = Color.FromArgb(24, 116, 188);
            e.Graphics.DrawRectangle(new Pen(_Win10BlueBorderColor), borderRectangle);
            base.OnPaint(e);
        }

    }
}
