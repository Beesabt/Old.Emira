using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

using emira.BusinessLogicLayer;
using emira.HelperFunctions;

namespace emira.GUI
{
    public partial class AddOrUpdateGroupPage : Form
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        int togMove;
        int mValX;
        int mValY;
        string groupID = string.Empty;
        string groupName = string.Empty;
        CustomMsgBox customMsgBox;

        public AddOrUpdateGroupPage()
        {
            InitializeComponent();
        }

        private void AddOrUpdateGroupPage_Load(object sender, EventArgs e)
        {
            try
            {
                var l_CurrentStack = new StackTrace(true);

                for (int i = 0; i <= l_CurrentStack.FrameCount; i++)
                {
                    StackFrame _click = l_CurrentStack.GetFrame(i);

                    if (_click.GetMethod().ToString().Contains("btnAddGroup_Click"))
                    {
                        lAddOrUpdateGroup.Text = "Csoport hozááadása";
                        btnAdd.Text = Texts.Button.Add;

                        break;
                    }

                    if (_click.GetMethod().ToString().Contains("btnUpdateGroup_Click"))
                    {

                        // Get the actual value of the group combobox
                        TaskManager _taskManager = new TaskManager();
                        string _groupIDandName = string.Empty;

                        _groupIDandName = TaskManager.cbGroupValue;

                        // The text of the combobox contains the group ID and Name
                        string[] _group = new string[2];
                        if (!string.IsNullOrEmpty(_groupIDandName))
                        {
                            _group = _groupIDandName.Split(' ');
                        }

                        // Set the global variables for Update button
                        groupID = _group[0];
                        groupName = _group[1];

                        // Set the group ID
                        int _groupID;
                        if (Int32.TryParse(_group[0], out _groupID))
                        {
                            nupGroupID.Value = _groupID;
                        }

                        // Set the group Name
                        tbGroupName.Text = _group[1];

                        // Modify the text of the label and button
                        lAddOrUpdateGroup.Text = "Csoport módosítása";
                        btnAdd.Text = Texts.Button.Update;
                        break;
                    }
                }
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }       
        }

        private void nupGroupID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                TaskModification _taskModification = new TaskModification();

                // Cehck the text field is empty or not
                if (!_taskModification.TextBoxValueValidation(tbGroupName.Text))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.RequiredFieldIsEmpty, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    return;
                }

                bool _isSuccess = false;

                if (btnAdd.Text == Texts.Button.Add)
                {                    
                    // Add new group
                    _isSuccess = _taskModification.AddNewGroup(nupGroupID.Value.ToString(), tbGroupName.Text);

                    if (!_isSuccess)
                    {
                        customMsgBox = new CustomMsgBox();
                        customMsgBox.Show(Texts.ErrorMessages.CheckValuesOfFields, Texts.Captions.InvalidValue, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                        return;
                    }

                    Close();
                }
                else
                {
                    // Update the group
                    _isSuccess = _taskModification.UpdateGroup(groupID, nupGroupID.Value.ToString(), groupName, tbGroupName.Text);

                    if (!_isSuccess)
                    {
                        customMsgBox = new CustomMsgBox();
                        customMsgBox.Show(Texts.ErrorMessages.CheckValuesOfFields, Texts.Captions.InvalidValue, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                        return;
                    }

                    Close();
                }
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
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
            togMove = 0;
        }

        private void pHeader_MouseDown(object sender, MouseEventArgs e)
        {
            togMove = 1;
            mValX = e.X;
            mValY = e.Y;
        }

        private void pHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (togMove == 1)
            {
                SetDesktopLocation(MousePosition.X - mValX, MousePosition.Y - mValY);
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
