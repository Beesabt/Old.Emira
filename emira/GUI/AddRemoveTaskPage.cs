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
        int togMove;
        int mValX;
        int mValY;
        AddRemoveTask addRemoveTask;
        DataTable dataTable;

        List<TreeNode> _SelectedItemsAfterLoad = new List<TreeNode>();

        public AddRemoveTaskPage()
        {
            InitializeComponent();
        }

        private void AddRemoveTaskPage_Load(object sender, EventArgs e)
        {
            try
            {
                addRemoveTask = new AddRemoveTask();
                dataTable = new DataTable();

                string _actualTaskGroupID = string.Empty;
                string _actualTaskGroup = string.Empty;
                string _actualTaskID = string.Empty;
                string _actualTaskName = string.Empty;
                string _actualTaskSelected = string.Empty;
                string _actualTaskIDFirstNumber = string.Empty;
                string _actualTaskIDLastNumber = string.Empty;
                int _actualTaskIDInteger = 0;
                int _index = 0;
                string _previousGroupID = "0";
                string _previousTaskID = "0";

                dataTable = addRemoveTask.GetTask();

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

                foreach (DataRow task in dataTable.Rows)
                {
                    _actualTaskID = task[Texts.TaskProperties.TaskID].ToString();
                    _actualTaskName = task[Texts.TaskProperties.TaskName].ToString();

                    _index = _actualTaskID.IndexOf('_');
                    _actualTaskIDFirstNumber = _actualTaskID.Remove(_index);
                    _actualTaskIDInteger = Convert.ToInt32(_actualTaskIDFirstNumber);

                    if (_previousTaskID == _actualTaskIDFirstNumber)
                    {
                        tvAddOrRemoveTask.Nodes[_actualTaskIDInteger - 1].Nodes.Add(_actualTaskID + " " + _actualTaskName);
                    }
                    else
                    {
                        tvAddOrRemoveTask.Nodes[_actualTaskIDInteger - 1].Nodes.Add(_actualTaskID + " " + _actualTaskName);
                        _previousTaskID = _actualTaskIDFirstNumber;
                    }

                }

                foreach (DataRow selected in dataTable.Rows)
                {
                    _actualTaskID = selected[Texts.TaskProperties.TaskID].ToString();
                    _actualTaskName = selected[Texts.TaskProperties.TaskName].ToString();
                    _actualTaskSelected = selected[Texts.TaskProperties.Selected].ToString();

                    _index = _actualTaskID.IndexOf('_');
                    _actualTaskIDFirstNumber = _actualTaskID.Remove(_index);
                    _actualTaskIDInteger = Convert.ToInt32(_actualTaskIDFirstNumber);

                    if (_actualTaskSelected.ToLower() == "true")
                    {
                        foreach (TreeNode item in tvAddOrRemoveTask.Nodes[_actualTaskIDInteger - 1].Nodes)
                        {
                            if (item.Text == (_actualTaskID + " " + _actualTaskName))
                            {
                                item.Checked = true;
                                _SelectedItemsAfterLoad.Add(item);
                                item.Parent.Checked = true;
                                item.Parent.Expand();
                                break;
                            }
                        }
                    }
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool ListCheck<T>(IEnumerable<T> l1, IEnumerable<T> l2)
        {
            if (l1 == null || l2 == null)
            {
                return false;
            }

            if (l1.Intersect(l2).Any())
            {            
                return true;
            }
            else
            {
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

                    _parentName = node.Parent.Text;
                    _nodeName = node.Text;

                    // Parent name and node name contain the ID and the name therefore need to split them
                    _index = _parentName.IndexOf(' ');
                    _parentID = _parentName.Remove(_index + 1);
                    _parentName = _parentName.Remove(0, (_index));

                    _index = _nodeName.IndexOf(' ');
                    _nodeID = _nodeName.Remove(_index + 1);
                    _nodeName = _nodeName.Remove(0, (_index));

                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add(Texts.TaskProperties.Selected, "True");

                    addRemoveTask.SaveModification(data, _nodeID.Trim());
                }

                foreach (TreeNode node in _unSelectedNodes)
                {

                    _parentName = node.Parent.Text;
                    _nodeName = node.Text;

                    // Parent name and node name contain the ID and the name therefore need to split them
                    _index = _parentName.IndexOf(' ');
                    _parentID = _parentName.Remove(_index + 1);
                    _parentName = _parentName.Remove(0, (_index));

                    _index = _nodeName.IndexOf(' ');
                    _nodeID = _nodeName.Remove(_index + 1);
                    _nodeName = _nodeName.Remove(0, (_index));

                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add(Texts.TaskProperties.Selected, "False");

                    addRemoveTask.SaveModification(data, _nodeID.Trim());

                    // Get the date
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
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tvAddOrRemoveTask_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                bool _isChecked = false;
                TreeNode _node = new TreeNode();
                _node = e.Node;
                _isChecked = _node.Checked;
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
                    _parentNode.Checked = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
