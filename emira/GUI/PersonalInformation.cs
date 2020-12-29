using System;
using System.Windows.Forms;
using System.Drawing;

using emira.BusinessLogicLayer;
using emira.ValueObjects;
using emira.HelperFunctions;

namespace emira.GUI
{
    public partial class PersonalInformation : UserControl
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        Settings settings;
        Person person;
        CustomMsgBox customMsgBox;

        public PersonalInformation()
        {
            InitializeComponent();           
        }

        private void tlpPersonalInformation_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                settings = new Settings();
                person = new Person();

                // Get the information
                person = settings.GetSomePersonalInformation();

                if (person != null)
                {
                    lNameFromDatabase.Text = person.Name;
                    lRegisterNumberFromDatabase.Text = person.RegisterNumber.ToString();
                    lCompanyFromDatabase.Text = person.Company;
                    lCostCenterFromDatabase.Text = person.CostCenter;
                    lPositionFromDatabase.Text = person.Position;
                }
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void btnChangeData_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(person.Name))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.DataTableNames.Person + Texts.ErrorMessages.UserIDDoesNotExistOrTableIsEmpty, Texts.Captions.PersonalInformationError, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    btnChangeData.Enabled = false;
                    return;
                }
                PersonalDataChangeForm _dataChangePage = new PersonalDataChangeForm();
                _dataChangePage.ShowDialog();
                tlpPersonalInformation.Invalidate();
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
