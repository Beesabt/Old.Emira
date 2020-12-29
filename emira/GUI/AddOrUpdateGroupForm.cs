using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

using emira.BusinessLogicLayer;
using emira.Utilities;

namespace emira.GUI
{
    public partial class AddOrUpdateGroupForm : Form
    {
        int togMove;
        int mValX;
        int mValY;
        string oldGroupID = string.Empty;
        string oldGroupName = string.Empty;
        CustomMsgBox customMsgBox;
        TaskModification taskModification;

        public AddOrUpdateGroupForm()
        {
            InitializeComponent();
        }

        private void AddOrUpdateGroupPage_Load(object sender, EventArgs e)
        {
            try
            {
                var _currentStack = new StackTrace(true);

                for (int i = 0; i <= _currentStack.FrameCount; i++)
                {
                    StackFrame _click = _currentStack.GetFrame(i);

                    if (_click.GetMethod().ToString().Contains("btnAddGroup_Click"))
                    {
                        // Modify the text of the label and button
                        lAddOrUpdateGroup.Text = Texts.Label.Add;
                        btnAction.Text = Texts.Button.Add;

                        // Get the next group ID and set it for the number up down control
                        taskModification = new TaskModification();
                        int _nextGroupID = 0;
                        _nextGroupID = taskModification.GetNextGroupID();

                        if (_nextGroupID > 0)
                            nupGroupID.Value = _nextGroupID;

                        return;
                    }

                    if (_click.GetMethod().ToString().Contains("btnUpdateGroup_Click"))
                    {
                        // Modify the text of the label and button
                        lAddOrUpdateGroup.Text = Texts.Label.Update;
                        btnAction.Text = Texts.Button.Update;

                        // Get the actual value of the group combobox
                        TaskManager _taskManager = new TaskManager();
                        string _groupIDandName = string.Empty;

                        _groupIDandName = TaskManager.cbGroupValue;

                        // If somehow the combox was empty close the update dialog
                        if (string.IsNullOrEmpty(_groupIDandName)) Close();

                        // The text of the combobox contains the group ID and Name
                        string[] _group = new string[2];
                        _group = _groupIDandName.Split(' ');

                        // Set the global variables for Update button
                        oldGroupID = _group[0];
                        oldGroupName = _group[1];

                        // Set the group ID
                        int _groupID;
                        if (Int32.TryParse(_group[0], out _groupID))
                            nupGroupID.Value = _groupID;

                        // Set the group Name
                        tbGroupName.Text = _group[1];

                        return;
                    }
                }
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
            }
        }

        private void nupGroupID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                taskModification = new TaskModification();

                bool _isSuccess = false;

                if (btnAction.Text == Texts.Button.Add)
                {
                    // Add new group
                    _isSuccess = taskModification.AddNewGroup(nupGroupID.Value.ToString(), tbGroupName.Text);

                    if (!_isSuccess)
                    {
                        customMsgBox = new CustomMsgBox();
                        customMsgBox.ShowError(Texts.ErrorMessages.CheckValuesOfFieldsForGroup, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error);
                        return;
                    }

                    Close();
                }
                else
                {
                    // If the values are the same then it returns with warning message
                    if (oldGroupID == nupGroupID.Value.ToString() && oldGroupName == tbGroupName.Text)
                    {
                        customMsgBox = new CustomMsgBox();
                        customMsgBox.Show(Texts.ErrorMessages.NothingChangedForUpdate, Texts.Captions.Warning, CustomMsgBox.MsgBoxIcon.Warning, CustomMsgBox.Button.OK);
                        return;
                    }

                    // Freez controls
                    nupGroupID.Enabled = false;
                    tbGroupName.Enabled = false;

                    // Update the group
                    _isSuccess = taskModification.UpdateGroup(oldGroupID, nupGroupID.Value.ToString(), oldGroupName, tbGroupName.Text);

                    if (!_isSuccess)
                    {
                        customMsgBox = new CustomMsgBox();
                        customMsgBox.ShowError(Texts.ErrorMessages.CheckValuesOfFieldsForGroup, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error);
                        // Freez controls
                        nupGroupID.Enabled = true;
                        tbGroupName.Enabled = true;
                        return;
                    }

                    // Enable controls
                    nupGroupID.Enabled = true;
                    tbGroupName.Enabled = true;

                    Close();
                }
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
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
