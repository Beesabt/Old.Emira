using emira.BusinessLogicLayer;
using emira.HelperFunctions;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace emira.GUI
{
    public partial class TaskManager : UserControl
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        CustomMsgBox customMsgBox;
        DataTable dataTable;
        TaskModification taskModification;
        string oldGroupID = string.Empty;
        string oldTaskID = string.Empty;
        string oldTaskName = string.Empty;

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
            catch (Exception error)
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

                // Save the old group ID for update
                oldGroupID = e.Node.Parent.Text.Remove(e.Node.Parent.Text.IndexOf(' '));

                // Get the task ID and name
                _taskName = e.Node.Text.Remove(0, e.Node.Text.IndexOf(' ') + 1);
                _taskID = e.Node.Text.Remove(e.Node.Text.IndexOf(' '));

                // Get the task ID
                _taskID = _taskID.Substring(_taskID.IndexOf('_') + 1);

                // Save the old values for update
                oldTaskName = _taskName;
                oldTaskID = _taskID;

                // Set the task ID and task Name if they are not empty
                if (!string.IsNullOrEmpty(_taskID) && !string.IsNullOrEmpty(_taskName))
                {
                    tbTaskName.Text = _taskName;

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
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }



        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog _openFileDialog = new OpenFileDialog();
                _openFileDialog.Filter = "XML|*.xml";
                if (_openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var _xmlFilename = _openFileDialog.FileName;


                    var _pathOfDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    var _xmlFilePath = Path.Combine(_pathOfDesktop, _xmlFilename);

                    XmlSchemaSet _schema = new XmlSchemaSet();

                    string _executableLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    string _pathOfDebug = (Path.GetDirectoryName(_executableLocation));

                    string _xsdFilePath = string.Empty;
                    _xsdFilePath = Path.Combine(_pathOfDebug, @"ApplicationFiles\XSDFiles\" + "TaskManager.xsd");
                    _schema.Add(string.Empty, _xsdFilePath);

                    XDocument _xmlFile = XDocument.Load(_xmlFilePath);

                    bool _validationError = false;

                    _xmlFile.Validate(_schema, (s, ev) =>
                    {
                        _validationError = true;
                    });

                    if (_validationError)
                    {
                        customMsgBox = new CustomMsgBox();
                        customMsgBox.Show("Az elem(ek) nem felelnek meg a típusnak!", Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                        return;
                    }

                    IEnumerable<int> _groupIDs = from item in _xmlFile.Descendants("Table1")
                                                 select (int)item.Element("GroupID");

                    IEnumerable<string> _groupNames = from item in _xmlFile.Descendants("Table1")
                                                      select (string)item.Element("GroupName");

                    // Check the group ID, it has not to be 0
                    if (_groupIDs.Contains(0))
                    {
                        customMsgBox = new CustomMsgBox();
                        customMsgBox.Show("The group ID can not be 0, it is reserved!", Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                        return;
                    }

                    // Check the group ID and group Name
                    int _previousGroupID = -1;
                    string _previousGroupName = string.Empty;
                    for (int i = 0; i < _groupIDs.Count(); i++)
                    {
                        if (_previousGroupID != _groupIDs.ElementAt(i))
                        {
                            _previousGroupID = _groupIDs.ElementAt(i);

                            if (_previousGroupName == _groupNames.ElementAt(i))
                            {
                                customMsgBox = new CustomMsgBox();
                                customMsgBox.Show("The group name has to be unique!", Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                                return;
                            }

                            _previousGroupName = _groupNames.ElementAt(i);
                        }

                        if (_previousGroupName != _groupNames.ElementAt(i))
                        {
                            customMsgBox = new CustomMsgBox();
                            customMsgBox.Show("The group ID has to be unique!", Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                            return;
                        }
                    }

                    // Get the GroupIDs and GroupNames
                    IEnumerable<int> _groupIDsWithoutDuplicates = _groupIDs.Distinct();
                    IEnumerable<string> _groupNamesWithoutDuplicates = _groupNames.Distinct();

                    // Check the task ID
                    for (int i = 0; i < _groupIDsWithoutDuplicates.Count(); i++)
                    {
                        IEnumerable<int> _taskIDs = from item in _xmlFile.Descendants("Table1")
                                                    where (int)item.Element("GroupID") == _groupIDsWithoutDuplicates.ElementAt(i)
                                                    select (int)item.Element("TaskID");


                        IEnumerable<int> _taskIDsWithoutDuplicates = _taskIDs.Distinct();

                        if (_taskIDsWithoutDuplicates.Count() < _taskIDs.Count())
                        {
                            customMsgBox = new CustomMsgBox();
                            customMsgBox.Show("The task ID has to be unique under the group!", Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                            return;
                        }

                        // Check the task Name
                        IEnumerable<string> _taskNames = from item in _xmlFile.Descendants("Table1")
                                                         where (string)item.Element("GroupName") == _groupNamesWithoutDuplicates.ElementAt(i)
                                                         select (string)item.Element("TaskName");

                        IEnumerable<string> _taskNamesWithoutDuplicates = _taskNames.Distinct();

                        if (_taskNamesWithoutDuplicates.Count() < _taskNames.Count())
                        {
                            customMsgBox = new CustomMsgBox();
                            customMsgBox.Show("The task Name has to be unique under the group!", Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                            return;
                        }
                    }

                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show("Import OK!", Texts.Captions.Information, CustomMsgBox.MsgBoxIcon.Information, CustomMsgBox.Button.OK);
                }
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                taskModification = new TaskModification();
                dataTable = new DataTable();
                dataTable = taskModification.GetTasksForExport();
                DataSet ds = new DataSet();
                ds.Tables.Add(dataTable);
                ds.DataSetName = "TaskModification";
                SaveFileDialog _saveFileDialog = new SaveFileDialog();
                _saveFileDialog.Filter = "XML|*.xml";
                if (_saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ds.WriteXml(_saveFileDialog.FileName);
                    }
                    catch (Exception error)
                    {
                        Logger.Error(error);
                        customMsgBox = new CustomMsgBox();
                        customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                        return;
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
            catch (Exception error)
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

                // The text of the combobox contains the group ID and Name
                string[] _group = new string[2];
                _group = cbGroupName.Text.Split(' ');

                // If the user did not change anything on the values
                if (_group[0] == oldGroupID && nupTaskID.Value.ToString() == oldTaskID && tbTaskName.Text == oldTaskName)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.NothingChangedForUpdate, Texts.Captions.Warning, CustomMsgBox.MsgBoxIcon.Warning, CustomMsgBox.Button.OK);
                    cbGroupName.Enabled = true;
                    nupTaskID.Enabled = true;
                    tbTaskName.Enabled = true;
                    return;
                }

                // Update the task
                _isSuccess = taskModification.UpdateTask(_group[0], oldGroupID, nupTaskID.Value.ToString(), oldTaskID, tbTaskName.Text, oldTaskName);

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
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            try
            {
                taskModification = new TaskModification();
                bool _selected = false;
                string[] _groupIDName = new string[2];

                _groupIDName = cbGroupName.Text.Split(' ');

                // Get the task is selected and warn the user because of data loss
                _selected = taskModification.GetSelectionStateOfTheSelectedTask(_groupIDName[0], nupTaskID.Value.ToString());

                if (_selected)
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

                // Freez controls
                cbGroupName.Enabled = false;
                nupTaskID.Enabled = false;
                tbTaskName.Enabled = false;

                // Delete the group, task(s) and hours from Catalog if the period is not locked
                _isSuccess = taskModification.DeleteTask(_groupIDName[0], nupTaskID.Value.ToString());

                if (!_isSuccess)
                {
                    customMsgBox = new CustomMsgBox();
                    customMsgBox.Show(Texts.ErrorMessages.CheckValuesOfFieldsForTask, Texts.Captions.InvalidValue, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                    cbGroupName.Enabled = true;
                    nupTaskID.Enabled = true;
                    tbTaskName.Enabled = true;
                    return;
                }

                // Enable the controls
                cbGroupName.Enabled = true;
                nupTaskID.Enabled = true;
                tbTaskName.Enabled = true;

                // Empty the text box
                UpdateTaskID();
                tbTaskName.Clear();

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
                dataTable = taskModification.GetTasks();

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
                        tvGroupsAndTasks.Nodes[_groupID].Nodes.Add(_actualTaskGroupID + "_" + _actualTaskID + " " + _actualTaskName);
                    }
                    else
                    {
                        tvGroupsAndTasks.Nodes[_groupID].Nodes.Add(_actualTaskGroupID + "_" + _actualTaskID + " " + _actualTaskName);
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

                // The text of the combobox contains the group ID and Name
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


        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle borderRectangle = new Rectangle(0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            e.Graphics.DrawRectangle(Pens.Black, borderRectangle);
            base.OnPaint(e);
        }
    }
}
