using emira.BusinessLogicLayer;
using emira.HelperFunctions;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace emira.GUI
{
    public partial class TaskManager : UserControl
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        CustomMsgBox customMsgBox;
        DataTable dataTable;
        TaskModification taskModification;

        public static string cbGroupValue = string.Empty;

        public TaskManager()
        {
            InitializeComponent();
        }

        private void UpdateGroups()
        {
            try
            {
                // Clean up the control
                cbGroupName.Items.Clear();

                taskModification = new TaskModification();

                // Fill the combox with groups from DB
                List<string> _groups = taskModification.GetGroups(true);

                if (_groups.Count == 0) return;

                foreach (var item in _groups)
                {
                    cbGroupName.Items.Add(item);
                }

                cbGroupName.SelectedItem = _groups[0];
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void TaskManager_Load(object sender, EventArgs e)
        {
            try
            {
                UpdateGroups();

                UpdateTreeView();

                UpdateTaskID();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nupTaskID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbGroupName_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                UpdateTaskID();
            }
            catch(Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void tvGroupsAndTasks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                string _group = string.Empty;
                string _taskID = string.Empty;
                string _taskName = string.Empty;
                int _ID = 1;

                // If the user chose the parent node then it returns
                if (e.Node.Parent == null) return;

                // If the user chose the reserved task then it returns
                if (e.Node.Text.Contains("0_")) return;

                // Get the group name
                _group = e.Node.Parent.Text;

                // Set the group name for the combobox if it is not empty
                if (!string.IsNullOrEmpty(_group))
                   cbGroupName.SelectedItem = _group;
                
                // Get the task ID and name
                _taskName = e.Node.Text.Remove(0, e.Node.Text.IndexOf(' ') + 1);
                _taskID = e.Node.Text.Remove(e.Node.Text.IndexOf(' ') + 1);

                // Set the task ID and task Name if they are not empty
                if (!string.IsNullOrEmpty(_taskID) && !string.IsNullOrEmpty(_taskName))
                {
                    tbTaskName.Text = _taskName;

                    // Get the task ID
                    _taskID = _taskID.Substring(_taskID.IndexOf('_') + 1);

                    // Get the task ID as int
                    Int32.TryParse(_taskID, out _ID);

                    nupTaskID.Value = _ID;
                }
                else
                {
                    // If something was wrong clean up the controls
                    tbTaskName.Text = string.Empty;
                    UpdateTaskID();
                }              
            }
            catch(Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }



        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            // User can not modify the combobox
            cbGroupName.Enabled = false;

            AddOrUpdateGroupPage _addOrUpdateGroupPage = new AddOrUpdateGroupPage();
            _addOrUpdateGroupPage.ShowDialog();

            // Combobox enabled again
            cbGroupName.Enabled = true;

            // Update the content of the combobox
            UpdateGroups();

            // Update the content of the tree view
            UpdateTreeView();
        }

        private void btnUpdateGroup_Click(object sender, EventArgs e)
        {
            // Check the combobox is empty or not
            if (string.IsNullOrEmpty(cbGroupName.Text))
            {
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.ComboboxIsEmptyForModify, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return;
            }

            // User can not modify the combobox
            cbGroupName.Enabled = false;

            cbGroupValue = cbGroupName.SelectedItem.ToString();

            AddOrUpdateGroupPage _addOrUpdateGroupPage = new AddOrUpdateGroupPage();
            _addOrUpdateGroupPage.ShowDialog();

            // Combobox enabled again
            cbGroupName.Enabled = true;

            // Update the content of the combobox
            UpdateGroups();

            // Update the content of the tree view
            UpdateTreeView();
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            try
            {
                // Check the combobox is empty or not
                if (string.IsNullOrEmpty(cbGroupName.Text))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.ComboboxIsEmptyForDelete, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    return;
                }

                taskModification = new TaskModification();
                dataTable = new DataTable();
                string[] _groupIDName = new string[2];

                _groupIDName = cbGroupName.Text.Split(' ');

                // Get the selected task(s) and warn the user because of data loss
                dataTable = taskModification.GetSelectedTaskBySelectedGroup(_groupIDName[0]);

                if (dataTable.Rows.Count > 0)
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

                bool _isSuccess = false;

                cbGroupName.Enabled = false;

                // Delete the group, task(s) and hours from Catalog if the period is not locked
                _isSuccess = taskModification.DeleteGroup(_groupIDName[0]);

                if (!_isSuccess)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.CheckValuesOfFieldsForGroup, Texts.Captions.InvalidValue, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    cbGroupName.Enabled = true;
                    return;
                }

                // Enable the combobox
                cbGroupName.Enabled = true;


                // Update the content of the combobox
                UpdateGroups();


                // Update the content of the tree view
                UpdateTreeView();
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }



        private void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                // Check the combobox is empty or not
                if (string.IsNullOrEmpty(cbGroupName.Text))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.ComboboxIsEmptyForAdd, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    return;
                }

                // Check the text field is empty or not
                if (!taskModification.TextBoxValueValidation(tbTaskName.Text))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.RequiredFieldIsEmpty, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    return;
                }

                // Freez the controls
                cbGroupName.Enabled = false;
                nupTaskID.Enabled = false;
                tbTaskName.Enabled = false;

                taskModification = new TaskModification();

                bool _isSuccess = false;

                // The text of the combobox contains the task ID and Name
                string[] _group = new string[2];
                _group = cbGroupName.Text.Split(' ');

                // Add new task
                _isSuccess = taskModification.AddNewTask(_group[0], nupTaskID.Value.ToString(), tbTaskName.Text);

                if (!_isSuccess)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.CheckValuesOfFieldsForTask, Texts.Captions.InvalidValue, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    cbGroupName.Enabled = true;
                    nupTaskID.Enabled = true;
                    tbTaskName.Enabled = true;
                    return;
                }

                // Set the next ID and clean up the TaskName
                nupTaskID.Value = nupTaskID.Value + 1;
                tbTaskName.Text = string.Empty;
                cbGroupName.Enabled = true;
                nupTaskID.Enabled = true;
                tbTaskName.Enabled = true;

                // Update the content of the tree view
                UpdateTreeView();
            }
            catch(Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }          
        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            try
            {
                // Check the text field is empty or not
                if (!taskModification.TextBoxValueValidation(tbTaskName.Text))
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.RequiredFieldIsEmpty, Texts.Captions.EmptyRequiredField, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    return;
                }

                // Freez the controls
                cbGroupName.Enabled = false;
                nupTaskID.Enabled = false;
                tbTaskName.Enabled = false;

                taskModification = new TaskModification();

                bool _isSuccess = false;

                // The text of the combobox contains the task ID and Name
                string[] _group = new string[2];
                _group = cbGroupName.Text.Split(' ');

                // Add new task
                //_isSuccess = taskModification.UpdateTask(_group[0], nupTaskID.Value.ToString(), tbTaskName.Text);

                if (!_isSuccess)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.CheckValuesOfFieldsForTask, Texts.Captions.InvalidValue, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    cbGroupName.Enabled = true;
                    nupTaskID.Enabled = true;
                    tbTaskName.Enabled = true;
                    return;
                }

                // Set the next ID and clean up the TaskName
                nupTaskID.Value = nupTaskID.Value + 1;
                tbTaskName.Text = string.Empty;
                cbGroupName.Enabled = true;
                nupTaskID.Enabled = true;
                tbTaskName.Enabled = true;

                // Update the content of the tree view
                UpdateTreeView();
            }
            catch(Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {

        }

        private void UpdateTreeView()
        {
            try
            {
                // Clean up the tree view
                tvGroupsAndTasks.Nodes.Clear();

                taskModification = new TaskModification();
                dataTable = new DataTable();

                // Get the group(s) from the TaskGroup table
                List<string> _groups = taskModification.GetGroups();
                string[] _group = new string[2];
                string _previousGroupID = string.Empty;

                foreach (string item in _groups)
                {
                    _group = item.Split(' ');
                    if (_previousGroupID != _group[0])
                    {
                        tvGroupsAndTasks.Nodes.Add(item);
                        _previousGroupID = _group[0];
                    }
                }

                // Get the task(s) from the Task table
                dataTable = taskModification.GetTask();

                string _actualTaskGroupID = string.Empty;
                string _actualTaskID = string.Empty;
                string _actualTaskName = string.Empty;
                string _previousTaskID = string.Empty;
                int _groupID = 0;

                // Set the child nodes and
                // Set the checkbox where the task is selected
                foreach (DataRow task in dataTable.Rows)
                {
                    _actualTaskGroupID = task[Texts.TaskProperties.GroupID].ToString();
                    _actualTaskID = task[Texts.TaskProperties.TaskID].ToString();
                    _actualTaskName = task[Texts.TaskProperties.TaskName].ToString();

                    Int32.TryParse(_actualTaskGroupID, out _groupID);

                    if (_previousTaskID == _actualTaskGroupID)
                    {
                        tvGroupsAndTasks.Nodes[_groupID].Nodes.Add(_actualTaskID + " " + _actualTaskName);
                    }
                    else
                    {
                        tvGroupsAndTasks.Nodes[_groupID].Nodes.Add(_actualTaskID + " " + _actualTaskName);
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

        private void UpdateTaskID()
        {
            try
            {
                // Check the combobox is empty or not
                if (string.IsNullOrEmpty(cbGroupName.Text)) return;
                
                // The text of the combobox contains the task ID and Name
                string[] _group = new string[2];
                _group = cbGroupName.SelectedItem.ToString().Split(' ');

                taskModification = new TaskModification();

                int _nextTaskID = 1;
                _nextTaskID = taskModification.GetNextTaskID(_group[0]);

                nupTaskID.Value = _nextTaskID;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        //private void dgvTaskModification_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    try
        //    {
        //        string _taskID = string.Empty;
        //        int _index = 0;
        //        tbTaskGroupID.Text = dgvTaskModification.SelectedRows[0].Cells[0].Value.ToString();
        //        tbTaskGroup.Text = dgvTaskModification.SelectedRows[0].Cells[1].Value.ToString();

        //        _taskID = dgvTaskModification.SelectedRows[0].Cells[2].Value.ToString();
        //        _index = _taskID.LastIndexOf('_');
        //        tbTaskID.Text = _taskID.Substring(_index + 1);

        //        tbTaskName.Text = dgvTaskModification.SelectedRows[0].Cells[3].Value.ToString();
        //    }
        //    catch (Exception error)
        //    {
        //        MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        bool _isSuccess = false;
        //        _taskModification = new TaskModification();
        //        if (!_taskModification.TextBoxValueValidation(tbTaskGroupID.Text) || !_taskModification.TextBoxValueValidation(tbTaskGroup.Text) ||
        //            !_taskModification.TextBoxValueValidation(tbTaskID.Text) || !_taskModification.TextBoxValueValidation(tbTaskName.Text))
        //        {
        //            MessageBox.Show(Texts.ErrorMessages.RequiredFieldIsEmpty, Texts.Captions.EmptyRequiredField, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        if (System.Text.RegularExpressions.Regex.IsMatch(tbTaskGroupID.Text, "^[a-z A-Z]"))
        //        {
        //            MessageBox.Show(lTaskGroupID.Text + Texts.ErrorMessages.NumericField, Texts.Captions.NumericField, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        if (System.Text.RegularExpressions.Regex.IsMatch(tbTaskID.Text, "^[a-z A-Z]"))
        //        {
        //            MessageBox.Show(lTaskID.Text + Texts.ErrorMessages.NumericField, Texts.Captions.NumericField, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        _taskModification = new TaskModification();
        //        _isSuccess = _taskModification.AddNewTask(tbTaskGroupID.Text, tbTaskGroup.Text, tbTaskID.Text, tbTaskName.Text);

        //        if (!_isSuccess)
        //        {
        //            MessageBox.Show(Texts.ErrorMessages.CheckValuesOfFields, Texts.Captions.InvalidValue, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        tbTaskGroupID.Text = string.Empty;
        //        tbTaskGroup.Text = string.Empty;
        //        tbTaskID.Text = string.Empty;
        //        tbTaskName.Text = string.Empty;
        //        UpdateTable();
        //    }
        //    catch (Exception error)
        //    {
        //        MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        _taskModification = new TaskModification();
        //        string oldTaskID = dgvTaskModification.SelectedRows[0].Cells[2].Value.ToString();
        //        _taskModification.UpdateTask(oldTaskID, tbTaskGroupID.Text, tbTaskGroup.Text, tbTaskID.Text, tbTaskName.Text);
        //        tbTaskGroupID.Text = string.Empty;
        //        tbTaskGroup.Text = string.Empty;
        //        tbTaskID.Text = string.Empty;
        //        tbTaskName.Text = string.Empty;
        //        UpdateTable();
        //    }
        //    catch (Exception error)
        //    {
        //        MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        foreach (DataGridViewRow actualRow in dgvTaskModification.SelectedRows)
        //        {
        //            string TaskGroupID = actualRow.Cells[0].Value.ToString();
        //            string TaskGroup = actualRow.Cells[1].Value.ToString();
        //            string TaskID = actualRow.Cells[2].Value.ToString();
        //            string TaskName = actualRow.Cells[3].Value.ToString();
        //            _taskModification = new TaskModification();
        //            _taskModification.DeleteItem(TaskGroupID, TaskGroup, TaskID, TaskName);
        //        }
        //        UpdateTable();
        //    }
        //    catch (Exception error)
        //    {
        //        MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btnImport_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnExport_Click(object sender, EventArgs e)
        //{
        //    _taskModification = new TaskModification();
        //    _dataTable = new DataTable();
        //    _dataTable = _taskModification.GetTasks();
        //    DataSet ds = new DataSet();
        //    ds.Tables.Add(_dataTable);
        //    ds.DataSetName = "TaskModification";
        //    SaveFileDialog sfd = new SaveFileDialog();
        //    sfd.Filter = "XML|*.xml";
        //    if (sfd.ShowDialog() == DialogResult.OK)
        //    {
        //        try
        //        {
        //            ds.WriteXml(sfd.FileName);
        //        }
        //        catch (Exception error)
        //        {
        //            MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //    }
        //}

        //private void btnPrint_Click(object sender, EventArgs e)
        //{
        //    PrintDialog printDialog = new PrintDialog();

        //    PrintDocument printDocument = new PrintDocument();

        //    printDialog.Document = printDocument;

        //    printDocument.PrintPage += printDocument_PrintPage;

        //    DialogResult result = printDialog.ShowDialog();

        //    if (result == DialogResult.OK)
        //    {
        //        printDocument.Print();
        //    }
        //}

        //private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        //{
        //    using (Font header_font = new Font("Times New Roman", 16, FontStyle.Bold))
        //    {
        //        using (Font body_font = new Font("Times New Roman", 12))
        //        {

        //            string[] _headers = {Texts.TaskProperties.TaskGroupID,
        //                                 Texts.TaskProperties.TaskGroupName,
        //                                 Texts.TaskProperties.TaskID,
        //                                 Texts.TaskProperties.TaskName };

        //            _taskModification = new TaskModification();
        //            _dataTable = new DataTable();
        //            _dataTable = _taskModification.GetTasks(false);

        //            int count = 0;
        //            //string[] _row = new string[_dataTable.Rows.Count];
        //            List<string> _row = new List<string>();
        //            List<string[]> _data = new List<string[]>();
        //            foreach (DataRow row in _dataTable.Rows)
        //            {
        //                foreach (var item in row.ItemArray)
        //                {
        //                    //_row[count] = item.ToString();
        //                    _row.Add(item.ToString());
        //                    count++;
        //                }
        //                _data.Add(_row.ToArray());
        //                count = 0;
        //                _row.Clear();
        //            }

        //            // We'll skip this much space between rows.
        //            int line_spacing = 20;

        //            string[][] _dataArray = _data.ToArray();

        //            // See how wide the columns must be.
        //            int[] column_widths = FindColumnWidths(
        //                            e.Graphics, header_font, body_font, _headers, _dataArray);

        //            // Start at the left margin.
        //            int x = e.MarginBounds.Left;

        //            // Print by columns.
        //            for (int col = 0; col < _headers.Length; col++)
        //            {
        //                // Print the header.
        //                int y = e.MarginBounds.Top;
        //                e.Graphics.DrawString(_headers[col],
        //                    header_font, Brushes.Blue, x, y);
        //                y += (int)(line_spacing * 1.5);

        //                // Print the items in the column.
        //                for (int row = 0; row <=
        //                    _dataArray.GetUpperBound(0); row++)
        //                {
        //                    e.Graphics.DrawString(_dataArray[row][col],
        //                        body_font, Brushes.Black, x, y);
        //                    y += line_spacing;
        //                }

        //                // Move to the next column.
        //                x += column_widths[col];
        //            } // Looping over columns


        //            //DrawGrid(e, y)
        //            e.HasMorePages = false;
        //        }
        //    }
        //}

        ////Figure out how wide each column should be.
        //private int[] FindColumnWidths(Graphics gr, Font header_font,
        //    Font body_font, string[] headers, string[][] values)
        //{
        //    // Make room for the widths.
        //    int[] widths = new int[headers.Length];

        //    // Find the width for each column.
        //    for (int col = 0; col < widths.Length; col++)
        //    {
        //        // Check the column header.
        //        widths[col] = (int)gr.MeasureString(
        //            headers[col], header_font).Width;

        //        // Check the items.
        //        for (int row = 0; row <= values.GetUpperBound(0); row++)
        //        {
        //            int value_width = (int)gr.MeasureString(
        //                values[row][col], body_font).Width;
        //            if (widths[col] < value_width)
        //                widths[col] = value_width;
        //        }

        //        // Add some extra space.
        //        widths[col] += 20;
        //    }

        //    return widths;
        //}

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle borderRectangle = new Rectangle(0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            e.Graphics.DrawRectangle(Pens.Black, borderRectangle);
            base.OnPaint(e);
        }
    }
}
