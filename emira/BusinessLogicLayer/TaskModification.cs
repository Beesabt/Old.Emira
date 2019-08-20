using System;
using System.Collections.Generic;
using System.Data;

using emira.DataAccessLayer;
using emira.HelperFunctions;
using emira.GUI;
using NLog;
using System.Text;
using System.Windows.Forms;

namespace emira.BusinessLogicLayer
{
    class TaskModification
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        CustomMsgBox customMsgBox;
        DatabaseHandler DBHandler;
        DataTable dataTable;

        /// <summary>
        /// Get the groups from the DB for combobox
        /// </summary>
        /// <returns>List of the groups</returns>
        public List<string> GetGroups(bool forCombobox = false)
        {
            List<string> _groups = new List<string>();
            try
            {
                StringBuilder _sb = new StringBuilder();
                DBHandler = new DatabaseHandler();
                dataTable = new DataTable();

                // Get the group(s)
                string _command = string.Empty;
                if (forCombobox)
                {
                    _command = string.Format("SELECT * FROM {0} WHERE {1} != '0' ORDER BY {1}",
                        Texts.DataTableNames.TaskGroup,
                        Texts.TaskGropuProperties.GroupID);
                }
                else
                {
                    _command = string.Format("SELECT * FROM {0} ORDER BY {1}",
                        Texts.DataTableNames.TaskGroup,
                        Texts.TaskGropuProperties.GroupID);
                }

                dataTable = DBHandler.GetGroups(_command);

                // Get the ID and Name for the combobox into a list
                string _actualGroupID = string.Empty;
                string _actualGroupName = string.Empty;

                foreach (DataRow item in dataTable.Rows)
                {
                    _actualGroupID = item[Texts.TaskGropuProperties.GroupID].ToString();
                    _actualGroupName = item[Texts.TaskGropuProperties.GroupName].ToString();

                    // Add to list the 'groupID groupName'
                    _sb.Append(_actualGroupID + " " + _actualGroupName);
                    _groups.Add(_sb.ToString());

                    // Clean up the string builder for the new 'groupID groupName'
                    _sb = _sb.Clear();
                }

                return _groups;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _groups;
            }
        }

        /// <summary>
        /// Get the task(s) for tree view 
        /// </summary>
        /// <returns>DataTable with the task(s)</returns>
        public DataTable GetTask()
        {
            dataTable = new DataTable();
            try
            {
                DBHandler = new DatabaseHandler();

                dataTable = DBHandler.GetTask();

                return dataTable;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return dataTable;
            }
        }

        /// <summary>
        /// Validation of the text box against empty field
        /// </summary>
        /// <param name="textBoxValue">Textbox's value</param>
        /// <returns>True, if it is not empty</returns>
        public bool TextBoxValueValidation(string textBoxValue)
        {
            bool _isSuccess = true;
            try
            {
                if (string.IsNullOrEmpty(textBoxValue.Trim()) || string.IsNullOrWhiteSpace(textBoxValue))
                {
                    _isSuccess = false;
                }
                return _isSuccess;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _isSuccess;
            }
        }

        /// <summary>
        /// Get the next group ID for number up down
        /// </summary>
        /// <returns>Return with the next group ID</returns>
        public int GetNextGroupID()
        {
            int _nextGroupID = 1;
            try
            {
                int _maxGroupID = 0;
                DBHandler = new DatabaseHandler();

                _maxGroupID = DBHandler.GetMaxGroupID();

                _nextGroupID = _maxGroupID + 1;

                return _nextGroupID;
            }
            catch(Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _nextGroupID;
            }
        }

        /// <summary>
        /// Get the next task ID for number up down
        /// </summary>
        /// <param name="groupID">Group ID of the task</param>
        /// <returns>Return with the next task ID</returns>
        public int GetNextTaskID(string groupID)
        {
            int _nextTaskID = 1;
            try
            {
                DBHandler = new DatabaseHandler();
                dataTable = new DataTable();

                dataTable = DBHandler.GetAllTasksByGroup(groupID);

                string _taskID = string.Empty;
                string[] _task = new string[2];
                List<int> _taskIDs = new List<int>();
                int _iTaskID = 0;

                foreach (DataRow item in dataTable.Rows)
                {
                    _taskID = item[Texts.TaskProperties.TaskID].ToString();

                    _task = _taskID.Split('_');

                    if (Int32.TryParse(_task[1], out _iTaskID))
                    {
                        _taskIDs.Add(_iTaskID);
                    }
                }

                if (_taskIDs.Count != 0)
                {
                    _taskIDs.Sort();
                    _nextTaskID = _taskIDs[_taskIDs.Count - 1] + 1;
                }

                return _nextTaskID;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _nextTaskID;
            }
        }

