using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using emira.BusinessLogicLayer;
using emira.Utilities;

namespace emira.GUI
{
    public partial class AddRemoveTaskForm : Form
    {
        int togMove;
        int mValX;
        int mValY;
        AddRemoveTask addRemoveTask;
        TaskModification taskModification;
        DataTable dataTable;
        CustomMsgBox customMsgBox;

        List<TreeNode> _SelectedItemsAfterLoad = new List<TreeNode>();

        public AddRemoveTaskForm()
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
                string _actualTaskIDLastNumber = string.Empty;
                string _previousGroupID = string.Empty;
                string _previousTaskID = string.Empty;
                bool _actualTaskSelected = false;
                int _actualGroupID = 0;

                addRemoveTask = new AddRemoveTask();
                taskModification = new TaskModification();
                dataTable = new DataTable();
                List<string> _groups = new List<string>();

                // Get the groups from the TaskGroup table
                _groups = taskModification.GetGroups();

                // Set the parent nodes
                foreach (string group in _groups)
                {
                    _actualTaskGroupID = group.Remove(group.IndexOf(' '));
                    _actualTaskGroup = group.Remove(group.IndexOf(' ') + 1);


                    if (_previousGroupID != _actualTaskGroupID)
                    {
                        tvAddOrRemoveTask.Nodes.Add(group);
                        _previousGroupID = _actualTaskGroupID;
                    }
                }

                // Get the tasks from the Task table
                dataTable = taskModification.GetTasks();

                // Set the child nodes and
                // Set the checkbox where the task is selected
                foreach (DataRow task in dataTable.Rows)
                {
                    _actualTaskGroupID = task[Texts.TaskProperties.GroupID].ToString();
                    _actualTaskID = task[Texts.TaskProperties.TaskID].ToString();
                    _actualTaskName = task[Texts.TaskProperties.TaskName].ToString();

                    Int32.TryParse(_actualTaskGroupID, out _actualGroupID);
                    Boolean.TryParse(task[Texts.TaskProperties.Selected].ToString(), out _actualTaskSelected);

                    if (_previousTaskID == _actualTaskID)
                    {
                        TreeNode _taskNode = tvAddOrRemoveTask.Nodes[_actualGroupID].Nodes.Add(_actualTaskGroupID + "_" + _actualTaskID + " " + _actualTaskName);
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
                        TreeNode _taskNode = tvAddOrRemoveTask.Nodes[_actualGroupID].Nodes.Add(_actualTaskGroupID + "_" + _actualTaskID + " " + _actualTaskName);
                        if (_actualTaskSelected)
                        {
                            _taskNode.Checked = true;
                            _SelectedItemsAfterLoad.Add(_taskNode);
                            _taskNode.Parent.Checked = true;
                            _taskNode.Parent.Expand();
                        }
                        _previousTaskID = _actualTaskID;
                    }
                }
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
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
                MyLogger.GetInstance().Error(error.Message);
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

                string _nodeName = string.Empty;
                string _nodeID = string.Empty;
                string _groupID = string.Empty;
                string _taskID = string.Empty;

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
                    customMsgBox = new CustomMsgBox();
                    var _result = customMsgBox.Show(Texts.WarningMessages.DeleteTask,
                                      Texts.Captions.LossOfData,
                                      CustomMsgBox.MsgBoxIcon.Question,
                                      CustomMsgBox.Button.YesNo);
                    
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
                    _nodeID = _nodeName.Remove(_nodeName.IndexOf(' '));
                    _taskID = _nodeID.Substring(_nodeID.IndexOf('_') + 1);

                    // Get group ID
                    _groupID = node.Parent.Text.Remove(node.Parent.Text.IndexOf(' '));

                    // Save the task as selected
                    addRemoveTask.SaveModification("1", _groupID, _taskID);
                }

                foreach (TreeNode node in _unSelectedNodes)
                {
                    _nodeName = node.Text;

                    // Task name and node name contain the ID and the name therefore need to split them
                    _nodeID = _nodeName.Remove(_nodeName.IndexOf(' '));
                    _taskID = _nodeID.Substring(_nodeID.IndexOf('_') + 1);

                    // Get group ID
                    _groupID = node.Parent.Text.Remove(node.Parent.Text.IndexOf(' '));

                    // Save the task as unselected
                    addRemoveTask.SaveModification("0", _groupID, _taskID);

                    // Get the selected date from the WorkingHours form
                    Form _workingHoursPage = Application.OpenForms["WorkingHoursPage"];
                    Control[] _cbYearWithMonth = _workingHoursPage.Controls.Find("cbYearWithMonth", true);
                    string _date = string.Empty;

                    foreach (var item in _cbYearWithMonth)
                    {
                        _date = item.Text;
                    }

                    // Remove the hours from the Catalog for the task
                    addRemoveTask.DeleteHours(_date, _groupID, _taskID);
                }
                Cursor.Show();
                Close();
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
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
                MyLogger.GetInstance().Error(error.Message);
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
