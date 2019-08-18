using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using emira.BusinessLogicLayer;
using emira.HelperFunctions;

namespace emira.GUI
{
    public partial class AddRemoveTaskPage : Form
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        int togMove;
        int mValX;
        int mValY;
        AddRemoveTask addRemoveTask;
        DataTable dataTable;
        CustomMsgBox customMsgBox;

        List<TreeNode> _SelectedItemsAfterLoad = new List<TreeNode>();

        public AddRemoveTaskPage()
        {
            InitializeComponent();
        }

        private void AddRemoveTaskPage_Load(object sender, EventArgs e)
        {
            try
            {
                string _actualTaskGroupID = string.Empty;
                string _actualTaskGroup = string.Empty;
                string _actualTaskID = string.Empty;
                string _actualTaskName = string.Empty;
                bool _actualTaskSelected = false;
                string _actualTaskIDFirstNumber = string.Empty;
                string _actualTaskIDLastNumber = string.Empty;
                int _actualTaskIDInteger = 0;
                int _index = 0;
                string _previousGroupID = "0";
                string _previousTaskID = "0";

                addRemoveTask = new AddRemoveTask();
                dataTable = new DataTable();

                // Get the tasks from the Task table
                dataTable = addRemoveTask.GetTask();

                // Set the parent nodes
                foreach (DataRow group in dataTable.Rows)
                {
                    _actualTaskGroupID = group[Texts.TaskProperties.TaskGroupID].ToString();
                    _actualTaskGroup = group[Texts.TaskProperties.TaskGroupName].ToString();


                    if (_previousGroupID != _actualTaskGroupID)
                    {
                        tvAddOrRemoveTask.Nodes.Add(_actualTaskGroupID + " " + _actualTaskGroup);
                        _previousGroupID = _actualTaskGroupID;
                    }
                }

                // Set the child nodes and
                // Set the checkbox where the task is selected
                foreach (DataRow task in dataTable.Rows)
                {
                    _actualTaskID = task[Texts.TaskProperties.TaskID].ToString();
                    _actualTaskName = task[Texts.TaskProperties.TaskName].ToString();

                    _index = _actualTaskID.IndexOf('_');
                    _actualTaskIDFirstNumber = _actualTaskID.Remove(_index);

                    Int32.TryParse(_actualTaskIDFirstNumber, out _actualTaskIDInteger);
                    Boolean.TryParse(task[Texts.TaskProperties.Selected].ToString(), out _actualTaskSelected);

                    if (_previousTaskID == _actualTaskIDFirstNumber)
                    {
                        TreeNode _taskNode = tvAddOrRemoveTask.Nodes[_actualTaskIDInteger - 1].Nodes.Add(_actualTaskID + " " + _actualTaskName);
                        if (_actualTaskSelected)
                        {
                            _taskNode.Checked = true;
                            _SelectedItemsAfterLoad.Add(_taskNode);
                            _taskNode.Parent.Checked = true;
                            _taskNode.Parent.Expand();
                        }
                    }
                    else
                    {
                        TreeNode _taskNode = tvAddOrRemoveTask.Nodes[_actualTaskIDInteger - 1].Nodes.Add(_actualTaskID + " " + _actualTaskName);
                        if (_actualTaskSelected)
                        {
                            _taskNode.Checked = true;
                            _SelectedItemsAfterLoad.Add(_taskNode);
                            _taskNode.Parent.Checked = true;
                            _taskNode.Parent.Expand();
                        }
                        _previousTaskID = _actualTaskIDFirstNumber;
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



        private static bool ListCheck<T>(IEnumerable<T> l1, IEnumerable<T> l2)
        {
            try
            {
                // If a selected task became unselected then we return true othewise false
                if (l1.Intersect(l2).Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                Logger.Error(error);
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<TreeNode> _selectedNodes = new List<TreeNode>();
                List<TreeNode> _unSelectedNodes = new List<TreeNode>();
                addRemoveTask = new AddRemoveTask();

                string _parentName = string.Empty;
                string _nodeName = string.Empty;
                string _parentID = string.Empty;
                string _nodeID = string.Empty;

                int _index = 0;

                // Fill up the _selectedNodes and _unSelectedNodes with tasks according to the actual state
                foreach (TreeNode parent in tvAddOrRemoveTask.Nodes)
                {
                    if (parent.Checked)
                    {
                        foreach (TreeNode node in parent.Nodes)
                        {
                            if (node.Checked)
                            {
                                _selectedNodes.Add(node);
                            }
                            else
                            {
                                _unSelectedNodes.Add(node);
                            }
                        }
                    }
                    else
                    {
                        foreach (TreeNode node in parent.Nodes)
                        {
                            _unSelectedNodes.Add(node);
                        }
                    }
                }

                // If the task was checked then it will be removed from the Catalog
                // if the user says 'Yes'
                if (ListCheck(_SelectedItemsAfterLoad, _unSelectedNodes))
                {
                    var _result = MessageBox.Show(Texts.WarningMessages.DeleteTask,
                                            Texts.Captions.LossOfData,
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);
                    if (_result == DialogResult.No)
                    {
                        return;
                    }
                }

                Cursor.Hide();

                foreach (TreeNode node in _selectedNodes)
                {
                    _nodeName = node.Text;

                    // Task name and node name contain the ID and the name therefore need to split them
                    _index = _nodeName.IndexOf(' ');
                    _nodeID = _nodeName.Remove(_index + 1);
                    _nodeName = _nodeName.Remove(0, (_index));

                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add(Texts.TaskProperties.Selected, "True");

                    // Save the task as selected
                    addRemoveTask.SaveModification(data, _nodeID.Trim());
                }

                foreach (TreeNode node in _unSelectedNodes)
                {
                    _nodeName = node.Text;

                    // Task name and node name contain the ID and the name therefore need to split them
                    _index = _nodeName.IndexOf(' ');
                    _nodeID = _nodeName.Remove(_index + 1);
                    _nodeName = _nodeName.Remove(0, (_index));

                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add(Texts.TaskProperties.Selected, "False");

                    // Save the task as unselected
                    addRemoveTask.SaveModification(data, _nodeID.Trim());

                    // Get the selected date from the WorkingHours form
                    Form _workingHoursPage = Application.OpenForms["WorkingHoursPage"];
                    Control[] _cbYearWithMonth = _workingHoursPage.Controls.Find("cbYearWithMonth", true);
                    string date = string.Empty;

                    foreach (var item in _cbYearWithMonth)
                    {
                        date = item.Text;
                    }

                    // Remove the hours from the Catalog for the task
                    addRemoveTask.DeleteHours(date, _nodeID.Trim());
                }
                Cursor.Show();
                Close();
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }

        }

        private void tvAddOrRemoveTask_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                bool _isChecked = false;
                bool _isCheckedChildren = false;
                TreeNode _node = new TreeNode();

                // Set the task's or parent node's state
                _node = e.Node;
                _isChecked = _node.Checked;

                // If it is a parent then we check or uncheck all chid nodes
                // Or if it is a child node then we check the parent node according to the
                // other nodes' state under the parent
                if (_node.Nodes.Count > 0)
                {
                    foreach (TreeNode item in _node.Nodes)
                    {
                        item.Checked = _isChecked;
                    }
                }
                else
                {
                    TreeNode _parentNode = new TreeNode();
                    _parentNode = _node.Parent;

                    foreach (TreeNode item in _parentNode.Nodes)
                    {
                        _isCheckedChildren |= item.Checked;
                    }

                    if (_isCheckedChildren)
                    {
                        _parentNode.Checked = true;
                    }
                    else
                    {
                        _parentNode.Checked = false;
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



        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
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