        /// <summary>
        /// Add new group to the DB
        /// </summary>
        /// <param name="groupID">ID of the new group</param>
        /// <param name="groupName">Name of the new group</param>
        /// <returns>True, if the new group is added</returns>
        public bool AddNewGroup(string groupID, string groupName)
        {
            bool _isSuccess = false;
            try
            {
                bool _existGroupID = false;
                bool _existGroupName = false;
                int _groupID = -1; // 0 is reserved for 'Távollét'
                int _result = 0;
                DBHandler = new DatabaseHandler();

                // Get groupID as int
                Int32.TryParse(groupID, out _groupID);

                // Check the exists of the groupID and groupName
                _existGroupID = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupID, groupID);
                _existGroupName = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupName, groupName);

                // Insert the new group
                if (!_existGroupID && !_existGroupName)
                {
                    _result = DBHandler.InsertNewGroup(_groupID, groupName);
                    if (_result > 0) _isSuccess = true;
                    return _isSuccess;
                }

                return _isSuccess;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _isSuccess;
            }
        }

        /// <summary>
        /// Add new task to the DB
        /// </summary>
        /// <param name="groupID">ID of the group</param>
        /// <param name="taskID">ID of the new task</param>
        /// <param name="taskName">Name of the new task</param>
        /// <returns>True, if the new task is added</returns>
        public bool AddNewTask(string groupID, string taskID, string taskName)
        {
            bool _isSuccess = false;
            try
            {
                bool _existGroupID = false;
                bool _existGroupName = false;
                string _taskID = string.Empty;
                int _result = 0;
                DBHandler = new DatabaseHandler();

                // Get taskID as int
                _taskID = groupID + '_' + taskID;

                // Check the exists of the taskID and taskName
                _existGroupID = DBHandler.DoesExist(Texts.DataTableNames.Task, Texts.TaskProperties.TaskID, _taskID);
                _existGroupName = DBHandler.DoesExist(Texts.DataTableNames.Task, Texts.TaskProperties.TaskName, taskName);

                // Insert the new group
                if (!_existGroupID && !_existGroupName)
                {
                    _result = DBHandler.InsertNewTask(groupID, _taskID, taskName);
                    if (_result > 0) _isSuccess = true;
                    return _isSuccess;
                }

                return _isSuccess;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _isSuccess;
            }
        }

        /// <summary>
        /// Update the group ID or Name or both (= switch)
        /// </summary>
        /// <param name="oldGroupID">old group ID</param>
        /// <param name="newGroupID">new group ID</param>
        /// <param name="oldGroupName">old group Name</param>
        /// <param name="newGroupName">new group Name</param>
        /// <returns>True, if the update was success</returns>
        public bool UpdateGroup(string oldGroupID, string newGroupID, string oldGroupName, string newGroupName)
        {
            bool _isSuccess = false;
            try
            {
                bool _existGroupID = false;
                bool _existGroupName = false;
                int _groupID = -1; // 0 is reserved for 'Távollét'
                int _updatedRow = 0;

                // Get groupID as int
                Int32.TryParse(newGroupID, out _groupID);

                // Check the exists of the groupID and groupName
                // 1. If the group ID is the same, but the group name changed
                if (oldGroupID == newGroupID)
                {
                    _existGroupName = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupName, newGroupName);
                    if (_existGroupName) return _isSuccess;

                    // Update the group
                    DBHandler = new DatabaseHandler();

                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add(Texts.TaskGropuProperties.GroupID, newGroupID);
                    data.Add(Texts.TaskGropuProperties.GroupName, newGroupName);

                    _isSuccess = DBHandler.ModifyGroup(data, Texts.TaskGropuProperties.GroupID, oldGroupID, _updatedRow);

                    return _isSuccess;
                }

                // 2. If the group Name is the same, but the group ID changed
                if (oldGroupName == newGroupName)
                {
                    _existGroupID = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupID, newGroupID);
                    if (_existGroupID) return _isSuccess;

                    // Update the group
                    DBHandler = new DatabaseHandler();

                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add(Texts.TaskGropuProperties.GroupID, newGroupID);
                    data.Add(Texts.TaskGropuProperties.GroupName, newGroupName);

                    _isSuccess = DBHandler.ModifyGroup(data, Texts.TaskGropuProperties.GroupID, oldGroupID, _updatedRow);

                    return _isSuccess;
                }

                // 3. If the group ID and Name are changed (= switch)
                _existGroupID = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupID, newGroupID);
                _existGroupName = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupName, newGroupName);

                if (!_existGroupID && !_existGroupName)
                {
                    // Update the group
                    DBHandler = new DatabaseHandler();

                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add(Texts.TaskGropuProperties.GroupID, newGroupID);
                    data.Add(Texts.TaskGropuProperties.GroupName, newGroupName);

                    _isSuccess = DBHandler.ModifyGroup(data, Texts.TaskGropuProperties.GroupID, oldGroupID, _updatedRow);
                }

                return _isSuccess;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _isSuccess;
            }
        }

        public bool UpdateTask(string oldTaskID, string taskGroupID, string taskGroup, string taskID, string taskName)
        {
            bool _isSuccess = false;
            try
            {
                //bool _existGroupID = false;
                //bool _existGroupName = false;
                //int _groupID = -1; // 0 is reserved for 'Távollét'
                //int _updatedRow = 0;

                //// Get groupID as int
                //Int32.TryParse(newGroupID, out _groupID);

                //// Check the exists of the groupID and groupName
                //// 1. If the group ID is the same, but the group name changed
                //if (oldGroupID == newGroupID)
                //{
                //    _existGroupName = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupName, newGroupName);
                //    if (_existGroupName) return _isSuccess;

                //    // Update the group
                //    DBHandler = new DatabaseHandler();

                //    Dictionary<string, string> data = new Dictionary<string, string>();
                //    data.Add(Texts.TaskGropuProperties.GroupID, newGroupID);
                //    data.Add(Texts.TaskGropuProperties.GroupName, newGroupName);

                //    _isSuccess = DBHandler.ModifyGroup(data, Texts.TaskGropuProperties.GroupID, oldGroupID, _updatedRow);

                //    return _isSuccess;
                //}

                //// 2. If the group Name is the same, but the group ID changed
                //if (oldGroupName == newGroupName)
                //{
                //    _existGroupID = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupID, newGroupID);
                //    if (_existGroupID) return _isSuccess;

                //    // Update the group
                //    DBHandler = new DatabaseHandler();

                //    Dictionary<string, string> data = new Dictionary<string, string>();
                //    data.Add(Texts.TaskGropuProperties.GroupID, newGroupID);
                //    data.Add(Texts.TaskGropuProperties.GroupName, newGroupName);

                //    _isSuccess = DBHandler.ModifyGroup(data, Texts.TaskGropuProperties.GroupID, oldGroupID, _updatedRow);

                //    return _isSuccess;
                //}

                //// 3. If the group ID and Name are changed (= switch)
                //_existGroupID = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupID, newGroupID);
                //_existGroupName = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupName, newGroupName);

                //if (!_existGroupID && !_existGroupName)
                //{
                //    // Update the group
                //    DBHandler = new DatabaseHandler();

                //    Dictionary<string, string> data = new Dictionary<string, string>();
                //    data.Add(Texts.TaskGropuProperties.GroupID, newGroupID);
                //    data.Add(Texts.TaskGropuProperties.GroupName, newGroupName);

                //    _isSuccess = DBHandler.ModifyGroup(data, Texts.TaskGropuProperties.GroupID, oldGroupID, _updatedRow);
                //}

                return _isSuccess;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _isSuccess;
            }
        }

        /// <summary>
        /// Get the selected task by groupID
        /// </summary>
        /// <param name="groupID">The selected group ID</param>
        /// <returns>DataTable with the selected tasks</returns>
        public DataTable GetSelectedTaskBySelectedGroup(string groupID)
        {
            dataTable = new DataTable();
            try
            {
                DBHandler = new DatabaseHandler();

                dataTable = DBHandler.GetSelectedTaskByGroup(groupID);

                return dataTable;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return dataTable;
            }
        }

        /// <summary>
        /// Delete the group and tasks from Catalog and Task table
        /// </summary>
        /// <param name="groupID">The group ID what the user want to delete</param>
        /// <returns>True, if the group is deleted</returns>
        public bool DeleteGroup(string groupID)
        {
            bool _isSuccess = false;
            try
            {
                int _deletedRow = 0;
                DBHandler = new DatabaseHandler();
                dataTable = new DataTable();

                // Delete the task(s) from Catalog were the period is not locked
                DBHandler.DeleteUsedTasksFromCatalog(groupID);

                // Delete the task(s) from the Task which is under the selected group
                DBHandler.DeleteGroupAndTasks(Texts.DataTableNames.Task, groupID);

                // Delete the group
                _deletedRow = DBHandler.DeleteGroupAndTasks(Texts.DataTableNames.TaskGroup, groupID);

                if (_deletedRow > 0) _isSuccess = true;

                return _isSuccess;
            }
            catch(Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _isSuccess;
            }
        }


        public bool DeleteTask(string taskGroupID, string taskGroup, string taskID, string taskName)
        {
            bool isSuccess = false;
            int result = 0;
            DBHandler = new DatabaseHandler();
            result = DBHandler.DeleteRow(taskGroupID, taskGroup, taskID, taskName);
            if (result > 0) isSuccess = true;
            return isSuccess;
        }

        public DataTable GetTasks(bool withSelected = true)
        {
            string command = string.Empty;
            if (!withSelected)
            {
                command = string.Format("SELECT {1},{2},{3},{4} FROM {0} ORDER BY {1}",
                    Texts.DataTableNames.Task,
                    Texts.TaskProperties.GroupID,
                    Texts.TaskProperties.TaskGroupName,
                    Texts.TaskProperties.TaskID,
                    Texts.TaskProperties.TaskName);
            }
            else
            {
                command = string.Format("SELECT * FROM {0} ORDER BY {1}", Texts.DataTableNames.Task, Texts.TaskProperties.GroupID);
            }

            DBHandler = new DatabaseHandler();
            dataTable = new DataTable();

            dataTable = DBHandler.GetTask(command);
            return dataTable;
        }
    }
}
